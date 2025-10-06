using UserAPI.Model;

namespace UserAPI.Repository.Interface
{
    public interface IBiometricCredentialRepository
    {
        Task<BiometricCredential?> GetByTokenAsync(string token);
        Task<BiometricCredential> CreateAsync(BiometricCredential credential);
        Task<bool> DeleteAsync(int userId, string deviceId);
        Task<IEnumerable<BiometricCredential>> GetByUserIdAsync(int userId);
    }
}
