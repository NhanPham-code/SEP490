using DTOs.UserDTO;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Phương thức này sẽ lấy Access Token từ header của request
        // Đây là cách thông thường khi client gửi token trong header Authorization
        public string? GetAccessTokenFromHeader()
        {
            return _httpContextAccessor.HttpContext?.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();
        }

        // Phương thức này sẽ lấy Access Token từ cookie
        // Đây là cách bạn đã lưu token sau khi đăng nhập
        public string? GetAccessTokenFromCookie()
        {
            return _httpContextAccessor.HttpContext?.Request.Cookies["AccessToken"];
        }

        // Phương thức này sẽ lấy Refresh Token từ cookie
        public string? GetRefreshTokenFromCookie()
        {
            return _httpContextAccessor.HttpContext?.Request.Cookies["RefreshToken"];
        }

        // Phương thức để lưu token vào cookie
        // Bạn có thể chuyển đoạn code lưu cookie từ controller vào đây
        public void SaveTokens(LoginResponseDTO response)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = response.AccessTokenExpiresAt
            };
            _httpContextAccessor.HttpContext?.Response.Cookies.Append("AccessToken", response.AccessToken!, cookieOptions);

            var refreshOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            _httpContextAccessor.HttpContext?.Response.Cookies.Append("RefreshToken", response.RefreshToken!, refreshOptions);
        }

        // Phương thức để xóa token
        public void ClearTokens()
        {
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete("AccessToken");
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete("RefreshToken");
        }
    }
}
