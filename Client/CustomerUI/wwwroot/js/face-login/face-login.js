// ========================================================================
// AI Face Login with Auto-Capture - Powered by face-api.js
// Version: 2.0
// ========================================================================

document.addEventListener('DOMContentLoaded', () => {
    const faceLoginBtn = document.getElementById('biometric-login-btn');
    if (!faceLoginBtn) return;

    let faceApiModelsLoaded = false;
    let isDetectionRunning = false;
    let detectionInterval;

    // --- Bước 1: Tải các model của face-api.js ---
    async function loadFaceApiModels() {
        if (faceApiModelsLoaded) return true;
        // Đường dẫn tới thư mục models trong wwwroot
        const modelPath = '/weights';
        try {
            await faceapi.nets.tinyFaceDetector.loadFromUri(modelPath);
            faceApiModelsLoaded = true;
            console.log("FaceAPI models loaded successfully.");
            return true;
        } catch (error) {
            console.error("Error loading FaceAPI models:", error);
            showToast('Không thể tải mô hình nhận diện khuôn mặt.', 'error');
            return false;
        }
    }

    // --- Bước 2: Xử lý sự kiện click vào nút đăng nhập ---
    faceLoginBtn.addEventListener('click', async function () {
        if (!navigator.mediaDevices || !navigator.mediaDevices.getUserMedia) {
            showToast('Trình duyệt của bạn không hỗ trợ truy cập camera.', 'error');
            return;
        }

        showToast('Đang khởi tạo camera...', 'info', false);
        const modelsLoaded = await loadFaceApiModels();
        // Xóa toast "Đang khởi tạo..."
        if (typeof clearToastMessages === 'function') clearToastMessages();
        else if (typeof showAlert === 'function') showAlert('toast-container', '', 'info', true, true);


        if (modelsLoaded) {
            showFaceLoginModal();
        }
    });

    // --- Bước 3: Hiển thị Modal và bắt đầu nhận diện ---
    function showFaceLoginModal() {
        if (document.getElementById('face-login-modal')) return;

        document.body.insertAdjacentHTML('beforeend', `
            <div id="face-login-modal" class="fixed inset-0 z-[100] flex items-center justify-center bg-black bg-opacity-50 backdrop-blur-sm">
                <div class="bg-white rounded-xl shadow-xl p-6 relative w-full max-w-xs flex flex-col items-center text-center">
                    <h3 class="text-lg font-bold text-gray-800 mb-2">Đăng nhập bằng khuôn mặt</h3>
                    <div id="face-login-video-container" class="relative rounded-full w-64 h-64 bg-gray-200 mb-4 overflow-hidden border-4 border-gray-300">
                        <video id="face-login-video" autoplay muted playsinline class="w-full h-full object-cover" style="transform: scaleX(-1);"></video>
                        <canvas id="face-login-canvas" class="absolute top-0 left-0 w-full h-full" style="transform: scaleX(-1);"></canvas>
                    </div>
                    <p id="face-login-status" class="mb-4 text-gray-600 text-sm h-10 flex items-center justify-center">Vui lòng đưa khuôn mặt vào trong khung hình.</p>
                    <button id="face-login-cancel" class="submit-btn secondary w-full">Huỷ</button>
                </div>
            </div>
        `);

        const video = document.getElementById('face-login-video');
        const statusEl = document.getElementById('face-login-status');
        const container = document.getElementById('face-login-video-container');

        navigator.mediaDevices.getUserMedia({ video: { facingMode: "user" }, audio: false })
            .then(stream => {
                video.srcObject = stream;
                video.onplay = () => startFaceDetection(video, statusEl, container);
            })
            .catch(err => {
                statusEl.textContent = "Lỗi: Không thể truy cập camera.";
                container.style.borderColor = '#ef4444'; // Màu đỏ
            });

        document.getElementById('face-login-cancel').onclick = stopFaceLogin;
    }

    // --- Bước 4: Vòng lặp nhận diện và tự động chụp ---
    function startFaceDetection(video, statusEl, container) {
        if (isDetectionRunning) return;
        isDetectionRunning = true;

        const canvas = document.getElementById('face-login-canvas');
        const displaySize = { width: video.videoWidth, height: video.videoHeight };
        faceapi.matchDimensions(canvas, displaySize);

        let captureTimeout = null;
        let isCapturing = false;

        detectionInterval = setInterval(async () => {
            if (isCapturing) return;

            const detections = await faceapi.detectAllFaces(video, new faceapi.TinyFaceDetectorOptions({ scoreThreshold: 0.5 }));

            if (detections.length === 1) {
                const face = detections[0].box;
                const isLargeEnough = face.width > 100 && face.height > 100;

                if (isLargeEnough) {
                    container.style.borderColor = '#22c55e'; // Màu xanh
                    statusEl.textContent = "Giữ yên...";
                    if (!captureTimeout) {
                        captureTimeout = setTimeout(() => {
                            isCapturing = true;
                            captureAndSend(video, statusEl);
                        }, 1200); // Chờ 1.2 giây để ổn định
                    }
                } else {
                    container.style.borderColor = '#f97316'; // Màu cam
                    statusEl.textContent = "Vui lòng đến gần camera hơn.";
                    clearTimeout(captureTimeout);
                    captureTimeout = null;
                }
            } else {
                container.style.borderColor = '#ef4444'; // Màu đỏ
                statusEl.textContent = detections.length > 1 ? "Phát hiện nhiều khuôn mặt!" : "Không tìm thấy khuôn mặt.";
                clearTimeout(captureTimeout);
                captureTimeout = null;
            }
        }, 200);
    }

    function captureAndSend(video, statusEl) {
        statusEl.textContent = "Đã chụp! Đang xác thực...";
        const captureCanvas = document.createElement('canvas');
        captureCanvas.width = video.videoWidth;
        captureCanvas.height = video.videoHeight;

        const ctx = captureCanvas.getContext('2d');
        // Lật ảnh lại cho đúng chiều
        ctx.translate(video.videoWidth, 0);
        ctx.scale(-1, 1);
        ctx.drawImage(video, 0, 0, captureCanvas.width, captureCanvas.height);

        captureCanvas.toBlob(blob => {
            sendFaceLoginImage(blob);
        }, 'image/jpeg', 0.9);
    }

    // --- Bước 5: Dừng camera và đóng Modal ---
    function stopFaceLogin() {
        isDetectionRunning = false;
        clearInterval(detectionInterval);

        const modal = document.getElementById('face-login-modal');
        if (modal) {
            const video = modal.querySelector('video');
            if (video && video.srcObject) {
                video.srcObject.getTracks().forEach(track => track.stop());
            }
            modal.remove();
        }
    }

    // --- Bước 6: Gửi ảnh lên Server ---
    async function sendFaceLoginImage(blob) {
        const formData = new FormData();
        formData.append("FaceImage", blob, "face-login.jpg");

        try {
            const response = await fetch('/Common/AiFaceAuth', {
                method: 'POST',
                body: formData,
                signal: AbortSignal.timeout(20000) // Timeout 20 giây
            });

            const data = await response.json();

            if (response.ok && data.success) {
                showToast('🎉 Đăng nhập thành công!', 'success');
                setTimeout(() => {
                    stopFaceLogin();
                    window.location.href = data.redirectUrl || '/';
                }, 1500);
            } else {
                throw new Error(data.message || 'Đăng nhập bằng khuôn mặt thất bại.');
            }
        } catch (error) {
            showToast(error.message, 'error');
            setTimeout(stopFaceLogin, 2500); // Thất bại, đóng modal sau 2.5s
        }
    }
});