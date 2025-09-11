using UserAPI.DTOs;

namespace UserAPI.Service.Interface
{
    public interface IGoogleAuthService
    {
        Task<GoogleUserInfoDTO> VerifyGoogleTokenAsync(GoogleApiLoginRequestDTO dto);
    }
}
