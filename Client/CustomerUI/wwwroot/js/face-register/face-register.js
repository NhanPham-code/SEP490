document.addEventListener('DOMContentLoaded', async () => {
    // ====== Configuration ======
    const STEPS = [
        { key: 'straight', label: 'Nhìn thẳng', icon: '👁️' },
        { key: 'left', label: 'Quay sang trái', icon: '⬅️' },
        { key: 'right', label: 'Quay sang phải', icon: '➡️' },
        { key: 'up', label: 'Ngẩng đầu lên', icon: '⬆️' },
        { key: 'down', label: 'Cúi đầu xuống', icon: '⬇️' },
    ];

    const THRESHOLDS = {
        // GIẢM xuống 0.40 để bắt mặt nhạy hơn, tránh bị mất tracking khi quay nhanh
        faceConfidence: 0.40,

        maxViolations: 5,
        violationTimeThreshold: 2500,
        maxFaceAbsenceFrames: 30,

        // TỐI ƯU TỐC ĐỘ: Giảm xuống 150ms (gần như tức thì khi đúng tư thế)
        captureHoldTime: 150,

        // TỐI ƯU TỐC ĐỘ: Bỏ qua đếm ngược chuẩn bị, vào chụp luôn
        preparationTime: 0,

        // Tinh chỉnh độ nhạy góc quay
        poseFactor: {
            // thẳng
            straight: 0.15,

            // trái/ phải
            yaw: 0.08,

            // pitchUp: Số âm nhỏ (-0.02) để dễ ngẩng hơn (do cam thường đặt thấp)
            pitchUp: -0.02,

            // pitchDown: Số dương lớn (0.06) để tránh bị nhận diện nhầm là cúi khi đang nhìn thẳng
            pitchDown: 0.1,
        }
    };

    // ====== Elements (Không thay đổi) ======
    const elements = {
        avatarInput: document.getElementById('avatar'),
        avatarPreview: document.getElementById('avatarPreview'),
        removeAvatar: document.getElementById('removeAvatar'),
        videoEl: document.getElementById('preview'),
        faceCanvas: document.getElementById('faceCanvas'),
        faceStatus: document.getElementById('faceStatus'),
        directionGuide: document.getElementById('directionGuide'),
        directionText: document.getElementById('directionText'),
        directionProgress: document.getElementById('directionProgress'),
        violationCounter: document.getElementById('violationCounter'),
        violationCount: document.getElementById('violationCount'),
        overlay: document.getElementById('overlay'),
        overlayText: document.getElementById('overlayText'),
        countdownEl: document.getElementById('countdown'),
        progressBar: document.getElementById('progressBar'),
        progressPercent: document.getElementById('progressPercent'),
        statusIndicator: document.getElementById('statusIndicator'),
        statusText: document.getElementById('statusText'),
        startBtn: document.getElementById('startBtn'),
        resetBtn: document.getElementById('resetBtn'),
        stopBtn: document.getElementById('stopBtn'),
        submitBtn: document.getElementById('submitBtn'),
        stepsList: document.getElementById('stepsList'),
        faceImagePreviewZone: document.getElementById('faceImagePreviewZone'),
    };

    // ====== State ======
    let state = {
        stream: null,
        running: false,
        stepIndex: 0,
        faceApiLoaded: false,
        detectionActive: false,
        lastDetectedFace: null,
        violations: 0,
        faceAbsenceFrames: 0,
        lastViolationTime: 0,
        isPreparing: false,
        capturedImages: [],
        correctPoseStartTime: null,
        isSettingBaseline: false, // Cờ báo đang trong quá trình lấy baseline
        stepStartTime: 0, // Thời gian bắt đầu bước hiện tại
    };

    const faceCtx = elements.faceCanvas.getContext('2d');

    // Phần còn lại của các hàm tiện ích (không thay đổi)
    // ... (Audio, Sleep, SetStatus, etc.)
    const audioContext = new (window.AudioContext || window.webkitAudioContext)();
    function playSound(type) { if (!audioContext || audioContext.state === 'suspended') { audioContext.resume(); } if (!audioContext) return; const oscillator = audioContext.createOscillator(); const gainNode = audioContext.createGain(); oscillator.connect(gainNode); gainNode.connect(audioContext.destination); gainNode.gain.setValueAtTime(0, audioContext.currentTime); gainNode.gain.linearRampToValueAtTime(0.3, audioContext.currentTime + 0.01); if (type === 'success') { oscillator.type = 'sine'; oscillator.frequency.setValueAtTime(523.25, audioContext.currentTime); gainNode.gain.exponentialRampToValueAtTime(0.00001, audioContext.currentTime + 0.5); } else if (type === 'error') { oscillator.type = 'square'; oscillator.frequency.setValueAtTime(220, audioContext.currentTime); gainNode.gain.exponentialRampToValueAtTime(0.00001, audioContext.currentTime + 0.3); } else if (type === 'tick') { oscillator.type = 'sine'; oscillator.frequency.setValueAtTime(440, audioContext.currentTime); gainNode.gain.exponentialRampToValueAtTime(0.00001, audioContext.currentTime + 0.1); } oscillator.start(audioContext.currentTime); oscillator.stop(audioContext.currentTime + 1); }
    const sleep = (ms) => new Promise(resolve => setTimeout(resolve, ms));
    const setStatus = (msg, statusClass = 'status-ready') => { elements.statusIndicator.className = `status-indicator ${statusClass}`; elements.statusText.textContent = msg; };
    const setFaceStatus = (type, message, icon) => { elements.faceStatus.className = `face-status ${type}`; elements.faceStatus.innerHTML = `<i class="${icon}"></i><span>${message}</span>`; };
    const updateProgress = () => { const percentage = Math.min(100, Math.floor((state.stepIndex / STEPS.length) * 100)); elements.progressBar.style.width = `${percentage}%`; elements.progressPercent.textContent = `${percentage}%`; };
    const showToast = (message, type = 'success') => { if (window.showToast) window.showToast(message, type); else console.log(`Toast [${type}]: ${message}`); };
    const setStepClass = () => {
        const stepItems = elements.stepsList.querySelectorAll('.step-item');
        stepItems.forEach((li, idx) => {
            li.classList.remove('step-pending', 'step-active', 'step-completed', 'step-failed');
            const numberDiv = li.querySelector('div:first-child');
            if (idx < state.stepIndex) { li.classList.add('step-completed'); numberDiv.innerHTML = '<i class="ri-check-line"></i>'; numberDiv.className = 'w-8 h-8 rounded-full bg-green-500 text-white flex items-center justify-center font-semibold'; }
            else if (idx === state.stepIndex && state.running) { li.classList.add('step-active'); numberDiv.textContent = idx + 1; numberDiv.className = 'w-8 h-8 rounded-full bg-blue-500 text-white flex items-center justify-center font-semibold animate-pulse'; }
            else { li.classList.add('step-pending'); numberDiv.textContent = idx + 1; numberDiv.className = 'w-8 h-8 rounded-full bg-teal-100 text-teal-600 flex items-center justify-center font-semibold'; }
        });
    };
    async function loadFaceAPI() { try { setStatus('Đang tải AI model...', 'status-loading'); const modelsPath = '/weights'; await Promise.all([faceapi.nets.tinyFaceDetector.loadFromUri(modelsPath), faceapi.nets.faceLandmark68Net.loadFromUri(modelsPath)]); state.faceApiLoaded = true; setStatus('AI model đã sẵn sàng!', 'status-success'); playSound('success'); return true; } catch (error) { console.error('FaceAPI loading error:', error); setStatus('Lỗi tải AI model. Thử lại.', 'status-error'); showToast('Không thể tải model AI. Vui lòng kiểm tra đường dẫn và thử lại.', 'error'); return false; } }
    async function detectFace() { if (!state.faceApiLoaded || !elements.videoEl.videoWidth) return null; try { return await faceapi.detectSingleFace(elements.videoEl, new faceapi.TinyFaceDetectorOptions({ inputSize: 320, scoreThreshold: THRESHOLDS.faceConfidence })).withFaceLandmarks(); } catch { return null; } }
    function drawFaceBox(detection) { const canvas = elements.faceCanvas; canvas.width = elements.videoEl.videoWidth; canvas.height = elements.videoEl.videoHeight; faceCtx.clearRect(0, 0, canvas.width, canvas.height); if (!detection) return; const box = detection.detection.box; const color = '#059669'; faceCtx.strokeStyle = color; faceCtx.lineWidth = 3; faceCtx.shadowColor = color; faceCtx.shadowBlur = 10; faceCtx.strokeRect(box.x, box.y, box.width, box.height); faceCtx.shadowBlur = 0; }
    function resetViolations() { state.violations = 0; state.faceAbsenceFrames = 0; state.lastViolationTime = 0; elements.violationCounter.style.display = 'none'; elements.violationCount.textContent = '0'; }
    function resetAll() { state.running = false; state.isPreparing = false; state.stepIndex = 0; state.capturedImages = []; state.isSettingBaseline = false; resetViolations(); setStepClass(); updateProgress(); elements.overlay.classList.add('opacity-0'); elements.directionGuide.style.display = 'none'; elements.submitBtn.disabled = true; elements.startBtn.disabled = !state.lastDetectedFace; elements.resetBtn.disabled = true; elements.stopBtn.disabled = true; setStatus('Sẵn sàng bắt đầu.', 'status-ready'); elements.faceImagePreviewZone.innerHTML = ''; if (!state.detectionActive) startFaceDetection(); }
    function handleViolation(reason) { const currentTime = Date.now(); if (currentTime - state.lastViolationTime < THRESHOLDS.violationTimeThreshold) return false; state.violations++; state.lastViolationTime = currentTime; elements.violationCount.textContent = state.violations; elements.violationCounter.style.display = 'flex'; setFaceStatus('warning', `Chú ý: ${reason}`, 'ri-error-warning-line'); playSound('error'); if (state.violations >= THRESHOLDS.maxViolations) { forceRestart(`Quá nhiều sai sót. Hãy thử lại nhé!`); return true; } showToast(`Còn ${THRESHOLDS.maxViolations - state.violations} lần thử. Cố lên!`, 'warning'); return false; }
    function forceRestart(reason) { state.running = false; const currentStepItem = elements.stepsList.querySelector(`[data-step="${state.stepIndex}"]`); if (currentStepItem) { currentStepItem.classList.add('step-failed'); } elements.overlay.classList.remove('opacity-0'); elements.overlayText.textContent = reason; elements.countdownEl.textContent = '❌'; showToast('Đừng lo, hãy hít thở sâu và thử lại!', 'warning'); setTimeout(() => { resetAll(); }, 4000); }
    function updateDirectionProgress(progress) { elements.directionProgress.style.strokeDashoffset = 157 - (157 * progress); }
    function stopFaceDetection() { state.detectionActive = false; faceCtx.clearRect(0, 0, elements.faceCanvas.width, elements.faceCanvas.height); elements.directionGuide.style.display = 'none'; }
    async function initializeCamera() { try { setStatus('Đang khởi tạo camera...', 'status-loading'); if (state.stream) state.stream.getTracks().forEach(track => track.stop()); const constraints = { video: { width: { ideal: 640 }, height: { ideal: 480 }, facingMode: 'user' }, audio: false }; state.stream = await navigator.mediaDevices.getUserMedia(constraints); elements.videoEl.srcObject = state.stream; return new Promise((resolve) => { elements.videoEl.onloadedmetadata = async () => { elements.faceCanvas.width = elements.videoEl.videoWidth; elements.faceCanvas.height = elements.videoEl.videoHeight; if (!state.faceApiLoaded) await loadFaceAPI(); startFaceDetection(); setStatus('Sẵn sàng! Hãy đặt khuôn mặt vào khung hình.', 'status-ready'); showToast('Camera đã sẵn sàng!', 'success'); resolve(); }; }); } catch (error) { setStatus(`Lỗi camera: ${error.message}`, 'status-error'); showToast('Không thể truy cập camera. Vui lòng kiểm tra quyền truy cập.', 'error'); throw error; } }
    function captureImageFromVideo() { const canvas = document.createElement('canvas'); canvas.width = elements.videoEl.videoWidth; canvas.height = elements.videoEl.videoHeight; const ctx = canvas.getContext('2d'); ctx.drawImage(elements.videoEl, 0, 0, canvas.width, canvas.height); return canvas.toDataURL('image/png'); }
    function showImagePreviews() { elements.faceImagePreviewZone.innerHTML = ''; state.capturedImages.forEach(imgData => { const imgEl = document.createElement('img'); imgEl.src = imgData; imgEl.className = "w-16 h-16 object-cover rounded-md border-2 border-teal-500 shadow-md"; elements.faceImagePreviewZone.appendChild(imgEl); }); }

    // ====== ALL NEW LOGIC IN THIS SECTION ======

    /**
     * Tính toán độ lệch của khuôn mặt.
     * @param {object} landmarks - Các điểm mốc từ face-api.
     * @returns {object} Trả về độ lệch ngang (yaw) và dọc (pitch) đã được chuẩn hóa.
     */
    function getPose(landmarks) {
        const nose = landmarks.getNose()[3];
        const jaw = landmarks.getJawOutline();
        const faceCenter = {
            x: (jaw[0].x + jaw[16].x) / 2,
            y: (jaw[0].y + jaw[16].y) / 2,
        };
        const faceWidth = jaw[16].x - jaw[0].x;
        const faceHeight = jaw[8].y - (landmarks.getLeftEyeBrow()[2].y + landmarks.getRightEyeBrow()[2].y) / 2;

        const yaw = (nose.x - faceCenter.x) / faceWidth;
        const pitch = (nose.y - faceCenter.y) / faceHeight;

        return { yaw, pitch };
    }

    /**
     * Xác thực hướng quay của khuôn mặt.
     * @param {string} stepKey - Key của bước hiện tại ('straight', 'left', etc.).
     * @param {object} pose - Đối tượng pose trả về từ getPose().
     * @returns {object} Kết quả xác thực { correct: boolean, message: string }.
     */
    function validateDirection(stepKey, pose) {
        const { yaw, pitch } = pose;

        const { straight: straightFactor, yaw: yawFactor, pitchUp, pitchDown } = THRESHOLDS.poseFactor;

        let result = { correct: false, message: 'Giữ nguyên' };

        switch (stepKey) {
            case 'straight':
                // Thường khi nhìn thẳng, người dùng dễ bị lệch Pitch (ngẩng/cúi) hơn là lệch Yaw (trái/phải).
                // Ta cho phép Pitch lệch nhiều hơn một chút so với Yaw.

                const isYawStraight = Math.abs(yaw) < straightFactor; // Kiểm tra trái phải
                const isPitchStraight = Math.abs(pitch) < (straightFactor * 1.5); // Cho phép ngẩng/cúi lệch nhiều hơn gấp rưỡi

                result.correct = isYawStraight && isPitchStraight;

                // Thông báo lỗi chi tiết hơn để người dùng biết sửa
                if (!result.correct) {
                    if (!isYawStraight) result.message = "Nhìn chính diện vào camera";
                    else if (!isPitchStraight) result.message = "Để camera ngang tầm mắt";
                } else {
                    result.message = '✓ Giữ vững';
                }
                break;
            case 'left':
                // Người dùng quay sang TRÁI của họ -> Mũi của họ trên video sẽ di chuyển sang BÊN PHẢI của khung hình
                result.correct = yaw > yawFactor;
                result.message = result.correct ? '✓ Giữ vững' : 'Quay thêm sang trái';
                break;
            case 'right':
                // Người dùng quay sang PHẢI của họ -> Mũi của họ trên video sẽ di chuyển sang BÊN TRÁI của khung hình
                result.correct = yaw < -yawFactor;
                result.message = result.correct ? '✓ Giữ vững' : 'Quay thêm sang phải';
                break;
            case 'up':
                result.correct = pitch < pitchUp;
                result.message = result.correct ? '✓ Giữ vững' : 'Ngẩng thêm lên';
                break;
            case 'down':
                result.correct = pitch > pitchDown;
                result.message = result.correct ? '✓ Giữ vững' : 'Cúi thêm xuống';
                break;
        }
        return result;
    }

    /**
     * Xử lý chính trong vòng lặp nhận diện.
     * @param {object} detection - Kết quả nhận diện từ face-api.
     */
    function handlePoseValidation(detection) {
        if (!detection || !detection.landmarks) return;

        // Nếu đang trong quá trình lấy baseline
        if (state.isSettingBaseline) {
            const validation = validateDirection('straight', getPose(detection.landmarks));
            elements.directionText.innerHTML = `👁️<br>${validation.message}`;
            elements.directionGuide.className = `direction-guide ${validation.correct ? 'correct' : 'incorrect'}`;

            if (validation.correct) {
                if (state.correctPoseStartTime === null) { state.correctPoseStartTime = Date.now(); }
                const timeHeld = Date.now() - state.correctPoseStartTime;
                const progress = Math.min(timeHeld / THRESHOLDS.captureHoldTime, 1);
                updateDirectionProgress(progress);

                if (timeHeld >= THRESHOLDS.captureHoldTime) {
                    // Chụp ảnh "nhìn thẳng" và chuyển sang bước tiếp theo
                    captureStep();
                    state.isSettingBaseline = false; // Kết thúc quá trình lấy baseline
                }
            } else {
                state.correctPoseStartTime = null;
                updateDirectionProgress(0);
            }
            return;
        }

        // Xử lý các bước còn lại
        const currentStep = STEPS[state.stepIndex];
        if (!currentStep) return;

        const validation = validateDirection(currentStep.key, getPose(detection.landmarks));
        elements.directionText.innerHTML = `${currentStep.icon}<br>${validation.message}`;
        elements.directionGuide.className = `direction-guide ${validation.correct ? 'correct' : 'incorrect'}`;

        if (validation.correct) {
            if (state.correctPoseStartTime === null) { state.correctPoseStartTime = Date.now(); }
            const timeHeld = Date.now() - state.correctPoseStartTime;
            const progress = Math.min(timeHeld / THRESHOLDS.captureHoldTime, 1);
            updateDirectionProgress(progress);

            if (timeHeld >= THRESHOLDS.captureHoldTime) {
                captureStep();
            }
        } else {
            state.correctPoseStartTime = null;
            updateDirectionProgress(0);
            // Thêm thời gian chờ 3 giây trước khi báo lỗi tư thế
            if (Date.now() - state.lastViolationTime > 3000 && Date.now() - state.stepStartTime > 3000) {
                handleViolation(`Chưa đúng tư thế`);
            }
        }
    }

    /**
     * Vòng lặp nhận diện chính.
     */
    function startFaceDetection() {
        if (state.detectionActive) return;
        state.detectionActive = true;
        const detectLoop = async () => {
            if (!state.detectionActive) return;
            const detection = await detectFace();
            state.lastDetectedFace = detection;
            drawFaceBox(detection);

            if (detection) {
                state.faceAbsenceFrames = 0;
                const confidence = (detection.detection.score * 100).toFixed(0);
                setFaceStatus('detected', `Nhận diện (${confidence}%)`, 'ri-user-smile-line');
                if (!state.running) elements.startBtn.disabled = false;
                if (state.running && !state.isPreparing) { handlePoseValidation(detection); }
            } else {
                state.faceAbsenceFrames++;
                if (state.running && state.faceAbsenceFrames > THRESHOLDS.maxFaceAbsenceFrames) {
                    if (handleViolation('Khuôn mặt không trong khung hình')) return;
                }
                setFaceStatus('not-detected', 'Khuôn mặt không trong khung hình', 'ri-user-unfollow-line');
                if (!state.running) elements.startBtn.disabled = true;
                state.correctPoseStartTime = null;
                updateDirectionProgress(0);
            }
            requestAnimationFrame(detectLoop);
        };
        detectLoop();
    }

    /**
     * Chụp ảnh và chuyển sang bước tiếp theo.
     */
    async function captureStep() {
        playSound('success');
        const imgData = captureImageFromVideo();
        state.capturedImages.push(imgData);
        showImagePreviews();

        state.stepIndex++;
        updateProgress();
        setStepClass();
        state.correctPoseStartTime = null;
        updateDirectionProgress(0);

        if (state.stepIndex >= STEPS.length) {
            finishCaptureProcess();
        } else {
            const nextStep = STEPS[state.stepIndex];
            state.stepStartTime = Date.now();
            elements.directionText.innerHTML = `${nextStep.icon}<br>${nextStep.label}`;
            showToast(`Tuyệt vời! Tiếp theo: ${nextStep.label}`, 'success');
        }
    }

    function finishCaptureProcess() {
        state.running = false;
        elements.directionGuide.style.display = 'none';
        elements.overlay.classList.remove('opacity-0');
        elements.overlayText.textContent = '✅ Hoàn tất!';
        elements.countdownEl.textContent = '🎉';
        setStatus('Đã chụp đủ 5 ảnh!', 'status-success');
        showToast('Bạn đã hoàn thành xuất sắc!', 'success');
        elements.submitBtn.disabled = false;
        elements.resetBtn.disabled = false;
        elements.stopBtn.disabled = true;
        setTimeout(() => elements.overlay.classList.add('opacity-0'), 2000);
    }

    /**
     * Bắt đầu quy trình chụp ảnh.
     */
    async function runSteps() {
        if (audioContext.state === 'suspended') { audioContext.resume(); }
        resetAll();
        state.running = true;
        state.isPreparing = true; //Đặt isPreparing = true NGAY LẬP TỨC để chặn kiểm tra vi phạm
        setStepClass();
        elements.submitBtn.disabled = true; elements.startBtn.disabled = true; elements.resetBtn.disabled = false; elements.stopBtn.disabled = false;

        elements.overlay.classList.remove('opacity-0');
        elements.overlayText.textContent = '📸 Chuẩn bị...';
        for (let i = THRESHOLDS.preparationTime; i > 0; i--) { elements.countdownEl.textContent = i; playSound('tick'); await sleep(1000); }

        elements.overlay.classList.add('opacity-0');
        state.isPreparing = false; // Kết thúc giai đoạn chuẩn bị cho phép kiểm tra vi phạm
        state.stepStartTime = Date.now();

        // Bắt đầu quá trình lấy baseline
        state.isSettingBaseline = true;
        elements.directionGuide.style.display = 'flex';
        elements.directionText.innerHTML = `👁️<br>Hãy nhìn thẳng để lấy mẫu`;
        setStatus('📸 Đang chụp ảnh...', 'status-recording');
    }

    // ====== Event Listeners & Initialize ======
    elements.avatarInput.addEventListener('change', (e) => { const file = e.target.files?.[0]; if (file) { elements.avatarPreview.src = URL.createObjectURL(file); showToast('Avatar đã được cập nhật!', 'success'); } });
    elements.removeAvatar.addEventListener('click', () => { elements.avatarInput.value = ''; elements.avatarPreview.src = 'https://ui-avatars.com/api/?name=Avatar&background=0891b2&color=ffffff&size=128'; });
    elements.startBtn.addEventListener('click', runSteps);
    elements.resetBtn.addEventListener('click', () => { showToast('Đã reset. Sẵn sàng bắt đầu lại!', 'info'); resetAll(); });
    elements.stopBtn.addEventListener('click', () => { state.running = false; elements.startBtn.disabled = !state.lastDetectedFace; elements.resetBtn.disabled = false; elements.stopBtn.disabled = true; elements.directionGuide.style.display = 'none'; setStatus('Đã dừng. Bạn có thể bắt đầu lại.', 'status-warning'); });

    // === UPDATED SUBMIT LOGIC ===
    elements.submitBtn.addEventListener('click', async (e) => {
        e.preventDefault();
        if (state.capturedImages.length < 5) {
            showToast('Bạn cần chụp đủ 5 ảnh.', 'error');
            return;
        }
        elements.submitBtn.disabled = true;
        setStatus('🚀 Đang gửi dữ liệu...', 'status-loading');

        const formData = new FormData();

        // Thêm avatar nếu có
        if (elements.avatarInput.files[0]) {
            formData.append('avatar', elements.avatarInput.files[0]);
        }

        // Chuyển đổi và thêm 5 ảnh khuôn mặt
        for (let i = 0; i < state.capturedImages.length; i++) {
            const imgBase64 = state.capturedImages[i];
            const response = await fetch(imgBase64);
            const blob = await response.blob();
            // Đặt tên trường khớp với tham số trong C# controller: faceImage1, faceImage2, ...
            const fieldName = `faceImage${i + 1}`;
            const fileName = `faceImage${i + 1}.png`;
            formData.append(fieldName, blob, fileName);
        }

        try {
            const response = await fetch('/Common/CompleteRegistration', {
                method: 'POST',
                body: formData
                // Không cần 'Content-Type', trình duyệt sẽ tự đặt đúng với 'boundary' cho FormData
            });
            const data = await response.json();
            if (response.ok && data.success) {
                showToast('Thành công! Đang chuyển hướng...', 'success');
                setTimeout(() => {
                    window.location.href = data.redirectUrl || '/Home/Index';
                }, 1500);
            } else {
                throw new Error(data.message || 'Có lỗi không xác định xảy ra.');
            }
        } catch (error) {
            setStatus('Lỗi gửi dữ liệu: ' + error.message, 'status-error');
            elements.submitBtn.disabled = false;
            showToast('Gửi thất bại. Hãy thử lại!', 'error');
        }
    });

    (async () => { setStatus('Đang khởi tạo...', 'status-loading'); try { await initializeCamera(); } catch (error) { /* Handled */ } })();
    window.addEventListener('beforeunload', () => { stopFaceDetection(); if (state.stream) state.stream.getTracks().forEach(track => track.stop()); });
});