﻿'use strict';

// Namespace để tránh xung đột
window.FaceCapture = (function () {
    // ====== Configuration ======
    const STEPS = [
        { key: 'straight', label: 'Nhìn thẳng', icon: '<i class="ri-eye-line"></i>' },
        { key: 'left', label: 'Quay sang trái', icon: '<i class="ri-arrow-left-line"></i>' },
        { key: 'right', label: 'Quay sang phải', icon: '<i class="ri-arrow-right-line"></i>' },
        { key: 'up', label: 'Ngẩng đầu lên', icon: '<i class="ri-arrow-up-line"></i>' },
        { key: 'down', label: 'Cúi đầu xuống', icon: '<i class="ri-arrow-down-line"></i>' },
    ];

    const THRESHOLDS = {
        faceConfidence: 0.6,
        maxViolations: 5,
        violationTimeThreshold: 2500,
        maxFaceAbsenceFrames: 30,
        captureHoldTime: 1000, // Giữ 1 giây để chụp
        preparationTime: 3,
        poseFactor: {
            straight: 0.08,
            yaw: 0.12,
            pitch: 0.1,
        }
    };

    // ====== Elements ======
    const elements = {
        modal: document.getElementById('faceCaptureModal'),
        closeBtn: document.getElementById('closeFaceModalBtn'),
        videoEl: document.getElementById('facePreview'),
        faceCanvas: document.getElementById('faceCanvas'),
        faceStatus: document.getElementById('faceStatus'),
        directionGuide: document.getElementById('faceDirectionGuide'),
        directionText: document.getElementById('faceDirectionText'),
        directionProgress: document.getElementById('faceDirectionProgress'),
        violationCounter: document.getElementById('faceViolationCounter'),
        violationCount: document.getElementById('faceViolationCount'),
        overlay: document.getElementById('faceOverlay'),
        overlayText: document.getElementById('faceOverlayText'),
        countdownEl: document.getElementById('faceCountdown'),
        startBtn: document.getElementById('startFaceCaptureBtn'),
        submitBtn: document.getElementById('submitFaceImagesBtn'),
        stepsList: document.getElementById('faceStepsList'),
        imagePreviewContainer: document.getElementById('faceImagePreviewContainer'),
        userIdInput: document.getElementById('userIdInput'),
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
        isInitialized: false,
    };

    const faceCtx = elements.faceCanvas ? elements.faceCanvas.getContext('2d') : null;

    // ***FIXED***: Thêm lại AudioContext và hàm playSound
    const audioContext = new (window.AudioContext || window.webkitAudioContext)();
    function playSound(type) {
        if (!audioContext) return;
        if (audioContext.state === 'suspended') {
            audioContext.resume();
        }
        const oscillator = audioContext.createOscillator();
        const gainNode = audioContext.createGain();
        oscillator.connect(gainNode);
        gainNode.connect(audioContext.destination);
        gainNode.gain.setValueAtTime(0, audioContext.currentTime);
        gainNode.gain.linearRampToValueAtTime(0.3, audioContext.currentTime + 0.01);

        if (type === 'success') {
            oscillator.type = 'sine';
            oscillator.frequency.setValueAtTime(523.25, audioContext.currentTime);
            gainNode.gain.exponentialRampToValueAtTime(0.00001, audioContext.currentTime + 0.5);
        } else if (type === 'error') {
            oscillator.type = 'square';
            oscillator.frequency.setValueAtTime(220, audioContext.currentTime);
            gainNode.gain.exponentialRampToValueAtTime(0.00001, audioContext.currentTime + 0.3);
        } else if (type === 'tick') {
            oscillator.type = 'sine';
            oscillator.frequency.setValueAtTime(440, audioContext.currentTime);
            gainNode.gain.exponentialRampToValueAtTime(0.00001, audioContext.currentTime + 0.1);
        }

        oscillator.start(audioContext.currentTime);
        oscillator.stop(audioContext.currentTime + 1);
    }

    // ====== Utility Functions ======
    const showToast = (message, type = "success") => window.ProfilePage && typeof window.ProfilePage.showToast === 'function' && window.ProfilePage.showToast(message, type);
    const sleep = (ms) => new Promise(resolve => setTimeout(resolve, ms));
    const setFaceStatus = (type, message, iconClass = 'ri-loader-line animate-spin') => {
        if (elements.faceStatus) {
            elements.faceStatus.className = `face-status ${type}`;
            elements.faceStatus.innerHTML = `<i class="${iconClass}"></i><span>${message}</span>`;
        }
    };

    function createStepsList() {
        if (!elements.stepsList) return;
        elements.stepsList.innerHTML = '';
        STEPS.forEach((step, index) => {
            const li = document.createElement('li');
            li.className = 'step-item step-pending';
            li.dataset.step = index;
            li.innerHTML = `
                <div class="step-number">${index + 1}</div>
                <div class="step-label">${step.icon} ${step.label}</div>
            `;
            elements.stepsList.appendChild(li);
        });
    }

    function setStepClass() {
        if (!elements.stepsList) return;
        const stepItems = elements.stepsList.querySelectorAll('.step-item');
        stepItems.forEach((li, idx) => {
            li.classList.remove('step-pending', 'step-active', 'step-completed', 'step-failed');
            const numberDiv = li.querySelector('.step-number');
            if (idx < state.stepIndex) {
                li.classList.add('step-completed');
                numberDiv.innerHTML = '<i class="ri-check-line"></i>';
            } else if (idx === state.stepIndex && state.running) {
                li.classList.add('step-active');
                numberDiv.textContent = idx + 1;
            } else {
                li.classList.add('step-pending');
                numberDiv.textContent = idx + 1;
            }
        });
    }

    async function loadFaceAPI() {
        if (state.faceApiLoaded) return true;
        try {
            setFaceStatus('loading', 'Đang tải AI model...');
            const modelsPath = '/weights';
            await Promise.all([
                faceapi.nets.tinyFaceDetector.loadFromUri(modelsPath),
                faceapi.nets.faceLandmark68Net.loadFromUri(modelsPath)
            ]);
            state.faceApiLoaded = true;
            setFaceStatus('ready', 'AI model đã sẵn sàng!', 'ri-robot-2-line');
            return true;
        } catch (error) {
            console.error('FaceAPI loading error:', error);
            setFaceStatus('error', 'Lỗi tải AI model.', 'ri-error-warning-line');
            showToast('Không thể tải model AI. Vui lòng kiểm tra đường dẫn và thử lại.', 'error');
            return false;
        }
    }

    async function initializeCamera() {
        try {
            setFaceStatus('loading', 'Đang khởi tạo camera...');
            if (state.stream) {
                state.stream.getTracks().forEach(track => track.stop());
            }
            const constraints = { video: { width: { ideal: 640 }, height: { ideal: 480 }, facingMode: 'user' }, audio: false };
            state.stream = await navigator.mediaDevices.getUserMedia(constraints);
            elements.videoEl.srcObject = state.stream;
            return new Promise((resolve) => {
                elements.videoEl.onloadedmetadata = async () => {
                    elements.faceCanvas.width = elements.videoEl.videoWidth;
                    elements.faceCanvas.height = elements.videoEl.videoHeight;
                    if (!state.faceApiLoaded) {
                        await loadFaceAPI();
                    }
                    startFaceDetection();
                    setFaceStatus('ready', 'Sẵn sàng!', 'ri-camera-line');
                    resolve();
                };
            });
        } catch (error) {
            setFaceStatus('error', `Lỗi camera: ${error.message}`, 'ri-error-warning-line');
            showToast('Không thể truy cập camera. Vui lòng cấp quyền và thử lại.', 'error');
            throw error;
        }
    }

    function getPose(landmarks) {
        const nose = landmarks.getNose()[3];
        const jaw = landmarks.getJawOutline();
        const faceCenter = { x: (jaw[0].x + jaw[16].x) / 2, y: (jaw[0].y + jaw[16].y) / 2 };
        const faceWidth = jaw[16].x - jaw[0].x;
        const faceHeight = jaw[8].y - (landmarks.getLeftEyeBrow()[2].y + landmarks.getRightEyeBrow()[2].y) / 2;
        const yaw = (nose.x - faceCenter.x) / faceWidth;
        const pitch = (nose.y - faceCenter.y) / faceHeight;
        return { yaw, pitch };
    }

    function validateDirection(stepKey, pose) {
        const { yaw, pitch } = pose;
        const { straight: straightFactor, yaw: yawFactor, pitch: pitchFactor } = THRESHOLDS.poseFactor;
        let result = { correct: false, message: 'Giữ nguyên' };
        switch (stepKey) {
            case 'straight':
                result.correct = Math.abs(yaw) < straightFactor && Math.abs(pitch) < straightFactor;
                result.message = result.correct ? '✓ Giữ vững' : 'Nhìn thẳng vào';
                break;
            case 'left':
                result.correct = yaw > yawFactor;
                result.message = result.correct ? '✓ Giữ vững' : 'Quay thêm sang trái';
                break;
            case 'right':
                result.correct = yaw < -yawFactor;
                result.message = result.correct ? '✓ Giữ vững' : 'Quay thêm sang phải';
                break;
            case 'up':
                result.correct = pitch < -pitchFactor;
                result.message = result.correct ? '✓ Giữ vững' : 'Ngẩng thêm lên';
                break;
            case 'down':
                result.correct = pitch > pitchFactor;
                result.message = result.correct ? '✓ Giữ vững' : 'Cúi thêm xuống';
                break;
        }
        return result;
    }

    function updateDirectionProgress(progress) {
        if (elements.directionProgress) {
            elements.directionProgress.style.strokeDashoffset = 157 - (157 * progress);
        }
    }

    function handleViolation(reason) {
        const currentTime = Date.now();
        if (currentTime - state.lastViolationTime < THRESHOLDS.violationTimeThreshold) return false;
        state.violations++;
        state.lastViolationTime = currentTime;
        elements.violationCount.textContent = state.violations;
        elements.violationCounter.style.display = 'flex';
        playSound('error');
        if (state.violations >= THRESHOLDS.maxViolations) {
            forceRestart(`Quá nhiều sai sót. Quá trình sẽ tự hủy!`);
            return true;
        }
        showToast(`Vi phạm: ${reason}. Còn ${THRESHOLDS.maxViolations - state.violations} lần thử.`, 'warning');
        return false;
    }

    function forceRestart(reason) {
        state.running = false;
        showToast(reason, 'error');
        setTimeout(() => {
            resetAll();
            if (window.ProfilePage && typeof window.ProfilePage.closeModal === 'function') {
                window.ProfilePage.closeModal('faceCaptureModal');
            }
        }, 3000);
    }

    function handlePoseValidation(detection) {
        if (!detection || !detection.landmarks) return;
        const currentStepKey = STEPS[state.stepIndex]?.key;
        if (!currentStepKey) return;

        const pose = getPose(detection.landmarks);
        const validation = validateDirection(currentStepKey, pose);
        const currentStep = STEPS[state.stepIndex];

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
            if (state.running && Date.now() - state.lastViolationTime > 3000 && Date.now() - state.stepStartTime > 3000) {
                if (handleViolation(`Chưa đúng tư thế`)) return;
            }
        }
    }

    function startFaceDetection() {
        if (state.detectionActive) return;
        state.detectionActive = true;
        const detectLoop = async () => {
            if (!state.detectionActive || !elements.videoEl.srcObject) return;
            const detection = await faceapi.detectSingleFace(elements.videoEl, new faceapi.TinyFaceDetectorOptions({ inputSize: 224, scoreThreshold: THRESHOLDS.faceConfidence })).withFaceLandmarks();
            state.lastDetectedFace = detection;

            if (faceCtx) {
                faceCtx.clearRect(0, 0, elements.faceCanvas.width, elements.faceCanvas.height);
                if (detection) {
                    const box = detection.detection.box;
                    faceCtx.strokeStyle = '#059669';
                    faceCtx.lineWidth = 2;
                    faceCtx.strokeRect(box.x, box.y, box.width, box.height);
                }
            }

            if (detection) {
                state.faceAbsenceFrames = 0;
                setFaceStatus('detected', 'Đã nhận diện', 'ri-user-smile-line');
                if (!state.running) elements.startBtn.disabled = false;
                if (state.running && !state.isPreparing) { handlePoseValidation(detection); }
            } else {
                state.faceAbsenceFrames++;
                if (state.running && state.faceAbsenceFrames > THRESHOLDS.maxFaceAbsenceFrames) {
                    if (handleViolation('Khuôn mặt không trong khung hình')) return;
                }
                setFaceStatus('not-detected', 'Không tìm thấy khuôn mặt', 'ri-user-unfollow-line');
                if (!state.running) elements.startBtn.disabled = true;
                state.correctPoseStartTime = null;
                updateDirectionProgress(0);
            }
            requestAnimationFrame(detectLoop);
        };
        detectLoop();
    }

    function captureImageFromVideo() {
        const canvas = document.createElement('canvas');
        canvas.width = elements.videoEl.videoWidth;
        canvas.height = elements.videoEl.videoHeight;
        const ctx = canvas.getContext('2d');
        ctx.drawImage(elements.videoEl, 0, 0, canvas.width, canvas.height);
        return canvas.toDataURL('image/png');
    }

    function showImagePreviews() {
        elements.imagePreviewContainer.innerHTML = '';
        state.capturedImages.forEach(imgData => {
            const imgEl = document.createElement('img');
            imgEl.src = imgData;
            imgEl.className = "w-16 h-16 object-cover rounded-md border-2 border-green-500 shadow-md";
            elements.imagePreviewContainer.appendChild(imgEl);
        });
    }

    // ***FIXED***: Sửa lỗi chụp lặp 2 lần và thêm âm thanh
    async function captureStep() {
        playSound('success');
        const imgData = captureImageFromVideo();
        state.capturedImages.push(imgData);
        showImagePreviews();

        state.stepIndex++;
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
        showToast('Bạn đã hoàn thành xuất sắc!', 'success');
        elements.submitBtn.classList.remove('hidden');
        elements.startBtn.classList.add('hidden');
        setTimeout(() => elements.overlay.classList.add('opacity-0'), 2000);
    }

    function resetViolations() {
        state.violations = 0;
        state.faceAbsenceFrames = 0;
        state.lastViolationTime = 0;
        if (elements.violationCounter) {
            elements.violationCounter.style.display = 'none';
            elements.violationCount.textContent = '0';
        }
    }

    function resetAll() {
        state.running = false;
        state.isPreparing = false;
        state.stepIndex = 0;
        state.capturedImages = [];
        resetViolations();
        createStepsList();
        setStepClass();
        if (elements.imagePreviewContainer) elements.imagePreviewContainer.innerHTML = '';
        if (elements.overlay) elements.overlay.classList.add('opacity-0');
        if (elements.directionGuide) elements.directionGuide.style.display = 'none';
        if (elements.submitBtn) elements.submitBtn.classList.add('hidden');
        if (elements.startBtn) {
            elements.startBtn.classList.remove('hidden');
            elements.startBtn.disabled = !state.lastDetectedFace;
        }
        if (state.detectionActive) {
            setFaceStatus('ready', 'Sẵn sàng!', 'ri-camera-line');
        } else {
            setFaceStatus('loading', 'Đang khởi động...', 'ri-loader-line');
        }
    }

    // ***FIXED***: Thêm âm thanh đếm ngược
    async function runSteps() {
        resetAll();
        state.running = true;
        state.isPreparing = true;
        setStepClass();
        elements.startBtn.disabled = true;

        elements.overlay.classList.remove('opacity-0');
        elements.overlayText.textContent = '📸 Chuẩn bị...';
        for (let i = THRESHOLDS.preparationTime; i > 0; i--) {
            elements.countdownEl.textContent = i;
            playSound('tick');
            await sleep(1000);
        }

        elements.overlay.classList.add('opacity-0');
        state.isPreparing = false;
        state.stepStartTime = Date.now();

        elements.directionGuide.style.display = 'flex';
        const firstStep = STEPS[0];
        elements.directionText.innerHTML = `${firstStep.icon}<br>${firstStep.label}`;
        setFaceStatus('recording', 'Đang chụp ảnh...', 'ri-camera-lens-line');
    }

    async function start() {
        if (!state.isInitialized) {
            state.isInitialized = true;
            elements.startBtn.addEventListener('click', runSteps);
            elements.closeBtn.addEventListener('click', () => {
                if (window.ProfilePage && typeof window.ProfilePage.closeModal === 'function') {
                    window.ProfilePage.closeModal('faceCaptureModal');
                }
            });
            elements.submitBtn.addEventListener('click', submitFaceData);
        }
        resetAll();
        try {
            await initializeCamera();
        } catch (error) {
            // Lỗi đã được xử lý trong initializeCamera
        }
    }

    function stop() {
        state.detectionActive = false;
        if (state.stream) {
            state.stream.getTracks().forEach(track => track.stop());
            state.stream = null;
        }
        if (elements.videoEl) elements.videoEl.srcObject = null;
        if (faceCtx) {
            faceCtx.clearRect(0, 0, elements.faceCanvas.width, elements.faceCanvas.height);
        }
        setFaceStatus('stopped', 'Đã tạm dừng', 'ri-pause-circle-line');
    }

    async function submitFaceData(e) {
        e.preventDefault();
        if (state.capturedImages.length < STEPS.length) {
            showToast(`Bạn cần chụp đủ ${STEPS.length} ảnh.`, 'error');
            return;
        }

        const loadingToast = showToast("Đang gửi dữ liệu...", "loading");
        elements.submitBtn.disabled = true;

        const formData = new FormData();
        const userId = elements.userIdInput ? elements.userIdInput.value : null;
        if (!userId) {
            if (window.ProfilePage && typeof window.ProfilePage.removeLoadingToast === 'function') {
                window.ProfilePage.removeLoadingToast(loadingToast);
            }
            showToast('Lỗi: Không tìm thấy ID người dùng.', 'error');
            elements.submitBtn.disabled = false;
            return;
        }
        formData.append('UserId', userId);

        for (let i = 0; i < state.capturedImages.length; i++) {
            const imgBase64 = state.capturedImages[i];
            const response = await fetch(imgBase64);
            const blob = await response.blob();
            const fieldName = `FaceImages`;
            const fileName = `faceImage${i + 1}.png`;
            formData.append(fieldName, blob, fileName);
        }

        $.ajax({
            url: '/Common/AddOrUpdateFaceEmbeddings',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            timeout: 60000,
            success: function (response) {
                if (window.ProfilePage && typeof window.ProfilePage.removeLoadingToast === 'function') {
                    window.ProfilePage.removeLoadingToast(loadingToast);
                }
                showToast(response.message || "Cập nhật khuôn mặt thành công!", "success");
                setTimeout(() => {
                    if (window.ProfilePage && typeof window.ProfilePage.closeModal === 'function') {
                        window.ProfilePage.closeModal('faceCaptureModal');
                    }
                }, 1500);
            },
            error: function (xhr) {
                if (window.ProfilePage && typeof window.ProfilePage.removeLoadingToast === 'function') {
                    window.ProfilePage.removeLoadingToast(loadingToast);
                }
                const res = xhr.responseJSON;
                const errorMessage = res && res.message ? res.message : 'Có lỗi xảy ra, vui lòng thử lại!';
                showToast(errorMessage, "error");
            },
            complete: function () {
                elements.submitBtn.disabled = false;
            }
        });
    }

    return {
        start: start,
        stop: stop,
    };
})();