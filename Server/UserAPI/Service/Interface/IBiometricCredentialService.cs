using UserAPI.DTOs;
using UserAPI.Model;

namespace UserAPI.Service.Interface
{
    public interface IBiometricCredentialService
    {
        Task<string> GenerateBiometricCredentialAsync(int userId, string deviceId, string? deviceName);
        Task<LoginResponseDTO>LoginWithBiometricAsync(string biometricToken);
        Task DeleteBiometricCredentialAsync(int userId, string deviceId);
    }
}
