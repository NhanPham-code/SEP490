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

        public void SaveTokensToCookies(LoginResponseDTO response, bool rememberMe)
        {
            // 1. Thiết lập chung cho các cookie cần bảo mật (chứa token)
            var secureCookieOptions = new CookieOptions
            {
                HttpOnly = true, // Quan trọng: Ngăn JavaScript truy cập -> chống XSS
                Secure = true,   // Chỉ gửi qua HTTPS
                SameSite = SameSiteMode.Strict // Chống CSRF
            };

            // 2. Thiết lập cho cookie chứa thông tin công khai (thời gian hết hạn)
            var publicCookieOptions = new CookieOptions
            {
                HttpOnly = false, // Cho phép JavaScript đọc nếu cần (ví dụ: để hiển thị thông báo sắp hết hạn)
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            // 3. Xử lý thời gian sống của cookie
            if (rememberMe)
            {
                var refreshTokenExpiry = DateTime.UtcNow.AddDays(7); // Ví dụ: Refresh token sống 7 ngày
                secureCookieOptions.Expires = refreshTokenExpiry; // Cho RefreshToken sống cùng thời gian
                publicCookieOptions.Expires = refreshTokenExpiry; // Các cookie khác cũng nên sống tương đương
            }
            // Nếu không "Remember Me", không set Expires, chúng sẽ trở thành session cookies
            // và bị xóa khi đóng trình duyệt. Đây là hành vi mặc định và đúng đắn.

            // 4. Lưu các cookie
            _httpContextAccessor.HttpContext?.Response.Cookies.Append("AccessToken", response.AccessToken!, secureCookieOptions);
            _httpContextAccessor.HttpContext?.Response.Cookies.Append("RefreshToken", response.RefreshToken!, secureCookieOptions);

            // 5. LƯU COOKIE THỜI GIAN HẾT HẠN (QUAN TRỌNG NHẤT)
            // Dùng định dạng chuẩn ISO 8601 ("o") để đảm bảo không lỗi văn hóa (culture) khi parse
            _httpContextAccessor.HttpContext?.Response.Cookies.Append(
                "AccessTokenExpiresAt",
                response.AccessTokenExpiresAt.ToString("o"),
                publicCookieOptions
            );

            // Tùy chọn: Lưu trạng thái "Remember Me" để middleware biết cách đặt hạn cho cookie mới
            if (rememberMe)
            {
                _httpContextAccessor.HttpContext?.Response.Cookies.Append("RememberMe", "true", publicCookieOptions);
            }
            else
            {
                // Xóa cookie này nếu người dùng không chọn "Remember Me" trong lần đăng nhập mới nhất
                _httpContextAccessor.HttpContext?.Response.Cookies.Delete("RememberMe");
            }
        }

        // Phương thức để xóa token
        public void ClearTokens()
        {
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete("AccessToken");
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete("RefreshToken");
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete("AccessTokenExpiresAt");
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete("RememberMe");
        }
    }
}
