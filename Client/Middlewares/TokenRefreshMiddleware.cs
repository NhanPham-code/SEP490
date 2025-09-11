using DTOs.UserDTO;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;

namespace Middlewares
{
    public class TokenRefreshMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenRefreshMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserService userService, ITokenService tokenService)
        {
            // Lấy access token và thời gian hết hạn từ cookie
            var accessToken = context.Request.Cookies["AccessToken"];
            var accessTokenExpiresAtStr = context.Request.Cookies["AccessTokenExpiresAt"];

            // Chỉ xử lý nếu có token và chưa có header Authorization (tránh xử lý lại)
            if (!string.IsNullOrEmpty(accessToken) &&
                DateTime.TryParse(accessTokenExpiresAtStr, out var accessTokenExpiresAt) &&
                !context.Request.Headers.ContainsKey("Authorization"))
            {
                // Kiểm tra xem token có sắp hết hạn không (ví dụ: còn dưới 60 giây)
                // Hoặc đã hết hạn
                if (accessTokenExpiresAt <= DateTime.UtcNow.AddSeconds(60))
                {
                    var refreshToken = context.Request.Cookies["RefreshToken"];
                    if (!string.IsNullOrEmpty(refreshToken))
                    {
                        try
                        {
                            // Gọi service để lấy token mới
                            var refreshTokenRequest = new RefreshTokenRequestDTO
                            {
                                AccessToken = accessToken,
                                RefreshToken = refreshToken
                            };
                            var response = await userService.RefreshTokenAsync(refreshTokenRequest);
                            if (response != null && response.IsValid)
                            {
                                // Lưu token mới vào cookie
                                // Tham số rememberMe nên được lưu ở đâu đó, ví dụ trong một cookie khác hoặc claim
                                bool rememberMe = context.Request.Cookies.ContainsKey("RememberMe");
                                tokenService.SaveTokensToCookies(response, rememberMe);

                                // Gán access token mới vào header của request hiện tại
                                // để các middleware và controller sau đó có thể xác thực
                                context.Request.Headers.Add("Authorization", "Bearer " + response.AccessToken);
                            }
                            else
                            {
                                // Nếu refresh token không hợp lệ, xóa cookie cũ (đăng xuất)
                                tokenService.ClearTokens();
                            }
                        }
                        catch (Exception)
                        {
                            // Xử lý lỗi khi không thể refresh token
                            tokenService.ClearTokens();
                        }
                    }
                }
                else
                {
                    // Nếu token vẫn còn hạn, gắn nó vào header để xác thực
                    context.Request.Headers.Add("Authorization", "Bearer " + accessToken);
                }
            }

            // Chuyển request cho middleware tiếp theo trong pipeline
            await _next(context);
        }
    }
}
