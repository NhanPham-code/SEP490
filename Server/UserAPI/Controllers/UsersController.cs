using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.UriParser;
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

        public UsersController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        /// <summary>
        /// Đăng nhập và cấp access token + refresh token
        /// api/Users/login
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            if(string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Email and password cannot be empty." });
            }

            var result = await _userService.CheckLoginAsync(request);

            if (!result.IsValid)
            {
                return Unauthorized(new { message = result.Message });
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
        /// api/Users/register
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newUser = await _userService.RegisterAsync(request);
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
        /// api/Users?userId={userId}
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUserById([FromQuery] int userId)
        {
            if (userId <= 0)
            {
                return BadRequest(new { message = "Invalid user ID." });
            }

            var user = await _userService.GetUserByIdAsync(userId);
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

    }
}
