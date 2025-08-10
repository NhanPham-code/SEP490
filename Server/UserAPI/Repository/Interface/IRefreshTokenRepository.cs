using UserAPI.Model;

namespace UserAPI.Repository.Interface
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetRefreshTokenAsync(int userId, string refreshToken);

        Task CreateRefreshTokenAsync(RefreshToken refreshToken);

        Task UpdateRefreshTokenAsync(RefreshToken refreshToken);

        Task<bool> DeleteRefreshTokenAsync(int userId, string refreshToken);

        Task<bool> DeleteAllRefreshTokenOfUserIdAsync(int userId);

        Task<bool> IsRefreshTokenValidAsync(int userId, string refreshToken);
    }
}
