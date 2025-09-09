using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    public class AccountController : Controller
    {
        private static readonly string ROLE_DEFAULT = "Admin";
        private static readonly string BASE_URL = "https://localhost:7136"; // URL của Gateway của bạn
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;

        public AccountController(IUserService userService, IEmailService emailService, ITokenService tokenService)
        {
            _userService = userService;
            _emailService = emailService;
            _tokenService = tokenService;
        }

        // Dùng cho hàm Login và Register
        // Xử lý lưu token và thông tin người dùng vào cookie và session
        private void UpdateUserSession(LoginResponseDTO response)
        {
            // Lưu thông tin user vào Session (đường dẫn ảnh đầy đủ)
            var avatarFullUrl = !string.IsNullOrEmpty(response.AvatarUrl)
                ? $"{BASE_URL}{response.AvatarUrl}"
                : $"{BASE_URL}/avatars/default-avatar.png";

            HttpContext.Session.SetString("UserId", response.UserId.ToString());
            HttpContext.Session.SetString("FullName", response.FullName ?? "User");
            HttpContext.Session.SetString("AvatarUrl", avatarFullUrl);
        }

        // Dùng cho hàm UpdateProfile và UpdateAvatar (khác ở tham số truyền vào)
        private void UpdateUserSession(PrivateUserProfileDTO userProfileDTO)
        {
            // Lưu thông tin user vào Session (đường dẫn ảnh đầy đủ)
            var avatarFullUrl = !string.IsNullOrEmpty(userProfileDTO.AvatarUrl)
                ? $"{BASE_URL}{userProfileDTO.AvatarUrl}"
                : $"{BASE_URL}/avatars/default-avatar.png";

            HttpContext.Session.SetString("UserId", userProfileDTO.UserId.ToString());
            HttpContext.Session.SetString("FullName", userProfileDTO.FullName ?? "User");
            HttpContext.Session.SetString("AvatarUrl", avatarFullUrl);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return Json(new { success = false, message = "Email và Password không được để trống." });
            }

            var model = new LoginRequestDTO
            {
                Email = email,
                Password = password,
                Role = ROLE_DEFAULT
            };

            try
            {
                var response = await _userService.LoginAsync(model);
                if (response == null)
                {
                    return Json(new { success = false, message = "Email hoặc mật khẩu không đúng!" });
                }

                if (response.IsValid == false)
                {
                    return Json(new { success = false, message = response.Message });
                }

                // Lưu token vào cookie (HttpOnly để bảo mật)
                _tokenService.SaveTokensToCookies(response, rememberMe);

                // Lưu thông tin người dùng vào session
                UpdateUserSession(response);

                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Login failed: " + ex.Message });
            }
        }

        public async Task<IActionResult> Logout()
        {
            // Lấy token từ cookies trước khi xóa
            var accessToken = Request.Cookies["AccessToken"];
            var refreshToken = Request.Cookies["RefreshToken"];

            // Xóa cookies
            _tokenService.ClearTokens();

            // Xóa session
            HttpContext.Session.Clear();

            // Gọi API logout
            var logoutRequest = new LogoutRequestDTO
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            try
            {
                var result = await _userService.LogoutAsync(logoutRequest);

            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                TempData["ErrorMessage"] = "Logout failed: " + ex.Message;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
