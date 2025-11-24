using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OData.UriParser;
using System.Security.Claims;
using UserAPI.DTOs;
using UserAPI.Service;
using UserAPI.Service.Interface;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IGoogleAuthService _googleAuthService;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _memoryCache;
        private readonly IBiometricCredentialService _biometricCredentialService;

        // Record để lưu trữ trong cache
        public record OtpCacheEntry(string Code, DateTime ExpirationUtc);

        public UsersController(IUserService userService, ITokenService tokenService, IGoogleAuthService googleAuthService, 
            IEmailService emailService, IMemoryCache memoryCache, IBiometricCredentialService biometricCredentialService)
        {
            _userService = userService;
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _googleAuthService = googleAuthService;
            _emailService = emailService;
            _memoryCache = memoryCache;
            _biometricCredentialService = biometricCredentialService;
        }

        /// <sumary>
        /// Lấy thống kê user
        /// api/Users/statistics
        /// </sumary>
        [HttpGet("statistics")]
        public async Task<ActionResult<UserStatisticsDTO>> GetStatistics()
        {
            try
            {
                var statistics = await _userService.GetUserStatisticsAsync();
                return Ok(statistics);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi ở đây nếu cần
                return StatusCode(500, "An internal server error occurred while fetching user statistics.");
            }
        }

        /// <sumary>
        /// Thêm hoặc cập nhật khuôn mặt cho Customer
        /// api/Users/face-embeddings
        /// </sumary>
        [HttpPut("face-embeddings")]
        public async Task<IActionResult> AddOrUpdateFaceEmbeddings([FromForm] FaceImagesDTO request)
        {
            if (request.FaceImages == null || request.FaceImages.Count == 0)
            {
                return BadRequest(new { message = "Cần bổ sung ảnh khuôn mặt." });
            }

            // Lấy userId từ token
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userIdFromToken))
                return Unauthorized(new { message = "Không thể xác thực. " });

            try
            {
                var result = await _userService.AddorUpdateFaceEmbeddings(userIdFromToken, request);
                if (!result)
                {
                    return BadRequest(new { message = "Không thể thêm hoặc cập nhật khuôn mặt." });
                }
                return Ok(new { message = "Khuôn mặt được thêm hoặc cập nhật thành công." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Đăng nhập bằng sinh trắc học (biometric) cho Customer
        /// api/Users/biometric-login
        /// </summary>
        [HttpPost("biometric-login")]
        public async Task<IActionResult> BiometricLogin([FromBody] string biometricToken)
        {
            if (string.IsNullOrEmpty(biometricToken))
            {
                return BadRequest(new { message = "Biometric token is required." });
            }

            var result = await _biometricCredentialService.LoginWithBiometricAsync(biometricToken);
            if (!result.IsValid)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Xóa token đăng nhập bằng sinh trắc học (biometric) cho Customer
        /// api/Users/biometric-delete
        /// </summary>
        [HttpDelete("biometric-delete")]
        public async Task<IActionResult> DeleteBiometricCredential()
        {
            // Lấy userId từ token
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userIdFromToken))
                return Unauthorized(new { message = "Invalid access token" });

            // Lấy deviceId từ header
            var deviceId = Request.Headers["Device-Id"].FirstOrDefault();
            if (string.IsNullOrEmpty(deviceId))
                return BadRequest(new { message = "Device-Id header is required." });

            try
            {
                await _biometricCredentialService.DeleteBiometricCredentialAsync(userIdFromToken, deviceId);
                return Ok(new { message = "Biometric credential deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting biometric credential.", error = ex.Message });
            }
        }

        /// <summary>
        /// Tạo mã đăng nhập bằng sinh trắc học (biometric) cho Customer
        /// api/Users/biometric-token
        /// </summary>
        [HttpGet("biometric-token")]
        public async Task<IActionResult> GenerateBiometricToken() 
        {
            // Lấy userId từ token
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userIdFromToken))
                return Unauthorized(new { message = "Invalid access token" });

            // Lấy deviceId và deviceName từ header
            var deviceId = Request.Headers["Device-Id"].FirstOrDefault();
            var deviceName = Request.Headers["Device-Name"].FirstOrDefault();

            if (string.IsNullOrEmpty(deviceId))
                return BadRequest(new { message = "Device-Id header is required." });

            try
            {
                var biometricToken = await _biometricCredentialService.GenerateBiometricCredentialAsync(userIdFromToken, deviceId, deviceName);
                return Ok(new { biometricToken });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while generating biometric token.", error = ex.Message });
            }
        }

        /// <summary>
        /// Đăng nhập bằng khuôn mặt cho Cusotmer
        /// api/Users/face-login
        /// </summary>
        [HttpPost("face-login")]
        public async Task<IActionResult> FaceLogin([FromForm] AiFaceLoginRequestDTO request)
        {
            if (request.FaceImage == null || request.FaceImage.Length == 0)
            {
                return BadRequest(new { message = "Face image is required." });
            }

            var result = await _userService.LoginWithFaceAsync(request);

            if (!result.IsValid)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Xác thực và Đăng nhập/Đăng ký bằng Google
        /// api/Users/google-auth
        /// </summary>
        [HttpPost("google-auth")]
        public async Task<IActionResult> GoogleAuth([FromBody] GoogleApiLoginRequestDTO request)
        {
            // 1. Xác thực IdToken với Google
            var googleUser = await _googleAuthService.VerifyGoogleTokenAsync(request);
            if (googleUser == null || !googleUser.EmailVerified)
            {
                return BadRequest(new { message = "Invalid Google Token or email not verified." });
            }

            // 2. Gọi service để xử lý logic đăng nhập/đăng ký
            var result = await _userService.LoginOrRegisterWithGoogleAsync(googleUser);

            if (!result.IsValid)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Đăng nhập và cấp access token + refresh token
        /// api/Users/login
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Email and password cannot be empty." });
            }

            var result = await _userService.CheckLoginAsync(request);

            if (!result.IsValid)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Làm mới token khi access token hết hạn
        /// api/Users/refresh-token
        /// </summary>
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.AccessToken) || string.IsNullOrEmpty(request.RefreshToken))
            {
                return BadRequest(new { message = "Access Token or Refresh Token empty." });
            }

            var checkAccessToken = _tokenService.IsValidJwtFormat(request.AccessToken);
            if (!checkAccessToken)
            {
                return BadRequest(new { message = "Invalid access token format." });
            }

            var result = await _userService.RefreshTokenAsync(request);
            if (!result.IsValid)
            {
                return Unauthorized(new { message = result.Message });
            }

            return Ok(result);
        }

        /// <summary>
        /// api/Users/logout
        /// </summary>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequestDTO request)
        {
            // 1. Kiểm tra Access Token và Refresh Token không rỗng
            if (string.IsNullOrEmpty(request.AccessToken) || string.IsNullOrEmpty(request.RefreshToken))
            {
                return BadRequest(new { message = "Access Token or Refresh Token empty." });
            }

            // 3. Lấy phần token sau "Bearer "
            var actualToken = request.AccessToken.Substring("Bearer ".Length).Trim();

            var checkAccessToken = _tokenService.IsValidJwtFormat(actualToken);
            if (!checkAccessToken)
            {
                return BadRequest(new { message = "Invalid access token format." });
            }

            // 4. Gọi service để xử lý logout
            var result = await _userService.LogoutAsync(request);

            // 5. Kiểm tra kết quả trả về từ service
            if (!result.IsValid)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(result);
        }


        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpRequestDTO request)
        {
            // 1. Tạo mã OTP
            var otpCode = new Random().Next(100000, 999999).ToString();
            var cacheKey = $"otp_{request.Email}";
            var expirationTime = TimeSpan.FromMinutes(1); // 60 giây
            var expirationUtc = DateTime.UtcNow.Add(expirationTime);

            // 2. Tạo đối tượng để lưu vào cache
            var cacheEntry = new OtpCacheEntry(otpCode, expirationUtc);

            // 3. Sử dụng SetAbsoluteExpiration để đảm bảo hết hạn đúng 1 phút
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(expirationTime);

            _memoryCache.Set(cacheKey, cacheEntry, cacheEntryOptions);

            // 4. Gửi email
            await _emailService.SendEmailAsync(request.Email, "Mã xác thực của bạn", $"Mã OTP của bạn là: {otpCode}. Mã này sẽ hết hạn sau 1 phút.");

            return Ok(new { message = "Mã OTP đã được gửi đến email của bạn." });
        }

        [HttpPost("verify-otp")]
        public IActionResult VerifyOtp([FromBody] VerifyOtpRequestDTO request)
        {
            if (request.Code.Length != 6 || !int.TryParse(request.Code, out _))
                return BadRequest(new { verified = false, message = "Mã OTP không hợp lệ." });

            var cacheKey = $"otp_{request.Email}";

            // 1. Lấy đối tượng từ cache
            if (!_memoryCache.TryGetValue(cacheKey, out OtpCacheEntry? cachedEntry))
            {
                // Nếu không tìm thấy key trong cache, có nghĩa là mã đã hết hạn hoặc chưa bao giờ tồn tại.
                // Trong cả hai trường hợp, chúng ta đều có thể coi là "hết hạn".
                return Ok(new { verified = false, message = "Mã đã hết hạn." });
            }

            // 2. Kiểm tra xem mã đã hết hạn hay chưa (kiểm tra thủ công)
            if (DateTime.UtcNow > cachedEntry.ExpirationUtc)
            {
                // Mã vẫn còn trong cache nhưng đã quá thời gian, xóa nó đi
                _memoryCache.Remove(cacheKey);
                return Ok(new { verified = false, message = "Mã đã hết hạn." });
            }

            // 3. So sánh mã OTP
            if (cachedEntry.Code == request.Code)
            {
                // Xác thực thành công, xóa key khỏi cache để không thể sử dụng lại
                _memoryCache.Remove(cacheKey);
                return Ok(new { verified = true, message = "Xác thực mã thành công." });
            }
            else
            {
                // Mã không chính xác
                return Ok(new { verified = false, message = "Mã không chính xác." });
            }
        }

        /// <summary>
        /// api/Users/CustomerRegister
        /// </summary>
        [HttpPost("CustomerRegister")]
        public async Task<IActionResult> CustomerRegister([FromForm] CustomerRegisterRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newUser = await _userService.CustomerRegisterAsync(request);
                return Ok(new { message = "Register successful", user = newUser });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while registering user.", error = ex.Message });
            }
        }

        /// <summary>
        /// api/Users/ManagerRegister
        /// </summary>
        [HttpPost("ManagerRegister")]
        public async Task<IActionResult> ManagerRegister([FromForm] StadiumManagerRegisterRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newUser = await _userService.StadiumManagerRegisterAsync(request);
                return Ok(new { message = "Register successful", user = newUser });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while registering user.", error = ex.Message });
            }
        }

        /// <summary>
        /// api/Users/profile
        /// Lấy thông tin người dùng hiện tại (đang đăng nhập)
        /// Lấy bằng userId trong Access Token
        /// </summary>
        [HttpGet("profile")]
        [Authorize(Roles = "Customer,StadiumManager")]
        public async Task<IActionResult> GetUserProfile()
        {
            // lấy userId từ access token trong header
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId) || userId <= 0)
            {
                return BadRequest(new { message = "Invalid user ID." });
            }

            if (userId <= 0)
            {
                return BadRequest(new { message = "Invalid user ID." });
            }

            var user = await _userService.GetUserProfileAsync(userId);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            return Ok(user);
        }

        /// <summary>
        /// api/Users/id
        /// Lấy thông tin người dùng khác
        /// </summary>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOtherUserProfile(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest(new { message = "Invalid user ID." });
            }

            var user = await _userService.GetOtherUserProfileAsync(userId);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            return Ok(user);
        }

        /// <summary>
        /// api/Users/checkEmailExits
        /// </summary>
        [HttpPost("checkEmailExits")]
        public async Task<IActionResult> CheckEmailExists([FromBody] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new { message = "Email cannot be empty." });
            }

            var exists = await _userService.IsEmailExistsAsync(email);
            return Ok(exists);
        }

        /// <summary>
        /// api/Users
        /// </summary>
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { message = "Invalid user ID." });
            }

            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound(new { message = "User not found." });
            }

            return Ok(new { message = "User deleted successfully." });
        }


        [HttpPut("update-profile")]
        [Authorize(Roles = "Customer,StadiumManager")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserProfileDTO dto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Lấy userId từ token
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userIdFromToken))
                return Unauthorized(new { message = "Invalid access token" });

            // So sánh với userId trong DTO
            if (dto.UserId != userIdFromToken)
                return Forbid();

            try
            {
                var updatedUser = await _userService.UpdateUserProfileAsync(dto);
                return Ok(updatedUser);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating profile.", error = ex.Message });
            }
        }

        [HttpPut("update-avatar")]
        [Authorize(Roles = "Customer,StadiumManager")]
        public async Task<IActionResult> UpdateAvatar([FromForm] UpdateAvatarDTO dto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Lấy userId từ token
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userIdFromToken))
                return Unauthorized(new { message = "Invalid access token" });

            // So sánh với userId trong DTO
            if (dto.UserId != userIdFromToken)
                return Forbid();

            try
            {
                var updatedUser = await _userService.UpdateAvatarAsync(dto);
                return Ok(updatedUser);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating avatar.", error = ex.Message });
            }
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _userService.ResetPasswordAsync(dto);
                if (!result)
                {
                    return BadRequest(new { message = "Failed to reset password. Email may not exist." });
                }
                return Ok(new { message = "Password reset successful." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while resetting password.", error = ex.Message });
            }
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetAdminUserStats()
        {
            try
            {
                var stats = await _userService.GetAdminUserStatsAsync();
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching user statistics.", error = ex.Message });
            }
        }

        [HttpPut("ban/{userId}")]
        public async Task<IActionResult> BanUser(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest(new { message = "Invalid user ID." });
            }

            try
            {
                await _userService.BanUserAsync(userId);
                return Ok(new { message = "User banned successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while banning the user.", error = ex.Message });
            }
        }

        [HttpPut("unban/{userId}")]
        public async Task<IActionResult> UnbanUser(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest(new { message = "Invalid user ID." });
            }

            try
            {
                await _userService.UnbanUserAsync(userId);
                return Ok(new { message = "User unbanned successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while unbanning the user.", error = ex.Message });
            }
        }
    }
}
