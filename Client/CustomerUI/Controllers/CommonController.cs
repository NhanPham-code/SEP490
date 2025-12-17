using DTOs.Helper;
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

        private readonly IConfiguration _configuration;


        public CommonController(IUserService userService, IEmailService emailService, ITokenService tokenService, IConfiguration configuration)
        {
            _userService = userService;
            _emailService = emailService;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        // Dùng cho hàm Login và Register
        // Xử lý lưu token và thông tin người dùng vào cookie và session
        private void UpdateUserSession(LoginResponseDTO response)
        {
            // Lưu thông tin user vào Session (đường dẫn ảnh đầy đủ)
            var avatarFullUrl = !string.IsNullOrEmpty(response.AvatarUrl)
                ? $"{BASE_URL}{response.AvatarUrl}"
                : $"{BASE_URL}/uploads/avatars/default-avatar.png";

            HttpContext.Session.SetInt32("UserId", response.UserId);
            HttpContext.Session.SetString("FullName", response.FullName ?? "User");
            HttpContext.Session.SetString("AvatarUrl", avatarFullUrl);
        }

        // Dùng cho hàm UpdateProfile và UpdateAvatar (khác ở tham số truyền vào)
        private void UpdateUserSession(PrivateUserProfileDTO userProfileDTO)
        {
            // Lưu thông tin user vào Session (đường dẫn ảnh đầy đủ)
            var avatarFullUrl = !string.IsNullOrEmpty(userProfileDTO.AvatarUrl)
                ? $"{BASE_URL}{userProfileDTO.AvatarUrl}"
                : $"{BASE_URL}/uploads/avatars/default-avatar.png";

            HttpContext.Session.SetInt32("UserId", userProfileDTO.UserId);
            HttpContext.Session.SetString("FullName", userProfileDTO.FullName ?? "User");
            HttpContext.Session.SetString("AvatarUrl", avatarFullUrl);
        }

        // thêm hoặc cập nhật khuôn mặt
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateFaceEmbeddings([FromForm] FaceImagesDTO faceImagesDTO)
        {
            // 1. Get access token from cookie
            var accessToken = _tokenService.GetAccessTokenFromCookie();

            // 2. Handle missing access token
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Phiên đăng nhập hết hạn." });
            }

            // 3. Call the service to add or update face embeddings
            try
            {
                var result = await _userService.AddorUpdateFaceEmbeddings(faceImagesDTO, accessToken);

                if (!result)
                {
                    return BadRequest(new { message = "Thêm và cập nhật khuôn mặt thất bại. " });
                }

                return Ok(new { message = "Thêm và cập nhật khuôn mặt thành công." });
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(new { message = $"Thêm và cập nhật khuôn mặt thất bại: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }
        }

        // Xử lý đăng nhập bằng AI Face
        [HttpPost]
        public async Task<IActionResult> AiFaceAuth([FromForm] AiFaceLoginRequestDTO request)
        {
            if (request == null || request.FaceImage == null)
            {
                return Json(new { success = false, message = "Ảnh khuôn mặt không hợp lệ." });
            }

            try
            {
                var response = await _userService.LoginWithFaceAsync(request);

                if (response.IsValid == false)
                {
                    return Json(new { success = false, message = response.Message });
                }

                _tokenService.SaveTokensToCookies(response, false);
                UpdateUserSession(response);

                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            catch (HttpRequestException httpEx)
            {
                return Json(new { success = false, message = "Lỗi khi gọi dịch vụ nhận diện khuôn mặt: " + httpEx.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Đã có lỗi xảy ra phía máy chủ. " + ex.Message });
            }
        }

        // Xử lý đăng nhập bằng Google
        [HttpPost]
        public async Task<IActionResult> GoogleAuth([FromBody] GoogleApiLoginRequestDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.IdToken))
            {
                return Json(new { success = false, message = "Google Token không hợp lệ." });
            }

            try
            {
                var response = await _userService.LoginWithGoogleAsync(request);

                if (response == null)
                {
                    return Json(new { success = false, message = response?.Message ?? "Đăng nhập bằng Google thất bại." });
                }

                if(response.IsValid == false)
                {
                    return Json(new { success = false, message = response.Message });
                }

                _tokenService.SaveTokensToCookies(response, false);
                UpdateUserSession(response);

                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Đã có lỗi xảy ra phía máy chủ. " + ex.Message });
            }
        }

        public IActionResult Login()
        {
            // Đọc Client ID từ IConfiguration và truyền sang View
            var googleClientId = _configuration["GoogleAuth:ClientId"];

            // DEBUG: Log để kiểm tra
            Console.WriteLine($"Google Client ID: {googleClientId}");

            ViewBag.GoogleClientId = googleClientId;
            return View();
        }

        // Xử lý login
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

        // Xử lý đăng xuất
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
                var tempRegisterData = new CustomerTempRegistrationData
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
            var tempRegisterData = HttpContext.Session.GetObjectFromJson<CustomerTempRegistrationData>("TempRegisterData");

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
            var tempRegisterData = HttpContext.Session.GetObjectFromJson<CustomerTempRegistrationData>("TempRegisterData");

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
                redirectUrl = Url.Action("UploadAvatarAndFace", "Common") // Đảm bảo "Common" là tên Controller của bạn
            });
        }

        [HttpGet]
        public async Task<IActionResult> ResendCode()
        {
            // Lấy dữ liệu tạm từ session
            var tempRegisterData = HttpContext.Session.GetObjectFromJson<CustomerTempRegistrationData>("TempRegisterData");

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
        public IActionResult UploadAvatarAndFace()
        {
            return View();
        }

        // Action xử lý việc tải lên ảnh đại diện và ảnh khuôn mặt
        [HttpPost]
        public async Task<IActionResult> CompleteRegistration(
            IFormFile avatar,
            IFormFile faceImage1,
            IFormFile faceImage2,
            IFormFile faceImage3,
            IFormFile faceImage4,
            IFormFile faceImage5)
        {

            // Lấy dữ liệu tạm từ session
            var tempRegisterData = HttpContext.Session.GetObjectFromJson<CustomerTempRegistrationData>("TempRegisterData");

            if (tempRegisterData == null)
            {
                return BadRequest(new { success = false, message = "Phiên đăng ký đã hết hạn. Vui lòng thử lại từ đầu." });
            }

            var faceImages = new List<IFormFile> { faceImage1, faceImage2, faceImage3, faceImage4, faceImage5 };

            // Tạo một DTO từ dữ liệu tạm
            var registerRequestDTO = new CustomerRegisterRequestDTO
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
                FaceImages = faceImages // nhận list ảnh khuôn mặt
            };

            // Gọi service để đăng ký người dùng (API sẽ xử lý lưu file video từ base64)
            var isRegistered = await _userService.CustomerRegisterAsync(registerRequestDTO);

            if (!isRegistered)
            {
                return BadRequest(new { success = false, message = "Đăng ký không thành công. Vui lòng thử lại." });
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
                return StatusCode(500, new { success = false, message = "Đăng ký thành công nhưng không thể tự động đăng nhập. Vui lòng thử đăng nhập thủ công." });
            }

            // Lưu token vào cookie (HttpOnly để bảo mật)
            _tokenService.SaveTokensToCookies(loginResponse, false); // không lưu "Remember Me" sau đăng ký

            // Lưu thông tin người dùng vào session
            UpdateUserSession(loginResponse);

            return Ok(new { success = true, redirectUrl = Url.Action("Index", "Home") });
        }

        // lấy profile của người dùng
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            // Kiểm tra cờ xác thực
            /*if (TempData["ProfileVerified"] == null || (bool)TempData["ProfileVerified"] == false)
            {
                // Nếu chưa xác thực mà cố vào -> Đá về trang chủ và báo lỗi
                TempData["ErrorMessage"] = "Vui lòng xác thực mật khẩu trước khi truy cập thông tin cá nhân.";
                return RedirectToAction("Index", "Home");
            }

            // Xóa cờ xác thực sau khi đã sử dụng
            TempData.Remove("ProfileVerified");*/

            // Get tokens from cookie
            var accessToken = _tokenService.GetAccessTokenFromCookie();

            // Handle missing access token
            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Access Token is missing.";
                return RedirectToAction("Login");
            }

            // Initial service call
            var userProfile = await _userService.GetMyProfileAsync(accessToken);

            if (userProfile == null)
            {
                TempData["ErrorMessage"] = "Could not retrieve your profile. Please log in again.";
                return RedirectToAction("Logout", "Account");
            }

            userProfile.AvatarUrl = !string.IsNullOrEmpty(userProfile.AvatarUrl)
                ? $"{BASE_URL}{userProfile.AvatarUrl}"
                : $"{BASE_URL}/uploads/avatars/default-avatar.png";

            return View(userProfile);
        }

        [HttpGet]
        public IActionResult GetUserHeaderInfo()
        {
            var fullName = HttpContext.Session.GetString("FullName");
            var avatarUrl = HttpContext.Session.GetString("AvatarUrl");

            return Ok(new
            {
                fullName = fullName ?? "User",
                avatarUrl = avatarUrl ?? $"{BASE_URL}/uploads/avatars/default-avatar.png"
            });
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

                UpdateUserSession(updatedUser); // Lưu thông tin người dùng vào session

                await HttpContext.Session.CommitAsync();

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

                UpdateUserSession(updatedUser); // Lưu thông tin người dùng vào session

                await HttpContext.Session.CommitAsync();

                updatedUser.AvatarUrl = !string.IsNullOrEmpty(updatedUser.AvatarUrl)
                    ? $"{BASE_URL}{updatedUser.AvatarUrl}"
                    : $"{BASE_URL}/uploads/avatars/default-avatar.png";

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

        [HttpPost]
        public async Task<IActionResult> VerifyPassword(string password)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Phiên đăng nhập hết hạn." });
            }

            var dto = new VerifyPasswordRequestDTO
            {
                Password = password
            };

            var result = await _userService.VerifyPassword(dto, accessToken);

            if (result.IsSuccess)
            {
                // Đánh dấu Session/TempData là đã xác thực cho Profile
                // Tránh truy cập trái phép vào trang chỉnh sửa profile
                TempData["ProfileVerified"] = true;
                TempData.Keep("ProfileVerified");
                return Ok(new { success = true, message = result.Message ?? "Xác thực thành công." });
            }

            return Ok(new { success = false, message = result.Message ?? "Mật khẩu không chính xác." });
        }

        //public IActionResult GetSignalRToken()
        //{
        //    // Kiểm tra xem người dùng đã đăng nhập vào ứng dụng MVC này hay chưa
        //    // bằng cách kiểm tra một giá trị nào đó trong Session.
        //    // Nếu chưa đăng nhập, session sẽ không có UserId.
        //    if (HttpContext.Session.GetInt32("UserId") == null)
        //    {
        //        // Trả về lỗi 401 Unauthorized để JavaScript biết và dừng lại
        //        return Unauthorized();
        //    }

        //    // Sử dụng ITokenService đã có sẵn để đọc giá trị từ cookie.
        //    // Đây là cách làm nhất quán và đúng đắn.
        //    var token = _tokenService.GetAccessTokenFromCookie();

        //    // Nếu vì lý do nào đó không có token (dù đã đăng nhập)
        //    if (string.IsNullOrEmpty(token))
        //    {
        //        return NotFound(new { message = "Access Token cookie not found." });
        //    }

        //    // Trả về token dưới dạng JSON
        //    return Ok(new { token = token });
        //}
    }

}
