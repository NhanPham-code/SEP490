/**
 * =================================================================================
 * Social Login Manager for SEP490 Project - FINAL VERSION
 * =================================================================================
 * Author: NhanPham-code
 * Version: 2.1.0 (2025-09-10)
 *
 * Handles:
 * 1. Google Sign-In: Reads Client ID from the DOM and sends idToken to the backend.
 * 2. Biometric (WebAuthn) Login: Full challenge-response flow.
 *
 * CHANGE LOG:
 * - FIXED: Reads Google Client ID from the `data-client_id` attribute in the HTML.
 * - Added `getGoogleClientIdFromDOM()` to safely retrieve configuration.
 * - Initialization logic now ensures Client ID is loaded before any action.
 * =================================================================================
 */

// ==================== CONFIGURATION & STATE ====================
const SOCIAL_LOGIN_CONFIG = {
    endpoints: {
        googleAuth: '/Common/GoogleAuth',
        biometricChallenge: '/Common/GetBiometricChallenge',
        biometricVerify: '/Common/VerifyBiometric'
    },
    timeouts: {
        network: 15000,
        biometric: 60000
    },
    buttonIds: {
        google: 'google-login-btn',
        biometric: 'biometric-login-btn'
    },
    alertContainerId: 'login-alert'
};

// Biến toàn cục để lưu cấu hình động (ví dụ: Client ID đọc từ DOM)
let DYNAMIC_CONFIG = {
    googleClientId: null
};

// ==================== UTILITY FUNCTIONS ====================

function setSocialButtonState(buttonId, state) {
    const button = document.getElementById(buttonId);
    if (!button) return;
    button.classList.remove('loading', 'success', 'error');
    button.disabled = false;
    switch (state) {
        case 'loading': button.classList.add('loading'); button.disabled = true; break;
        case 'success': button.classList.add('success'); button.disabled = true; break;
        case 'error':
            button.classList.add('error');
            button.disabled = true;
            setTimeout(() => setSocialButtonState(buttonId, 'reset'), 3000);
            break;
        case 'reset': default: break;
    }
}

function showToast(message, type = 'info', autoHide = true) {
    if (typeof showAlert === 'function') {
        showAlert('toast-container', message, type, autoHide, true);
    } else {
        console.log(`[Toast ${type.toUpperCase()}]: ${message}`);
    }
}

function showFormAlert(message, type = 'error') {
    if (typeof showAlert === 'function') {
        if (typeof clearAlert === 'function') clearAlert(SOCIAL_LOGIN_CONFIG.alertContainerId);
        showAlert(SOCIAL_LOGIN_CONFIG.alertContainerId, message, type, false, false);
    } else {
        console.error(`[Form Alert]: ${message}`);
    }
}

function clearToastMessages() {
    if (typeof closeAlert !== 'function') return;
    setTimeout(() => {
        document.querySelectorAll('.toast').forEach(toast => {
            const text = toast.textContent || "";
            if (text.includes('Đang') || text.includes('Vui lòng')) {
                const toastId = toast.id || toast.parentElement?.id;
                if (toastId) closeAlert(toastId);
            }
        });
    }, 300);
}

function arrayBufferToBase64(buffer) {
    return btoa(String.fromCharCode.apply(null, new Uint8Array(buffer)));
}

/**
 * [FIX] Hàm đọc Google Client ID từ thuộc tính data của thẻ div trong DOM.
 * @returns {string|null} Google Client ID hoặc null nếu không tìm thấy.
 */
function getGoogleClientIdFromDOM() {
    const googleDiv = document.getElementById('g_id_onload');
    if (!googleDiv) {
        console.error("CRITICAL: The div with id 'g_id_onload' was not found in the DOM at all.");
        return null;
    }

    // Đọc trực tiếp thuộc tính 'data-client_id' thay vì dùng .dataset
    const clientId = googleDiv.getAttribute('data-client_id');

    if (clientId && clientId.length > 1) {
        console.log("Successfully read Google Client ID via getAttribute: ", clientId);
        return clientId;
    }

    console.error("CRITICAL: Found 'g_id_onload' div, but its 'data-client_id' attribute is either missing, empty, or invalid.", `Value found: '${clientId}'`);
    return null;
}

// ==================== GOOGLE SIGN-IN HANDLER ====================

/**
 * Callback được Google gọi sau khi người dùng xác thực thành công.
 * Gửi idToken đến backend /Common/GoogleAuth.
 * @param {Object} response - Google credential response object.
 */
async function handleGoogleSignIn(response) {
    // Ngay khi hàm này được gọi, chúng ta biết quá trình đã có kết quả
    clearToastMessages();
    const googleButtonId = SOCIAL_LOGIN_CONFIG.buttonIds.google;
    setSocialButtonState(googleButtonId, 'loading'); // Giữ loading trong khi xác thực với server

    if (!response || !response.credential) {
        setSocialButtonState(googleButtonId, 'error');
        showFormAlert('Không nhận được thông tin xác thực từ Google.');
        return;
    }

    const requestData = { idToken: response.credential };

    try {
        showToast('⚡ Đang xác thực với máy chủ...', 'info', false);

        const result = await fetch(SOCIAL_LOGIN_CONFIG.endpoints.googleAuth, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Requested-With': 'XMLHttpRequest'
            },
            body: JSON.stringify(requestData),
            signal: AbortSignal.timeout(SOCIAL_LOGIN_CONFIG.timeouts.network)
        });

        const data = await result.json();

        if (data.success) {
            setSocialButtonState(googleButtonId, 'success');
            clearToastMessages();
            showToast('🎉 Đăng nhập Google thành công!', 'success');
            setTimeout(() => {
                window.location.href = data.redirectUrl || '/';
            }, 1500);
        } else {
            throw new Error(data.message || 'Máy chủ từ chối yêu cầu đăng nhập.');
        }
    } catch (error) {
        setSocialButtonState(googleButtonId, 'error');
        clearToastMessages();
        const errorMessage = error.name === 'AbortError'
            ? 'Yêu cầu tới máy chủ bị timeout. Vui lòng thử lại.'
            : (error.message || 'Lỗi kết nối đến máy chủ.');
        showFormAlert(errorMessage);
    }
}

// ==================== INITIALIZATION ====================

async function updateBiometricButtonUI() {
    const button = document.getElementById(SOCIAL_LOGIN_CONFIG.buttonIds.biometric);
    if (!button) return;
    try {
        const isSupported = window.PublicKeyCredential && await PublicKeyCredential.isUserVerifyingPlatformAuthenticatorAvailable();
        if (!isSupported) {
            button.style.display = 'none';
            const info = document.querySelector('.biometric-info');
            if (info) info.style.display = 'none';
        }
    } catch {
        button.style.display = 'none';
    }
}

function addGlobalEventHandlers() {
    const googleBtn = document.getElementById(SOCIAL_LOGIN_CONFIG.buttonIds.google);
    const biometricBtn = document.getElementById(SOCIAL_LOGIN_CONFIG.buttonIds.biometric);
    if (googleBtn) googleBtn.addEventListener('click', handleGoogleLogin);
    if (biometricBtn) biometricBtn.addEventListener('click', handleBiometricLogin);
}

function initializeSocialLogin() {
    console.log("Initializing Social Login Manager...");
    DYNAMIC_CONFIG.googleClientId = getGoogleClientIdFromDOM();
    updateBiometricButtonUI();
    addGlobalEventHandlers();
    window.handleGoogleSignIn = handleGoogleSignIn;
    console.log("Social Login Manager initialized.");
}

// Chạy hàm khởi tạo khi DOM đã sẵn sàng
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', initializeSocialLogin);
} else {
    initializeSocialLogin();
}