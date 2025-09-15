using DTOs.UserDTO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Middlewares
{
    public class TokenSessionMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly string BASE_URL = "https://localhost:7136"; // Nên lấy từ appsettings.json

        public TokenSessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserService userService, ITokenService tokenService)
        {
            // 1. Tối ưu: Nếu đã có session, đi tiếp và không làm gì cả.
            if (context.Session.Keys.Contains("UserId"))
            {
                await _next(context);
                return;
            }

            // 2. Nếu không có session, kiểm tra cookie để tìm access token
            var accessToken = tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                // Không có session, cũng không có token -> người dùng chưa đăng nhập.
                await _next(context);
                return;
            }

            // 3. Đã có Access Token, thử lấy thông tin người dùng
            var userProfile = await userService.GetMyProfileAsync(accessToken);

            // 4. Kịch bản: Access Token hết hạn, nhưng có Refresh Token
            if (userProfile == null)
            {
                var refreshToken = tokenService.GetRefreshTokenFromCookie();
                if (!string.IsNullOrEmpty(refreshToken))
                {
                    try
                    {
                        // Gọi API để làm mới token
                        var newTokens = await userService.RefreshTokenAsync(new RefreshTokenRequestDTO { AccessToken = accessToken, RefreshToken = refreshToken });

                        // Suy luận `rememberMe` là true vì Refresh Token vẫn còn tồn tại
                        bool wasRememberMe = true;
                        tokenService.SaveTokensToCookies(newTokens, wasRememberMe);

                        // Lấy lại profile với token mới
                        userProfile = await userService.GetMyProfileAsync(newTokens.AccessToken);
                    }
                    catch (Exception) // Refresh thất bại (VD: refresh token cũng hết hạn)
                    {
                        tokenService.ClearTokens(); // Dọn dẹp cookie hỏng để tránh lặp lại lỗi
                    }
                }
            }

            // 5. Kịch bản: Lấy được profile thành công (dù là lần đầu hay sau khi refresh)
            if (userProfile != null)
            {
                // Lưu thông tin user vào Session (đường dẫn ảnh đầy đủ)
                var avatarFullUrl = !string.IsNullOrEmpty(userProfile.AvatarUrl)
                    ? $"{BASE_URL}{userProfile.AvatarUrl}"
                    : $"{BASE_URL}/avatars/default-avatar.png";

                context.Session.SetInt32("UserId", userProfile.UserId);
                context.Session.SetString("FullName", userProfile.FullName ?? "User");
                context.Session.SetString("AvatarUrl", avatarFullUrl);
            }

            // 6. Luôn gọi middleware tiếp theo trong pipeline
            await _next(context);
        }
    }
}
