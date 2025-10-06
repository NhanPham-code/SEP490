// ====== Bước 1: Xử lý nút "Đăng nhập bằng sinh trắc học" ======
document.getElementById('biometric-login-btn').addEventListener('click', function () {
    showFaceLoginModal();
});

function showFaceLoginModal() {
    // Hiện modal hoặc popup chứa <video> và nút chụp
    document.body.insertAdjacentHTML('beforeend', `
        <div id="face-login-modal" class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-40">
            <div class="bg-white rounded-xl shadow-xl p-6 relative w-full max-w-xs flex flex-col items-center">
                <video id="face-login-video" autoplay muted playsinline class="rounded-lg w-64 h-48 bg-gray-100 mb-4"></video>
                <canvas id="face-login-canvas" class="hidden"></canvas>
                <div id="face-login-status" class="mb-2 text-gray-600 text-sm"></div>
                <button id="face-login-capture" class="sport-btn sport-btn-primary mb-2 w-full"><i class="ri-camera-line mr-2"></i>Chụp ảnh</button>
                <button id="face-login-cancel" class="sport-btn sport-btn-secondary w-full">Huỷ</button>
            </div>
        </div>
    `);

    // Khởi động camera
    const video = document.getElementById('face-login-video');
    navigator.mediaDevices.getUserMedia({ video: { facingMode: "user" }, audio: false })
        .then(stream => {
            video.srcObject = stream;
        })
        .catch(err => {
            document.getElementById('face-login-status').textContent = "Không thể truy cập camera.";
        });

    // Chụp ảnh
    document.getElementById('face-login-capture').onclick = async function () {
        const canvas = document.getElementById('face-login-canvas');
        canvas.width = video.videoWidth;
        canvas.height = video.videoHeight;
        canvas.getContext('2d').drawImage(video, 0, 0, canvas.width, canvas.height);
        canvas.toBlob(async function (blob) {
            await sendFaceLoginImage(blob);
            stopFaceLoginCamera();
        }, 'image/png');
    };

    // Huỷ modal
    document.getElementById('face-login-cancel').onclick = stopFaceLoginCamera;

    // Đóng modal và stop camera
    function stopFaceLoginCamera() {
        if (video.srcObject) {
            video.srcObject.getTracks().forEach(track => track.stop());
        }
        document.getElementById('face-login-modal').remove();
    }
}

// Gửi ảnh lên server để login bằng khuôn mặt
async function sendFaceLoginImage(blob) {
    const status = document.getElementById('face-login-status');
    status.textContent = "Đang xác thực khuôn mặt...";
    const formData = new FormData();
    formData.append("FaceImage", blob, "face.png");

    try {
        const response = await fetch('/Common/AiFaceAuth', {
            method: 'POST',
            body: formData
        });

        let data;
        try {
            data = await response.json();
        } catch {
            data = {};
        }

        if (response.ok && data.success) {
            status.textContent = "Đăng nhập thành công! Đang chuyển hướng...";
            setTimeout(() => window.location.href = data.redirectUrl || '/', 1500);
        } else {
            status.textContent = data.message || "Đăng nhập bằng khuôn mặt thất bại.";
        }
    } catch (error) {
        status.textContent = "Lỗi kết nối hoặc máy chủ.";
    }
}