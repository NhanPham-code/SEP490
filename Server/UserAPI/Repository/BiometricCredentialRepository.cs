using Google;
using UserAPI.Data;
using UserAPI.Model;
using UserAPI.Repository.Interface;

namespace UserAPI.Repository
{
    public class BiometricCredentialRepository : IBiometricCredentialRepository
    {
        private readonly UserDbContext _context;

        public BiometricCredentialRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<BiometricCredential> CreateAsync(BiometricCredential credential)
        {
            var result = await _context.BiometricCredentials.AddAsync(credential);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(int userId, string deviceId)
        {
            var credential = _context.BiometricCredentials
                .FirstOrDefault(c => c.UserId == userId && c.DeviceId == deviceId);
            if (credential == null)
            {
                return false;
            }
            _context.BiometricCredentials.Remove(credential);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BiometricCredential?> GetByTokenAsync(string token)
        {
            var result = await _context.BiometricCredentials
                .FindAsync(token);
            return result;
        }

        public async Task<IEnumerable<BiometricCredential>> GetByUserIdAsync(int userId)
        {
            var result = _context.BiometricCredentials
                .Where(c => c.UserId == userId)
                .AsEnumerable();
            return await Task.FromResult(result);
        }
    }
}
