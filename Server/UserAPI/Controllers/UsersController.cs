using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UsersController(IUserService userService, ITokenService tokenService, IGoogleAuthService googleAuthService)
        {
            _userService = userService;
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _googleAuthService = googleAuthService;
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
        [Authorize(Roles = "Customer,StadiumManager,Admin")]
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
    }
}
