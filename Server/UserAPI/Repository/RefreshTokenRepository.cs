using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Model;
using UserAPI.Repository.Interface;

namespace UserAPI.Repository
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly UserDbContext _context;

        public RefreshTokenRepository(UserDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<RefreshToken?> GetRefreshTokenAsync(int userId, string refreshToken)
        {
            return await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.UserId == userId && rt.Token == refreshToken);
        }

        public async Task CreateRefreshTokenAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRefreshTokenAsync(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Update(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteRefreshTokenAsync(int userId, string refreshToken)
        {
            var token = await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.UserId == userId && rt.Token == refreshToken);

            if (token == null) return false;

            _context.RefreshTokens.Remove(token);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAllRefreshTokenOfUserIdAsync(int userId)
        {
            var tokens = await _context.RefreshTokens
                .Where(rt => rt.UserId == userId)
                .ToListAsync();

            if (!tokens.Any()) return false;

            _context.RefreshTokens.RemoveRange(tokens);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsRefreshTokenValidAsync(int userId, string refreshToken)
        {
            var token = await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.UserId == userId && rt.Token == refreshToken);

            return token != null && token.ExpiryDate > DateTime.UtcNow;
        }
    }
}
