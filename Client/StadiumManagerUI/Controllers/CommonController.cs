using DTOs.Helper;
using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Interfaces;

namespace StadiumManagerUI.Controllers
{
    // Cần có class này để định nghĩa các extension method cho Session
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }

    public class CommonController : Controller
    {
        private static readonly string ROLE_DEFAULT = "StadiumManager";
        private static readonly string BASE_URL = "https://localhost:7136"; // URL của Gateway của bạn
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;

        public CommonController(IUserService userService, IEmailService emailService, ITokenService tokenService)
        {
            _userService = userService;
            _emailService = emailService;
            _tokenService = tokenService;
        }

        // Xử lý lưu token và thông tin người dùng vào cookie và session
        private void SaveTokenCookiesAndUserInfo(LoginResponseDTO response)
        {
            // Lưu token vào cookie (HttpOnly để bảo mật)
            _tokenService.SaveTokens(response);

            // Lưu thông tin user vào Session (đường dẫn ảnh đầy đủ)
            var avatarFullUrl = !string.IsNullOrEmpty(response.AvatarUrl)
                ? $"{BASE_URL}{response.AvatarUrl}"
                : $"{BASE_URL}/avatars/default-avatar.png";

            HttpContext.Session.SetString("UserId", response.UserId.ToString());
            HttpContext.Session.SetString("FullName", response.FullName ?? "User");
            HttpContext.Session.SetString("AvatarUrl", avatarFullUrl);
        }

        private void SaveUserInfo(PrivateUserProfileDTO userProfileDTO)
        {
            // Lưu thông tin user vào Session (đường dẫn ảnh đầy đủ)
            var avatarFullUrl = !string.IsNullOrEmpty(userProfileDTO.AvatarUrl)
                ? $"{BASE_URL}{userProfileDTO.AvatarUrl}"
                : $"{BASE_URL}/avatars/default-avatar.png";

            HttpContext.Session.SetString("UserId", userProfileDTO.UserId.ToString());
            HttpContext.Session.SetString("FullName", userProfileDTO.FullName ?? "User");
            HttpContext.Session.SetString("AvatarUrl", avatarFullUrl);
        }

        public IActionResult Login()
        {
            return View();
        }

        // Xử lý login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
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

                // Lưu token vào cookie (HttpOnly để bảo mật) và lưu thông tin người dùng vào session
                SaveTokenCookiesAndUserInfo(response);

                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Login failed: " + ex.Message });
            }
        }

        // Xử lý đăng xuất
        public async Task<IActionResult> Logout()
        {
            // Lấy token từ cookies trước khi xóa
            var accessToken = Request.Cookies["AccessToken"];
            var refreshToken = Request.Cookies["RefreshToken"];

            // Xóa cookies
            Response.Cookies.Delete("AccessToken");
            Response.Cookies.Delete("RefreshToken");

            // Xóa session lưu các thông tin của người dùng
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

            return RedirectToAction("Login", "Common");
        }

        // Action xử lý đăng ký người dùng mới
        [HttpPost]
        public async Task<IActionResult> Register(string fullname, string email, string password, string address,
            string phoneNumber, string gender, string dateOfBirth)
        {
            // Tạo DTO
            var registerRequestDTO = new CustomerRegisterRequestDTO
            {
                FullName = fullname,
                Email = email,
                Password = password,
                Address = address,
                PhoneNumber = phoneNumber,
                Role = ROLE_DEFAULT,
                Gender = gender,
                DateOfBirth = dateOfBirth
            };

            // Server-side validation
            if (!TryValidateModel(registerRequestDTO))
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .FirstOrDefault();

                return Json(new
                {
                    success = false,
                    message = errors ?? "Thông tin đăng ký không hợp lệ. Vui lòng kiểm tra lại."
                });
            }

            try
            {
                // Kiểm tra email tồn tại
                if (await _userService.IsEmailExistsAsync(registerRequestDTO.Email))
                {
                    return Json(new
                    {
                        success = false,
                        message = "Email này đã tồn tại. Vui lòng sử dụng email khác."
                    });
                }

                // Tạo mã xác thực
                var verificationCode = new Random().Next(100000, 999999).ToString();

                // Lưu vào session
                var tempRegisterData = new TempRegistrationData
                {
                    RegisterData = registerRequestDTO,
                    VerificationCode = verificationCode,
                    VerificationCodeTimestamp = DateTime.UtcNow
                };

                HttpContext.Session.SetObjectAsJson("TempRegisterData", tempRegisterData);

                // Gửi email
                await _emailService.SendEmailAsync(
                    registerRequestDTO.Email,
                    "Mã Xác Thực Đăng Ký - Sportivey",
                    $"Xin chào {registerRequestDTO.FullName},\n\nMã xác thực của bạn là: {verificationCode}\n\nMã này có hiệu lực trong 60 giây.\n\nTrân trọng,\nĐội ngũ Sportivey");

                return Json(new
                {
                    success = true,
                    message = "Đăng ký thành công! Mã xác thực đã được gửi đến email của bạn.",
                    redirectUrl = Url.Action("Verify"),
                    email = registerRequestDTO.Email
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Đã có lỗi xảy ra trong quá trình đăng ký. Vui lòng thử lại."
                });
            }
        }

        // Action hiển thị trang xác thực
        [HttpGet]
        public IActionResult Verify()
        {
            // Lấy dữ liệu tạm từ session
            var tempRegisterData = HttpContext.Session.GetObjectFromJson<TempRegistrationData>("TempRegisterData");

            // Trường hợp 1: Session không tồn tại hoặc đã hết hạn
            if (tempRegisterData == null)
            {
                return Json(new { success = false, message = "Phiên đăng ký đã hết hạn hoặc không hợp lệ. Vui lòng thử lại." });
            }

            ViewBag.Email = tempRegisterData.RegisterData.Email;
            return View();
        }

        // Action xử lý việc xác thực mã qua AJAX
        [HttpPost]
        public async Task<IActionResult> Verify(string email, string code)
        {
            // Lấy dữ liệu tạm từ session
            var tempRegisterData = HttpContext.Session.GetObjectFromJson<TempRegistrationData>("TempRegisterData");

            // Trường hợp 1: Session không tồn tại hoặc đã hết hạn
            if (tempRegisterData == null)
            {
                return Json(new { success = false, message = "Phiên đăng ký đã hết hạn hoặc không hợp lệ. Vui lòng thử lại." });
            }

            // Trường hợp 2: Mã đã hết hạn theo thời gian
            if (DateTime.UtcNow - tempRegisterData.VerificationCodeTimestamp > TimeSpan.FromSeconds(60))
            {
                return Json(new { success = false, message = "Mã xác thực đã hết hạn. Vui lòng yêu cầu gửi lại mã mới." });
            }

            // Trường hợp 3: Mã không đúng hoặc email không khớp
            if (tempRegisterData.RegisterData.Email != email || tempRegisterData.VerificationCode != code)
            {
                return Json(new { success = false, message = "Mã xác thực không đúng. Vui lòng thử lại." });
            }

            // Trường hợp 4: Xác thực thành công
            // Không xóa session ở đây, vì cần dùng ở bước tiếp theo (UploadAvatarAndFace)
            return Json(new
            {
                success = true,
                redirectUrl = Url.Action("UploadCccd", "Common") // Đảm bảo "Common" là tên Controller của bạn
            });
        }

        [HttpGet]
        public async Task<IActionResult> ResendCode()
        {
            // Lấy dữ liệu tạm từ session
            var tempRegisterData = HttpContext.Session.GetObjectFromJson<TempRegistrationData>("TempRegisterData");

            if (tempRegisterData == null)
            {
                return Json(new { success = false, message = "Không tìm thấy dữ liệu đăng ký tạm thời." });
            }

            // Gửi lại mã xác thực
            var registerRequestDTO = tempRegisterData.RegisterData;

            // Tạo lại mã xác thực mới
            var newVerificationCode = new Random().Next(100000, 999999).ToString();

            await _emailService.SendEmailAsync(
                    registerRequestDTO.Email,
                    "Mã Xác Thực Đăng Ký - Sportivey",
                    $"Xin chào {registerRequestDTO.FullName},\n\nMã xác thực của bạn là: {newVerificationCode}\n\nMã này có hiệu lực trong 60 giây.\n\nTrân trọng,\nĐội ngũ Sportivey");

            // Cập nhật lại session với mã mới
            tempRegisterData.VerificationCode = newVerificationCode;
            tempRegisterData.VerificationCodeTimestamp = DateTime.UtcNow; // Cập nhật lại thời gian gửi mã

            HttpContext.Session.SetObjectAsJson("TempRegisterData", tempRegisterData);

            return Json(new { success = true, message = "Mã xác thực mới đã được gửi thành công." });
        }

        // Action hiển thị trang tải lên ảnh đại diện và ảnh khuôn mặt
        [HttpGet]
        public IActionResult UploadCccd()
        {
            return View();
        }

        // Action xử lý việc tải lên ảnh đại diện và ảnh khuôn mặt
        [HttpPost]
        public async Task<IActionResult> CompleteRegistration(IFormFile avatar, IFormFile frontCccdImage)
        {

            // Lấy dữ liệu tạm từ session
            var tempRegisterData = HttpContext.Session.GetObjectFromJson<dynamic>("TempRegisterData");

            if (tempRegisterData == null)
            {
                ViewBag.ErrorMessage = "Không tìm thấy dữ liệu đăng ký tạm thời.";
                return View("Verify");
            }

            // Tạo một DTO từ dữ liệu tạm
            var registerRequestDTO = new StadiumManagerRegisterRequestDTO
            {
                FullName = tempRegisterData.RegisterData.FullName,
                Email = tempRegisterData.RegisterData.Email,
                Password = tempRegisterData.RegisterData.Password,
                Address = tempRegisterData.RegisterData.Address,
                PhoneNumber = tempRegisterData.RegisterData.PhoneNumber,
                Role = tempRegisterData.RegisterData.Role,
                Gender = tempRegisterData.RegisterData.Gender,
                DateOfBirth = tempRegisterData.RegisterData.DateOfBirth,
                Avatar = avatar,
                FrontCCCDImage = frontCccdImage // nhận dạng IFormFile chuẩn
            };

            // Gọi service để đăng ký người dùng (API sẽ xử lý lưu file video từ base64)
            var isRegistered = await _userService.StadiumManagerRegisterAsync(registerRequestDTO);

            if (!isRegistered)
            {
                ViewBag.ErrorMessage = "Đăng ký không thành công. Vui lòng thử lại.";
                return View("Login");
            }

            // Xóa dữ liệu tạm sau khi đăng ký thành công
            HttpContext.Session.Remove("TempRegisterData");

            // Đăng nhập người dùng ngay sau khi đăng ký thành công
            var loginResponse = await _userService.LoginAsync(new LoginRequestDTO
            {
                Email = registerRequestDTO.Email,
                Password = registerRequestDTO.Password,
                Role = ROLE_DEFAULT
            });

            if (loginResponse == null || string.IsNullOrEmpty(loginResponse.AccessToken))
            {
                ViewBag.ErrorMessage = "Đăng nhập sau đăng ký không thành công.";
                return View("Verify");
            }

            // Lưu token vào cookie (HttpOnly để bảo mật) và lưu thông tin người dùng vào session
            SaveTokenCookiesAndUserInfo(loginResponse);

            return RedirectToAction("Index", "Home");
        }

        // lấy profile của người dùng
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            // 1. Get tokens from cookie
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            var refreshToken = _tokenService.GetRefreshTokenFromCookie();

            // 2. Handle missing access token
            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Access Token is missing.";
                return RedirectToAction("Login");
            }

            // 3. Initial service call
            var userProfile = await _userService.GetMyProfileAsync(accessToken);

            // 4. If first attempt fails, attempt to refresh token
            if (userProfile == null)
            {
                if (!string.IsNullOrEmpty(refreshToken))
                {
                    try
                    {
                        // Call the refresh token service
                        var newTokens = await _userService.RefreshTokenAsync(new RefreshTokenRequestDTO
                        {
                            AccessToken = accessToken,
                            RefreshToken = refreshToken
                        });

                        // Save the new tokens
                        _tokenService.SaveTokens(newTokens);

                        // Retry the profile request with the new access token
                        userProfile = await _userService.GetMyProfileAsync(newTokens.AccessToken);

                        if (userProfile == null)
                        {
                            // Redirect if retry also fails
                            TempData["ErrorMessage"] = "Failed to retrieve user profile after token refresh.";
                            return RedirectToAction("Login");
                        }
                    }
                    catch (HttpRequestException)
                    {
                        // Redirect on refresh failure
                        TempData["ErrorMessage"] = "Session has expired. Please log in again.";
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    // Redirect if no refresh token is available
                    TempData["ErrorMessage"] = "Session has expired. Please log in again.";
                    return RedirectToAction("Login");
                }
            }

            userProfile.AvatarUrl = !string.IsNullOrEmpty(userProfile.AvatarUrl)
                ? $"{BASE_URL}{userProfile.AvatarUrl}"
                : "/images/default-avatar.png";

            userProfile.FaceImageUrl = !string.IsNullOrEmpty(userProfile.FaceImageUrl)
                ? $"{BASE_URL}{userProfile.FaceImageUrl}"
                : "";

            return View(userProfile);
        }

        // update profile
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateUserProfileDTO updateUserProfileDTO)
        {
            // 1. Get access token from cookie
            var accessToken = _tokenService.GetAccessTokenFromCookie();

            // 2. Handle missing access token
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Access Token is missing." });
            }

            // 3. Call the service to update user profile
            try
            {
                var updatedUser = await _userService.UpdateUserProfileAsync(updateUserProfileDTO, accessToken);

                SaveUserInfo(updatedUser); // Lưu thông tin người dùng vào session

                return Ok(updatedUser); // Trả thẳng JSON về client
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(new { message = $"Failed to update profile: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }
        }

        // update avatar
        [HttpPost]
        public async Task<IActionResult> UpdateAvatar(UpdateAvatarDTO updateAvatarDTO)
        {
            // 1. Get access token from cookie
            var accessToken = _tokenService.GetAccessTokenFromCookie();

            // 2. Handle missing access token
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Access Token is missing." });
            }

            // 3. Call the service to update avatar
            try
            {
                var updatedUser = await _userService.UpdateAvatarAsync(updateAvatarDTO, accessToken);

                SaveUserInfo(updatedUser); // Lưu thông tin người dùng vào session

                updatedUser.AvatarUrl = !string.IsNullOrEmpty(updatedUser.AvatarUrl)
                ? $"{BASE_URL}{updatedUser.AvatarUrl}"
                : "/images/default-avatar.png";

                updatedUser.FaceImageUrl = !string.IsNullOrEmpty(updatedUser.FaceImageUrl)
                    ? $"{BASE_URL}{updatedUser.FaceImageUrl}"
                    : "";

                return Ok(updatedUser); // Trả thẳng JSON về client
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(new { message = $"Failed to update profile: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }
        }

        // Hiển thị trang quên mật khẩu
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // Gửi mã xác thực đặt lại mật khẩu
        [HttpPost]
        public async Task<IActionResult> SendResetCode(string email)
        {
            // check email tồn tại
            if (!await _userService.IsEmailExistsAsync(email))
            {
                return Json(new { success = false, message = "Email không tồn tại trong hệ thống." });
            }

            // Tạo mã xác thực
            var resetCode = new Random().Next(100000, 999999).ToString();

            // Lưu mã xác thực vào session
            HttpContext.Session.SetString("ResetEmail", email);
            HttpContext.Session.SetString("PasswordResetCode", resetCode);
            HttpContext.Session.SetObjectAsJson("CodeTimeExits", DateTime.UtcNow);

            // Gửi mã xác thực về email
            await _emailService.SendEmailAsync(
                               email,
                                              "Mã Xác Thực Đặt Lại Mật Khẩu",
                                                             $"Mã xác thực đặt lại mật khẩu của bạn là: {resetCode}");

            return Json(new { success = true, email = email, message = "Mã xác thực đã được gửi đến email của bạn." });
        }

        [HttpPost]
        public IActionResult VerifyResetCode(string email, string code)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(code))
            {
                return Json(new { success = false, message = "Email và mã xác thực không được để trống." });
            }

            var sessionEmail = HttpContext.Session.GetString("ResetEmail");
            var sessionCode = HttpContext.Session.GetString("PasswordResetCode");
            var codeTimeExits = HttpContext.Session.GetObjectFromJson<DateTime>("CodeTimeExits");

            // Trường hợp 1: Session không tồn tại hoặc đã hết hạn
            if (string.IsNullOrEmpty(sessionEmail) || string.IsNullOrEmpty(sessionCode) || codeTimeExits == default)
            {
                return Json(new { success = false, message = "Phiên đặt lại mật khẩu đã hết hạn hoặc không hợp lệ. Vui lòng thử lại." });
            }

            // Trường hợp 2: Mã đã hết hạn theo thời gian
            if (DateTime.UtcNow - codeTimeExits > TimeSpan.FromSeconds(60))
            {
                return Json(new { success = false, message = "Mã xác thực đã hết hạn. Vui lòng yêu cầu gửi lại mã mới." });
            }

            // Trường hợp 3: Mã không đúng hoặc email không khớp
            if (sessionEmail != email || sessionCode != code)
            {
                return Json(new { success = false, message = "Mã xác thực không đúng. Vui lòng thử lại." });
            }

            // Trường hợp 4: Xác thực thành công
            return Json(new { success = true, email = email, message = "Xác thực thành công. Vui lòng đặt lại mật khẩu mới." });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email, string code, string newPassword, string confirmPassword)
        {
            var resetPasswordDTO = new ResetPasswordDTO
            {
                Email = email,
                NewPassword = newPassword
            };

            var result = await _userService.ResetPasswordAsync(resetPasswordDTO);
            if (!result)
            {
                return Json(new { success = false, message = "Đặt lại mật khẩu không thành công. Vui lòng thử lại." });
            }

            // Xóa session sau khi đặt lại mật khẩu thành công
            HttpContext.Session.Clear();

            return Json(new { success = true, message = "Đặt lại mật khẩu thành công. Vui lòng đăng nhập với mật khẩu mới." });
        }
    }
}
