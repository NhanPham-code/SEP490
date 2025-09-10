using Google.Apis.Auth;
using Microsoft.SqlServer.Server;
using UserAPI.DTOs;
using UserAPI.Service.Interface;

namespace UserAPI.Service
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly string _googleClientId;

        public GoogleAuthService(IConfiguration configuration)
        {
            // Lấy Client ID từ appsettings.json
            _googleClientId = configuration["GoogleAuth:ClientId"];
            if (string.IsNullOrEmpty(_googleClientId))
            {
                throw new ArgumentNullException("GoogleAuth:ClientId is not configured in appsettings.json");
            }
        }

        public async Task<GoogleUserInfoDTO> VerifyGoogleTokenAsync(GoogleApiLoginRequestDTO dto)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(dto.IdToken, new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { _googleClientId }
                });

                return new GoogleUserInfoDTO
                {
                    GoogleId = payload.Subject,
                    Email = payload.Email,
                    FullName = payload.Name,
                    AvatarUrl = payload.Picture,
                    EmailVerified = payload.EmailVerified
                };
            }
            catch (InvalidJwtException)
            {
                // Token không hợp lệ hoặc đã hết hạn
                return null;
            }
        }
    }
}
