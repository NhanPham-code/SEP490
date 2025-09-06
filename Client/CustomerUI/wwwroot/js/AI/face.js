document.addEventListener('DOMContentLoaded', async () => {
    // ====== Configuration ======
    const STEPS = [
        { key: 'straight', label: 'Nhìn thẳng vào camera', seconds: 3, icon: '👁️', description: 'Giữ đầu thẳng và nhìn vào camera' },
        { key: 'left', label: 'Quay mặt sang trái', seconds: 3, icon: '⬅️', description: 'Từ từ quay đầu sang bên trái' },
        { key: 'right', label: 'Quay mặt sang phải', seconds: 3, icon: '➡️', description: 'Từ từ quay đầu sang bên phải' },
        { key: 'up', label: 'Ngẩng cao đầu', seconds: 3, icon: '⬆️', description: 'Nhẹ nhàng ngẩng đầu lên trên' },
        { key: 'down', label: 'Cúi đầu xuống', seconds: 3, icon: '⬇️', description: 'Nhẹ nhàng cúi đầu xuống dưới' },
    ];

    const THRESHOLDS = {
        faceConfidence: 0.3,
        dx: 25,
        dy: 20,
        yawThreshold: 15,
        pitchThreshold: 12,
        maxViolations: 5, // Tăng số lần vi phạm được phép
        violationTimeThreshold: 2000, // Tăng thời gian grace period
        maxFaceAbsenceFrames: 45, // Tăng thời gian cho phép mặt biến mất
        movementThreshold: 15,
        preparationTime: 2 // Thời gian chuẩn bị trước mỗi bước
    };

    // ====== Elements ======
    const elements = {
        avatarInput: document.getElementById('avatar'),
        avatarPreview: document.getElementById('avatarPreview'),
        removeAvatar: document.getElementById('removeAvatar'),
        videoEl: document.getElementById('preview'),
        faceCanvas: document.getElementById('faceCanvas'),
        faceStatus: document.getElementById('faceStatus'),
        directionGuide: document.getElementById('directionGuide'),
        directionText: document.getElementById('directionText'),
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
        finalWrap: document.getElementById('finalWrap'),
        finalVideo: document.getElementById('finalVideo'),
        submitBtn: document.getElementById('submitBtn'),
        stepsList: document.getElementById('stepsList')
    };

    // ====== State ======
    let state = {
        stream: null,
        mediaRecorder: null,
        recordedBlobs: [],
        running: false,
        stepIndex: 0,
        baseline: null,
        faceApiLoaded: false,
        detectionActive: false,
        lastDetectedFace: null,
        detectionMode: 'faceapi',
        violations: 0,
        faceAbsenceFrames: 0,
        lastViolationTime: 0,
        currentStepStartTime: 0,
        strictMode: false,
        isPreparing: false,
        isCountingDown: false,
        userReady: false,
        lastValidationMessage: '',
        encouragementShown: false,
        stepAttempts: 0,
        totalStepTime: 0
    };

    // Canvas contexts
    const canvas = document.createElement('canvas');
    const ctx = canvas.getContext('2d');
    const faceCtx = elements.faceCanvas.getContext('2d');

    // ====== Audio Feedback ======
    const audioFeedback = {
        success: () => {
            const audio = new Audio('data:audio/wav;base64,UklGRnoGAABXQVZFZm10IBAAAAABAAEAQB8AAEAfAAABAAgAZGF0YQoGAACBhYqFbF1fdJivrJBhNjVgodDbq2EcBj+a2/LDciUFLIHO8tiJNwgZaLvt559NEAxQp+PwtmMcBjiR1/LMeSwFJHfH8N2QQAoUXrTp66hVFApGn+D0u2ogCEB+y/Heli');
            audio.volume = 0.3;
            audio.play().catch(() => { });
        },
        error: () => {
            const audio = new Audio('data:audio/wav;base64,UklGRnoGAABXQVZFZm10IBAAAAABAAEAQB8AAEAfAAABAAgAZGF0YQoGAACBhYqFbF1fdJivrJBhNjVgodDbq2EcBj+a2/LDciUFLIHO8tiJNwgZaLvt559NEAxQp+PwtmMcBjiR1/LMeSzw');
            audio.volume = 0.2;
            audio.play().catch(() => { });
        },
        tick: () => {
            const audio = new Audio('data:audio/wav;base64,UklGRnoGAABXQVZFZm10IBAAAAABAAEAQB8AAEAfAAABAAgAZGF0YQoGAACBhYqFbF1fdJivrJBhNjVgodDbq2EcBj+a2/LDciUFLIHO8tiJNwgZaLvt559NEAxQp+PwtmMcBjiR1/LMeSw');
            audio.volume = 0.1;
            audio.play().catch(() => { });
        }
    };

    // ====== Utility Functions ======
    const sleep = (ms) => new Promise(resolve => setTimeout(resolve, ms));

    const setStatus = (msg, statusClass = 'status-ready') => {
        elements.statusIndicator.className = `status-indicator ${statusClass}`;
        elements.statusText.textContent = msg;
        console.log('Status:', msg);
    };

    const setFaceStatus = (type, message, icon) => {
        elements.faceStatus.className = `face-status ${type}`;
        elements.faceStatus.innerHTML = `<i class="${icon}"></i><span>${message}</span>`;
    };

    const updateProgress = (current, total) => {
        const percentage = Math.min(100, Math.floor((current / total) * 100));
        elements.progressBar.style.width = `${percentage}%`;
        elements.progressPercent.textContent = `${percentage}%`;
    };

    const showEncouragement = (message, type = 'info') => {
        if (state.encouragementShown) return;
        state.encouragementShown = true;

        const toast = document.createElement('div');
        toast.className = `fixed top-4 right-4 p-4 rounded-lg shadow-lg z-50 transition-all duration-500 ${type === 'success' ? 'bg-green-500 text-white' :
                type === 'warning' ? 'bg-yellow-500 text-white' :
                    'bg-blue-500 text-white'
            }`;
        toast.textContent = message;
        document.body.appendChild(toast);

        setTimeout(() => {
            toast.style.transform = 'translateX(100%)';
            setTimeout(() => document.body.removeChild(toast), 500);
            state.encouragementShown = false;
        }, 3000);
    };

    const setStepClass = () => {
        const stepItems = elements.stepsList.querySelectorAll('.step-item');
        stepItems.forEach((li, idx) => {
            li.classList.remove('step-pending', 'step-active', 'step-completed', 'step-failed', 'step-preparing');
            const numberDiv = li.querySelector('div');

            if (idx < state.stepIndex) {
                li.classList.add('step-completed');
                numberDiv.className = 'w-8 h-8 rounded-full bg-green-500 text-white flex items-center justify-center font-semibold animate-pulse';
            } else if (idx === state.stepIndex && state.running) {
                if (state.isPreparing) {
                    li.classList.add('step-preparing');
                    numberDiv.className = 'w-8 h-8 rounded-full bg-yellow-500 text-white flex items-center justify-center font-semibold animate-bounce';
                } else {
                    li.classList.add('step-active');
                    numberDiv.className = 'w-8 h-8 rounded-full bg-blue-500 text-white flex items-center justify-center font-semibold';
                }
            } else {
                li.classList.add('step-pending');
                numberDiv.className = 'w-8 h-8 rounded-full bg-teal-100 text-teal-600 flex items-center justify-center font-semibold';
            }
        });
    };

    // ====== Face API Loading với Progress ======
    async function loadFaceAPI() {
        try {
            setStatus('Đang tải AI model...', 'status-loading');
            const modelsPath = '/weights';
            console.log('Bắt đầu tải AI model từ', modelsPath);

            // Hiển thị progress loading
            let loadProgress = 0;
            const progressInterval = setInterval(() => {
                loadProgress += 10;
                setStatus(`Đang tải AI model... ${loadProgress}%`, 'status-loading');
            }, 200);

            await Promise.race([
                Promise.all([
                    faceapi.nets.tinyFaceDetector.loadFromUri(modelsPath),
                    faceapi.nets.faceLandmark68Net.loadFromUri(modelsPath)
                ]),
                new Promise((_, reject) =>
                    setTimeout(() => reject(new Error('Timeout tải model sau 15 giây')), 15000)
                )
            ]);

            clearInterval(progressInterval);
            state.faceApiLoaded = true;
            console.log('AI model đã sẵn sàng!');
            setStatus('AI model đã sẵn sàng!', 'status-success');
            audioFeedback.success();
            return true;
        } catch (error) {
            console.error('Lỗi khi tải face-api.js models:', error);
            state.detectionMode = 'simple';
            setFaceStatus('fallback', 'Sử dụng chế độ cơ bản', 'ri-camera-line');
            showEncouragement('Đang sử dụng chế độ phát hiện cơ bản', 'warning');
            return false;
        }
    }

    // ====== Enhanced Face Detection ======
    async function detectFaceAdvanced() {
        if (!state.faceApiLoaded || !elements.videoEl.videoWidth || !elements.videoEl.videoHeight) {
            return null;
        }

        try {
            const detection = await faceapi
                .detectSingleFace(elements.videoEl, new faceapi.TinyFaceDetectorOptions({
                    inputSize: 224,
                    scoreThreshold: THRESHOLDS.faceConfidence
                }))
                .withFaceLandmarks();

            if (detection) {
                const landmarks = detection.landmarks;
                const nose = landmarks.getNose();
                const leftEye = landmarks.getLeftEye();
                const rightEye = landmarks.getRightEye();

                const eyeCenter = {
                    x: (leftEye[0].x + rightEye[0].x) / 2,
                    y: (leftEye[0].y + rightEye[0].y) / 2
                };

                const noseCenter = {
                    x: nose[3].x,
                    y: nose[3].y
                };

                const yaw = -Math.atan2(noseCenter.x - eyeCenter.x, 30) * 180 / Math.PI;
                const pitch = Math.atan2(eyeCenter.y - noseCenter.y, 30) * 180 / Math.PI;

                return {
                    ...detection,
                    headPose: { yaw, pitch },
                    quality: 'advanced'
                };
            }

            return null;
        } catch (error) {
            console.warn('Advanced face detection error:', error);
            return null;
        }
    }

    function detectFaceSimple() {
        try {
            if (!elements.videoEl.videoWidth || !elements.videoEl.videoHeight) return null;

            const w = elements.videoEl.videoWidth;
            const h = elements.videoEl.videoHeight;
            canvas.width = w;
            canvas.height = h;
            ctx.drawImage(elements.videoEl, 0, 0, w, h);

            const imageData = ctx.getImageData(0, 0, w, h);
            const data = imageData.data;

            let facePixels = 0;
            let totalBrightness = 0;
            const centerX = w / 2;
            const centerY = h / 2;
            const faceRegionSize = Math.min(w, h) * 0.3;

            for (let y = centerY - faceRegionSize / 2; y < centerY + faceRegionSize / 2; y += 4) {
                for (let x = centerX - faceRegionSize / 2; x < centerX + faceRegionSize / 2; x += 4) {
                    if (x >= 0 && x < w && y >= 0 && y < h) {
                        const i = (Math.floor(y) * w + Math.floor(x)) * 4;
                        const r = data[i];
                        const g = data[i + 1];
                        const b = data[i + 2];

                        if (r > 95 && g > 40 && b > 20 && r > g && r > b) {
                            facePixels++;
                        }

                        totalBrightness += (r + g + b) / 3;
                    }
                }
            }

            const avgBrightness = totalBrightness / (faceRegionSize * faceRegionSize / 16);
            const faceRatio = facePixels / (faceRegionSize * faceRegionSize / 16);

            if (faceRatio > 0.1 && avgBrightness > 30 && avgBrightness < 220) {
                return {
                    detection: {
                        box: {
                            x: centerX - faceRegionSize / 2,
                            y: centerY - faceRegionSize / 2,
                            width: faceRegionSize,
                            height: faceRegionSize
                        },
                        score: Math.min(0.9, faceRatio * 2)
                    },
                    quality: 'simple'
                };
            }

            return null;
        } catch (error) {
            console.warn('Simple face detection error:', error);
            return null;
        }
    }

    async function detectFace() {
        if (state.detectionMode === 'faceapi' && state.faceApiLoaded) {
            return await detectFaceAdvanced();
        } else {
            return detectFaceSimple();
        }
    }

    function drawFaceBox(detection) {
        if (!detection) return;

        const canvas = elements.faceCanvas;
        const ctx = faceCtx;

        ctx.clearRect(0, 0, canvas.width, canvas.height);
        canvas.width = elements.videoEl.videoWidth;
        canvas.height = elements.videoEl.videoHeight;

        const box = detection.detection.box;
        const color = detection.quality === 'advanced' ? '#059669' : '#0891b2';

        // Vẽ khung mượt mà hơn
        ctx.strokeStyle = color;
        ctx.lineWidth = 3;
        ctx.shadowColor = color;
        ctx.shadowBlur = 10;
        ctx.strokeRect(box.x, box.y, box.width, box.height);

        // Vẽ các góc để tạo cảm giác hiện đại
        const cornerLength = 20;
        ctx.lineWidth = 4;

        // Góc trên trái
        ctx.beginPath();
        ctx.moveTo(box.x, box.y + cornerLength);
        ctx.lineTo(box.x, box.y);
        ctx.lineTo(box.x + cornerLength, box.y);
        ctx.stroke();

        // Góc trên phải
        ctx.beginPath();
        ctx.moveTo(box.x + box.width - cornerLength, box.y);
        ctx.lineTo(box.x + box.width, box.y);
        ctx.lineTo(box.x + box.width, box.y + cornerLength);
        ctx.stroke();

        // Góc dưới trái
        ctx.beginPath();
        ctx.moveTo(box.x, box.y + box.height - cornerLength);
        ctx.lineTo(box.x, box.y + box.height);
        ctx.lineTo(box.x + cornerLength, box.y + box.height);
        ctx.stroke();

        // Góc dưới phải
        ctx.beginPath();
        ctx.moveTo(box.x + box.width - cornerLength, box.y + box.height);
        ctx.lineTo(box.x + box.width, box.y + box.height);
        ctx.lineTo(box.x + box.width, box.y + box.height - cornerLength);
        ctx.stroke();

        ctx.shadowBlur = 0;

        if (detection.landmarks) {
            const landmarks = detection.landmarks.positions;
            ctx.fillStyle = color;

            landmarks.forEach(point => {
                ctx.beginPath();
                ctx.arc(point.x, point.y, 1, 0, 2 * Math.PI);
                ctx.fill();
            });
        }
    }

    // ====== Enhanced Direction Validation ======
    function validateDirection(stepKey, detection, baseline) {
        if (!detection || !baseline) return { correct: false, message: 'Không phát hiện khuôn mặt', confidence: 0 };

        const currentFace = {
            x: detection.detection.box.x + detection.detection.box.width / 2,
            y: detection.detection.box.y + detection.detection.box.height / 2
        };
        const dx = currentFace.x - baseline.x;
        const dy = currentFace.y - baseline.y;

        const yaw = detection.headPose?.yaw ?? 0;
        const pitch = detection.headPose?.pitch ?? 0;
        const threshold = THRESHOLDS.movementThreshold;

        let result = { correct: false, message: '', confidence: 0 };

        switch (stepKey) {
            case 'straight':
                const straightScore = Math.max(0, 100 - Math.abs(dx) - Math.abs(dy) - Math.abs(yaw) * 2);
                const isStraight = Math.abs(dx) < threshold && Math.abs(dy) < threshold && Math.abs(yaw) < (THRESHOLDS.yawThreshold / 2);
                result = {
                    correct: isStraight,
                    message: isStraight ? '✓ Hoàn hảo! Giữ vững' : 'Điều chỉnh để nhìn thẳng',
                    confidence: straightScore
                };
                break;
            case 'left':
                if (detection.headPose) {
                    const leftScore = Math.max(0, 100 + yaw * 3);
                    const isLeft = yaw < -THRESHOLDS.yawThreshold;
                    result = {
                        correct: isLeft,
                        message: isLeft ? '✓ Tuyệt vời! Giữ vững' : `Quay thêm sang trái (${Math.abs(yaw).toFixed(0)}°)`,
                        confidence: leftScore
                    };
                } else {
                    const leftScore = Math.max(0, 100 + dx);
                    const isLeft = dx <= -THRESHOLDS.dx;
                    result = {
                        correct: isLeft,
                        message: isLeft ? '✓ Tuyệt vời! Giữ vững' : 'Quay thêm sang trái',
                        confidence: leftScore
                    };
                }
                break;
            case 'right':
                if (detection.headPose) {
                    const rightScore = Math.max(0, 100 + yaw * 3);
                    const isRight = yaw > THRESHOLDS.yawThreshold;
                    result = {
                        correct: isRight,
                        message: isRight ? '✓ Tuyệt vời! Giữ vững' : `Quay thêm sang phải (${Math.abs(yaw).toFixed(0)}°)`,
                        confidence: rightScore
                    };
                } else {
                    const rightScore = Math.max(0, 100 - dx);
                    const isRight = dx >= THRESHOLDS.dx;
                    result = {
                        correct: isRight,
                        message: isRight ? '✓ Tuyệt vời! Giữ vững' : 'Quay thêm sang phải',
                        confidence: rightScore
                    };
                }
                break;
            case 'up':
                if (detection.headPose) {
                    const upScore = Math.max(0, 100 - pitch * 3);
                    const isUp = pitch < -THRESHOLDS.pitchThreshold;
                    result = {
                        correct: isUp,
                        message: isUp ? '✓ Tuyệt vời! Giữ vững' : `Ngẩng thêm lên (${Math.abs(pitch).toFixed(0)}°)`,
                        confidence: upScore
                    };
                } else {
                    const upScore = Math.max(0, 100 + dy);
                    const isUp = dy <= -THRESHOLDS.dy;
                    result = {
                        correct: isUp,
                        message: isUp ? '✓ Tuyệt vời! Giữ vững' : 'Ngẩng thêm lên',
                        confidence: upScore
                    };
                }
                break;
            case 'down':
                if (detection.headPose) {
                    const downScore = Math.max(0, 100 + pitch * 3);
                    const isDown = pitch > THRESHOLDS.pitchThreshold;
                    result = {
                        correct: isDown,
                        message: isDown ? '✓ Tuyệt vời! Giữ vững' : `Cúi thêm xuống (${Math.abs(pitch).toFixed(0)}°)`,
                        confidence: downScore
                    };
                } else {
                    const downScore = Math.max(0, 100 - dy);
                    const isDown = dy >= THRESHOLDS.dy;
                    result = {
                        correct: isDown,
                        message: isDown ? '✓ Tuyệt vời! Giữ vững' : 'Cúi thêm xuống',
                        confidence: downScore
                    };
                }
                break;
        }

        return result;
    }

    // ====== Enhanced Violation Handling ======
    function handleViolation(reason) {
        const currentTime = Date.now();
        if (currentTime - state.lastViolationTime < THRESHOLDS.violationTimeThreshold) {
            return false;
        }

        state.violations++;
        state.lastViolationTime = currentTime;
        console.log(`Vi phạm ${state.violations}/${THRESHOLDS.maxViolations}: ${reason}`);

        elements.violationCount.textContent = state.violations;
        elements.violationCounter.style.display = 'block';

        // Hiển thị cảnh báo nhẹ nhàng hơn
        setFaceStatus('warning', `Chú ý: ${reason}`, 'ri-error-warning-line');
        audioFeedback.error();

        if (state.violations >= THRESHOLDS.maxViolations) {
            forceRestart(`Quá nhiều sai sót. Hãy thử lại nhé!`);
            return true;
        } else {
            // Khuyến khích người dùng
            const remainingAttempts = THRESHOLDS.maxViolations - state.violations;
            showEncouragement(`Còn ${remainingAttempts} lần thử. Bạn làm được!`, 'warning');
        }
        return false;
    }

    function forceRestart(reason) {
        console.log('Force restart:', reason);
        state.running = false;

        if (state.mediaRecorder && state.mediaRecorder.state === 'recording') {
            state.mediaRecorder.stop();
        }

        const currentStepItem = elements.stepsList.querySelector(`[data-step="${state.stepIndex}"]`);
        if (currentStepItem) {
            currentStepItem.classList.remove('step-active', 'step-pending');
            currentStepItem.classList.add('step-failed');
            const numberDiv = currentStepItem.querySelector('div');
            numberDiv.className = 'w-8 h-8 rounded-full bg-red-500 text-white flex items-center justify-center font-semibold';
        }

        elements.overlay.classList.remove('opacity-0');
        elements.overlayText.textContent = reason;
        elements.countdownEl.textContent = '❌';
        elements.countdownEl.style.color = '#dc2626';

        showEncouragement('Đừng lo! Mọi người đều cần thử vài lần. Hãy thử lại!', 'info');
        setTimeout(resetAll, 4000);
    }

    function resetViolations() {
        state.violations = 0;
        state.faceAbsenceFrames = 0;
        state.lastViolationTime = 0;
        state.stepAttempts = 0;
        elements.violationCounter.style.display = 'none';
        elements.violationCount.textContent = '0';
    }

    function resetAll() {
        state.running = false;
        state.stepIndex = 0;
        state.baseline = null;
        state.recordedBlobs = [];
        state.isPreparing = false;
        state.isCountingDown = false;
        state.userReady = false;
        resetViolations();
        setStepClass();
        updateProgress(0, 100);
        elements.finalWrap.classList.add('hidden');
        elements.overlay.classList.add('opacity-0');
        elements.directionGuide.style.display = 'none';
        elements.submitBtn.disabled = true;
        elements.countdownEl.style.color = '#f59e0b';
        elements.startBtn.disabled = !state.lastDetectedFace;
        elements.resetBtn.disabled = true;
        elements.stopBtn.disabled = true;
        setStatus('Sẵn sàng bắt đầu. Hãy đảm bảo khuôn mặt được phát hiện.', 'status-ready');

        if (!state.detectionActive) {
            startFaceDetection();
        }
    }

    // ====== Enhanced Face Detection Loop ======
    function startFaceDetection() {
        if (state.detectionActive) return;
        state.detectionActive = true;
        state.strictMode = false;

        const detectLoop = async () => {
            if (!state.detectionActive) return;

            const detection = await detectFace();
            if (detection) {
                state.faceAbsenceFrames = 0;
                state.lastDetectedFace = {
                    x: detection.detection.box.x + detection.detection.box.width / 2,
                    y: detection.detection.box.y + detection.detection.box.height / 2,
                    width: detection.detection.box.width,
                    height: detection.detection.box.height,
                    confidence: detection.detection.score,
                    headPose: detection.headPose
                };

                drawFaceBox(detection);

                const confidence = (detection.detection.score * 100).toFixed(0);
                const modeText = detection.quality === 'advanced' ? 'AI' : 'Cơ bản';
                setFaceStatus('detected', `Nhận diện (${confidence}%) - ${modeText}`, 'ri-user-smile-line');

                if (state.strictMode && state.running && state.baseline && !state.isPreparing) {
                    const currentStep = STEPS[state.stepIndex];
                    if (currentStep) {
                        const validation = validateDirection(currentStep.key, detection, state.baseline);

                        // Cập nhật UI với thông tin chi tiết hơn
                        const confidenceBar = Math.min(100, validation.confidence);
                        elements.directionText.innerHTML = `
                            <div class="flex flex-col items-center">
                                <span class="${validation.correct ? 'text-green-600' : 'text-yellow-600'}">
                                    ${currentStep.icon} ${validation.message}
                                </span>
                                <div class="w-full bg-gray-200 rounded-full h-2 mt-2">
                                    <div class="bg-${validation.correct ? 'green' : 'yellow'}-600 h-2 rounded-full transition-all duration-300" 
                                         style="width: ${confidenceBar}%"></div>
                                </div>
                            </div>
                        `;

                        elements.directionGuide.className = `direction-guide ${validation.correct ? 'correct' : 'incorrect'}`;

                        // Chỉ tính vi phạm sau một khoảng thời gian nhất định
                        if (state.stepIndex > 0 && !validation.correct) {
                            const timeInStep = Date.now() - state.currentStepStartTime;
                            if (timeInStep > 4000) { // Tăng thời gian cho phép
                                handleViolation(`${currentStep.label}: ${validation.message}`);
                            }
                        }

                        // Lưu validation message để tránh spam
                        state.lastValidationMessage = validation.message;
                    }
                }

                if (!state.running) {
                    elements.startBtn.disabled = false;
                }
            } else {
                state.faceAbsenceFrames++;
                state.lastDetectedFace = null;
                faceCtx.clearRect(0, 0, elements.faceCanvas.width, elements.faceCanvas.height);

                if (state.strictMode && state.running && state.faceAbsenceFrames > THRESHOLDS.maxFaceAbsenceFrames) {
                    if (handleViolation('Khuôn mặt không trong khung hình')) {
                        return;
                    }
                }

                setFaceStatus('not-detected', 'Hãy di chuyển để khuôn mặt vào khung hình', 'ri-user-unfollow-line');

                if (!state.running) {
                    elements.startBtn.disabled = true;
                }
            }

            if (state.detectionActive) {
                setTimeout(detectLoop, state.detectionMode === 'faceapi' ? 100 : 150);
            }
        };

        detectLoop();
    }

    function stopFaceDetection() {
        state.detectionActive = false;
        state.strictMode = false;
        faceCtx.clearRect(0, 0, elements.faceCanvas.width, elements.faceCanvas.height);
        elements.directionGuide.style.display = 'none';
    }

    // ====== Enhanced Camera & Recording ======
    async function initializeCamera() {
        try {
            console.log('Initializing camera...');
            setStatus('Đang khởi tạo camera...', 'status-loading');

            if (state.stream) {
                state.stream.getTracks().forEach(track => track.stop());
            }

            state.stream = await navigator.mediaDevices.getUserMedia({
                video: {
                    width: { ideal: 640 },
                    height: { ideal: 480 },
                    facingMode: 'user',
                    frameRate: { ideal: 30 }
                },
                audio: false
            });

            elements.videoEl.srcObject = state.stream;

            return new Promise((resolve, reject) => {
                elements.videoEl.onloadedmetadata = async () => {
                    console.log('Video metadata loaded');
                    elements.faceCanvas.width = elements.videoEl.videoWidth;
                    elements.faceCanvas.height = elements.videoEl.videoHeight;

                    setStatus('Đang tải AI model...', 'status-loading');
                    await loadFaceAPI();
                    startFaceDetection();

                    setStatus('Sẵn sàng! Hãy đặt khuôn mặt vào khung hình.', 'status-ready');
                    showEncouragement('Camera đã sẵn sàng! Hãy đặt khuôn mặt vào khung hình nhé.', 'success');
                    resolve();
                };

                elements.videoEl.onerror = (error) => {
                    console.error('Video error:', error);
                    reject(error);
                };

                setTimeout(() => reject(new Error('Camera initialization timeout')), 15000);
            });
        } catch (error) {
            console.error('Camera initialization failed:', error);
            setStatus(`Lỗi camera: ${error.message}`, 'status-error');
            showEncouragement('Không thể truy cập camera. Vui lòng kiểm tra quyền truy cập.', 'error');
            throw error;
        }
    }

    async function startRecording() {
        try {
            console.log('Starting recording...');
            if (!window.MediaRecorder) throw new Error('Trình duyệt không hỗ trợ ghi video');
            if (!state.stream || !state.stream.active) await initializeCamera();

            state.recordedBlobs = [];
            let options = {};

            if (MediaRecorder.isTypeSupported('video/webm;codecs=vp9')) {
                options = { mimeType: 'video/webm;codecs=vp9' };
            } else if (MediaRecorder.isTypeSupported('video/webm;codecs=vp8')) {
                options = { mimeType: 'video/webm;codecs=vp8' };
            } else if (MediaRecorder.isTypeSupported('video/webm')) {
                options = { mimeType: 'video/webm' };
            }

            state.mediaRecorder = new MediaRecorder(state.stream, options);

            state.mediaRecorder.ondataavailable = (event) => {
                if (event.data && event.data.size > 0) {
                    state.recordedBlobs.push(event.data);
                }
            };

            state.mediaRecorder.onstop = () => {
                console.log('Recording stopped. Total chunks:', state.recordedBlobs.length);
                handleRecordingComplete();
            };

            state.mediaRecorder.onerror = (event) => {
                console.error('MediaRecorder error:', event.error);
                setStatus(`Lỗi ghi video: ${event.error.message}`, 'status-error');
            };

            state.mediaRecorder.start(100);
            console.log('MediaRecorder started');
            audioFeedback.success();
        } catch (error) {
            console.error('Failed to start recording:', error);
            setStatus(`Không thể bắt đầu ghi: ${error.message}`, 'status-error');
            throw error;
        }
    }

    function handleRecordingComplete() {
        if (state.recordedBlobs.length === 0) {
            console.error('No recorded data available');
            setStatus('Không có dữ liệu video được ghi lại', 'status-error');
            return;
        }

        try {
            const blob = new Blob(state.recordedBlobs, { type: 'video/webm' });
            console.log('Created video blob:', blob.size, 'bytes');

            const videoURL = URL.createObjectURL(blob);
            elements.finalVideo.src = videoURL;
            elements.finalWrap.classList.remove('hidden');
            elements.submitBtn.blobVideo = blob;
            elements.submitBtn.disabled = false;

            setStatus('🎉 Hoàn thành! Hãy xem lại video của bạn.', 'status-success');
            showEncouragement('Tuyệt vời! Bạn đã hoàn thành thành công!', 'success');
            audioFeedback.success();
        } catch (error) {
            console.error('Error creating video blob:', error);
            setStatus('Lỗi tạo video: ' + error.message, 'status-error');
        }
    }

    // ====== Enhanced Main Recording Process ======
    async function runSteps() {
        try {
            console.log('Starting step sequence...');
            state.running = true;
            state.strictMode = false; // Bắt đầu với chế độ không nghiêm ngặt
            state.stepIndex = 0;
            state.baseline = null;
            resetViolations();
            setStepClass();

            elements.finalWrap.classList.add('hidden');
            elements.submitBtn.disabled = true;
            elements.directionGuide.style.display = 'block';
            elements.overlay.classList.remove('opacity-0');

            setStatus('🎬 Đang bắt đầu quay...', 'status-recording');

            // Đếm ngược ban đầu
            elements.overlayText.textContent = '🎬 Chuẩn bị quay video...';
            for (let i = 3; i > 0; i--) {
                elements.countdownEl.textContent = i;
                audioFeedback.tick();
                await sleep(1000);
            }

            await startRecording();

            const totalSeconds = STEPS.reduce((sum, step) => sum + step.seconds + THRESHOLDS.preparationTime, 0);
            let elapsedSeconds = 0;

            for (let i = 0; i < STEPS.length && state.running; i++) {
                state.stepIndex = i;
                const step = STEPS[i];
                state.currentStepStartTime = Date.now();
                state.stepAttempts = 0;

                console.log(`Starting step ${i + 1}: ${step.label}`);
                setStepClass();

                // Giai đoạn chuẩn bị
                state.isPreparing = true;
                setStepClass();
                elements.overlayText.textContent = `🔄 Chuẩn bị: ${step.description}`;
                elements.directionText.textContent = `🔄 Chuẩn bị: ${step.description}`;
                elements.directionGuide.className = 'direction-guide preparing';

                // Đếm ngược chuẩn bị
                for (let prep = THRESHOLDS.preparationTime; prep > 0 && state.running; prep--) {
                    elements.countdownEl.textContent = `Chuẩn bị: ${prep}`;
                    await sleep(1000);
                    elapsedSeconds++;
                    updateProgress(elapsedSeconds, totalSeconds);
                }

                if (!state.running) break;

                // Bắt đầu giai đoạn thực hiện
                state.isPreparing = false;
                state.strictMode = true; // Bật chế độ nghiêm ngặt
                setStepClass();
                elements.overlayText.textContent = `${step.icon} ${step.label}`;
                elements.directionText.textContent = `${step.icon} ${step.label}`;
                elements.directionGuide.className = 'direction-guide active';

                await sleep(500);

                // Thiết lập baseline cho bước đầu tiên
                if (i === 0 && state.lastDetectedFace) {
                    state.baseline = {
                        x: state.lastDetectedFace.x,
                        y: state.lastDetectedFace.y
                    };
                    console.log('Baseline set:', state.baseline);
                }

                // Đếm ngược cho bước hiện tại
                state.isCountingDown = true;
                for (let countdown = step.seconds; countdown > 0 && state.running; countdown--) {
                    elements.countdownEl.textContent = countdown;
                    if (countdown <= 3) audioFeedback.tick();
                    await sleep(1000);
                    elapsedSeconds++;
                    updateProgress(elapsedSeconds, totalSeconds);
                }
                state.isCountingDown = false;

                if (state.running && i === STEPS.length - 1) {
                    // Hoàn thành bước cuối
                    audioFeedback.success();
                    showEncouragement('Tuyệt vời! Bạn đã hoàn thành tất cả các bước!', 'success');
                }
            }

            if (state.running) {
                state.stepIndex = STEPS.length;
                setStepClass();
                console.log('All steps completed successfully!');
            }

        } catch (error) {
            console.error('Error in runSteps:', error);
            setStatus('Lỗi trong quá trình quay: ' + error.message, 'status-error');
            showEncouragement('Đã xảy ra lỗi. Hãy thử lại nhé!', 'error');
        } finally {
            elements.overlay.classList.add('opacity-0');

            if (state.mediaRecorder && state.mediaRecorder.state === 'recording') {
                state.mediaRecorder.stop();
            }

            state.running = false;
            state.strictMode = false;
            elements.startBtn.disabled = !state.lastDetectedFace;
            elements.resetBtn.disabled = false;
            elements.stopBtn.disabled = true;

            if (!state.detectionActive) {
                startFaceDetection();
            }
        }
    }

    // ====== Enhanced Event Listeners ======
    elements.avatarInput.addEventListener('change', (e) => {
        const file = e.target.files?.[0];
        if (file) {
            elements.avatarPreview.src = URL.createObjectURL(file);
            showEncouragement('Avatar đã được cập nhật!', 'success');
        }
    });

    elements.removeAvatar.addEventListener('click', () => {
        elements.avatarInput.value = '';
        elements.avatarPreview.src = 'https://ui-avatars.com/api/?name=Avatar&background=0891b2&color=ffffff&size=128';
        showEncouragement('Avatar đã được xóa', 'info');
    });

    elements.startBtn.addEventListener('click', async () => {
        if (!state.lastDetectedFace) {
            setStatus('Vui lòng đảm bảo khuôn mặt được phát hiện trước khi bắt đầu', 'status-error');
            showEncouragement('Hãy đặt khuôn mặt vào khung hình trước nhé!', 'warning');
            return;
        }

        if (!state.stream || !state.stream.active) {
            await initializeCamera();
        }

        updateProgress(0, 100);
        elements.startBtn.disabled = true;
        elements.resetBtn.disabled = false;
        elements.stopBtn.disabled = false;

        showEncouragement('Bắt đầu quay! Hãy làm theo hướng dẫn nhé.', 'info');
        await runSteps();
    });

    elements.resetBtn.addEventListener('click', () => {
        if (state.mediaRecorder && state.mediaRecorder.state === 'recording') {
            state.mediaRecorder.stop();
        }
        showEncouragement('Đã reset. Sẵn sàng bắt đầu lại!', 'info');
        resetAll();
    });

    elements.stopBtn.addEventListener('click', () => {
        state.running = false;

        if (state.mediaRecorder && state.mediaRecorder.state === 'recording') {
            state.mediaRecorder.stop();
        }

        elements.startBtn.disabled = !state.lastDetectedFace;
        elements.resetBtn.disabled = false;
        elements.stopBtn.disabled = true;

        if (state.stepIndex < STEPS.length) {
            setStatus('Đã dừng. Bạn có thể bắt đầu lại từ đầu.', 'status-warning');
            elements.submitBtn.disabled = true;
            showEncouragement('Video chưa hoàn thành. Hãy thử lại từ đầu nhé!', 'warning');
        }
    });

    elements.submitBtn.addEventListener('click', async (e) => {
        e.preventDefault();

        if (!elements.submitBtn.blobVideo) {
            setStatus('Chưa có video để gửi.', 'status-error');
            return;
        }

        elements.submitBtn.disabled = true;
        setStatus('🚀 Đang gửi dữ liệu...', 'status-loading');

        const form = document.getElementById('completeRegForm');
        const formData = new FormData(form);
        formData.append('faceVideo', elements.submitBtn.blobVideo, 'faceVideo.webm');

        try {
            const response = await fetch('/Common/CompleteRegistration', {
                method: 'POST',
                body: formData
            });

            if (response.redirected) {
                showEncouragement('Thành công! Đang chuyển hướng...', 'success');
                window.location.href = response.url;
            } else {
                const html = await response.text();
                document.open();
                document.write(html);
                document.close();
            }
        } catch (error) {
            console.error('Submit error:', error);
            setStatus('Lỗi gửi dữ liệu: ' + error.message, 'status-error');
            elements.submitBtn.disabled = false;
            showEncouragement('Gửi thất bại. Hãy thử lại!', 'error');
        }
    });

    // ====== Initialize ======
    console.log('🚀 Face Detection App initializing...');
    setStatus('Đang khởi tạo...', 'status-loading');

    try {
        await initializeCamera();
        showEncouragement('Chào mừng! Hãy thực hiện theo hướng dẫn để hoàn tất.', 'success');
    } catch (error) {
        console.error('Initial setup failed:', error);
        setStatus('Khởi tạo thất bại. Vui lòng kiểm tra camera.', 'status-error');

        if (!state.detectionActive) {
            startFaceDetection();
        }
    }

    // Cleanup khi đóng trang
    window.addEventListener('beforeunload', () => {
        stopFaceDetection();
        if (state.stream) {
            state.stream.getTracks().forEach(track => track.stop());
        }
    });

    // Xử lý khi tab không active (tạm dừng detection để tiết kiệm CPU)
    document.addEventListener('visibilitychange', () => {
        if (document.hidden) {
            if (state.detectionActive && !state.running) {
                stopFaceDetection();
                console.log('Tab hidden, pausing detection');
            }
        } else {
            if (!state.detectionActive && !state.running) {
                startFaceDetection();
                console.log('Tab visible, resuming detection');
            }
        }
    });
});