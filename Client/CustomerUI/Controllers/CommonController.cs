using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Interfaces;

namespace CustomerUI.Controllers
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
        private static readonly string ROLE_DEFAULT = "Customer";
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
                : "/images/default-avatar.png";

            var faceFullUrl = !string.IsNullOrEmpty(response.FaceImageUrl)
                ? $"{BASE_URL}{response.FaceImageUrl}"
                : "";

            HttpContext.Session.SetString("FullName", response.FullName ?? "User");
            HttpContext.Session.SetString("AvatarUrl", avatarFullUrl);
            HttpContext.Session.SetString("FaceImageUrl", faceFullUrl);
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
                TempData["ErrorMessage"] = "Email and Password can not be emtpy.";
                return View();
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
                if (response == null || string.IsNullOrEmpty(response.AccessToken))
                {
                    TempData["ErrorMessage"] = "Invalid Email or Password.";
                    return View();
                }

                // Lưu token vào cookie (HttpOnly để bảo mật) và lưu thông tin người dùng vào session
                SaveTokenCookiesAndUserInfo(response);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                TempData["ErrorMessage"] = "Login failed: " + ex.Message;
                return View();
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

        // Action xử lý đăng ký người dùng mới
        [HttpPost]
        public async Task<IActionResult> Register(string fullname, string email, string password, string address, string phoneNumber)
        {
            // Tạo một DTO từ các tham số riêng lẻ để tận dụng các validation đã định nghĩa
            var registerRequestDTO = new RegisterRequestDTO
            {
                FullName = fullname,
                Email = email,
                Password = password,
                Address = address,
                PhoneNumber = phoneNumber,
                Role = "Customer" // Giả định vai trò là "Customer"
            };

            // Thực hiện server-side validation thủ công trên DTO mới
            if (!TryValidateModel(registerRequestDTO))
            {
                // Trả về view với lỗi nếu validation thất bại
                TempData["ErrorMessage"] = "Thông tin đăng ký không hợp lệ. Vui lòng kiểm tra lại.";
                TempData["RegisterRequestDTO"] = registerRequestDTO; // Để hiển thị lại thông tin đã nhập
                return View("Login"); // Giả định form đăng ký ở trang Login
            }

            // 1. Kiểm tra xem email đã tồn tại chưa
            if (await _userService.IsEmailExistsAsync(registerRequestDTO.Email))
            {
                TempData["ErrorMessage"] = "Email này đã tồn tại. ";
                TempData["RegisterRequestDTO"] = registerRequestDTO; // Để hiển thị lại thông tin đã nhập
                return View("Login"); // Giả định form đăng ký ở trang Login
            }

            // 2. Tạo mã xác thực
            var verificationCode = new Random().Next(100000, 999999).ToString();

            // 3. Lưu thông tin đăng ký và mã xác thực vào session tạm thời
            // Tạo một DTO tạm thời để lưu vào session
            var tempRegisterData = new
            {
                RegisterData = registerRequestDTO,
                VerificationCode = verificationCode
            };

            HttpContext.Session.SetObjectAsJson("TempRegisterData", tempRegisterData);

            // 4. Gửi mã xác thực về email
            await _emailService.SendEmailAsync(
                registerRequestDTO.Email,
                "Mã Xác Thực Đăng Ký",
                $"Xin chào {registerRequestDTO.FullName}, mã xác thực của bạn là: {verificationCode}");

            // 5. Chuyển hướng người dùng đến trang xác thực
            TempData["Email"] = registerRequestDTO.Email;
            return RedirectToAction("Verify");
        }

        // Action hiển thị trang xác thực
        [HttpGet]
        public IActionResult Verify()
        {
            // Lấy email từ TempData để hiển thị cho người dùng
            ViewBag.Email = TempData["Email"];
            return View();
        }

        // Action xử lý việc xác thực mã
        [HttpPost]
        public async Task<IActionResult> Verify(string email, string code)
        {
            // Lấy dữ liệu tạm từ session
            var tempRegisterData = HttpContext.Session.GetObjectFromJson<dynamic>("TempRegisterData");

            // Kiểm tra dữ liệu session và mã xác thực
            if (tempRegisterData == null || tempRegisterData.VerificationCode != code)
            {
                TempData["ErrorMessage"] = "Mã xác thực không đúng. Vui lòng thử lại.";
                TempData["Email"] = email; // Gán lại email để hiển thị
                return View();
            }

            return View("UploadAvatarAndFace");
        }

        [HttpGet]
        public async Task<IActionResult> ResendCode()
        {
            // Lấy dữ liệu tạm từ session
            var tempRegisterData = HttpContext.Session.GetObjectFromJson<dynamic>("TempRegisterData");

            if (tempRegisterData == null)
            {
                ViewBag.ErrorMessage = "Không tìm thấy dữ liệu đăng ký tạm thời.";
                return View("Verify");
            }

            // Gửi lại mã xác thực
            var registerRequestDTO = tempRegisterData.RegisterData;
            var verificationCode = tempRegisterData.VerificationCode;

            // Tạo lại mã xác thực mới
            var newVerificationCode = new Random().Next(100000, 999999).ToString();

            // Cập nhật mã xác thực trong dữ liệu tạm
            tempRegisterData.VerificationCode = newVerificationCode;

            await _emailService.SendEmailAsync(
                               registerRequestDTO.Email,
                                              "Mã Xác Thực Đăng Ký",
                                                             $"Xin chào {registerRequestDTO.FullName}, mã xác thực của bạn là: {newVerificationCode}");

            ViewBag.SuccessMessage = "Mã xác thực đã được gửi lại đến email của bạn.";
            ViewBag.Email = registerRequestDTO.Email; // Gán lại email để hiển thị
            return View("Verify");
        }

        // Action xử lý việc tải lên ảnh đại diện và ảnh khuôn mặt
        [HttpPost]
        public async Task<IActionResult> CompleteRegistration(IFormFile avatar, IFormFile faceImage)
        {
            // Lấy dữ liệu tạm từ session
            var tempRegisterData = HttpContext.Session.GetObjectFromJson<dynamic>("TempRegisterData");

            if (tempRegisterData == null)
            {
                ViewBag.ErrorMessage = "Không tìm thấy dữ liệu đăng ký tạm thời.";
                return View("Verify");
            }

            // Tạo một DTO từ dữ liệu tạm
            var registerRequestDTO = new RegisterRequestDTO
            {
                FullName = tempRegisterData.RegisterData.FullName,
                Email = tempRegisterData.RegisterData.Email,
                Password = tempRegisterData.RegisterData.Password,
                Address = tempRegisterData.RegisterData.Address,
                PhoneNumber = tempRegisterData.RegisterData.PhoneNumber,
                Role = tempRegisterData.RegisterData.Role,
                Avatar = avatar,
                FaceImage = faceImage
            };


            // Gọi service để đăng ký người dùng
            var isRegistered = await _userService.RegisterAsync(registerRequestDTO);

            if (!isRegistered)
            {
                ViewBag.ErrorMessage = "Đăng ký không thành công. Vui lòng thử lại.";
                return View("Verify");
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
            var userProfile = await _userService.GetProfileAsync(accessToken);

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
                        userProfile = await _userService.GetProfileAsync(newTokens.AccessToken);

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
    }
}
