using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.DTOs;
using UserAPI.Model;
using UserAPI.Repository.Interface;
namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<User> GetAllUsers()
        {
            return _context.Users.AsQueryable();
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.UserId);
            if (existingUser == null)
            {
                return null;
            }

            _context.Entry(existingUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<AdminUserStatsDTO> GetAdminUserStatsAsync()
        {
            var now = DateTime.UtcNow;
            var monthStart = new DateTime(now.Year, now.Month, 1);

            var totalUsers = await _context.Users.CountAsync();
            var activeUsers = await _context.Users.CountAsync(u => u.IsActive);
            var bannedUsers = await _context.Users.CountAsync(u => !u.IsActive);
            var newUsersThisMonth = await _context.Users.CountAsync(u => u.CreatedDate >= monthStart);

            return new AdminUserStatsDTO
            {
                TotalUsers = totalUsers,
                ActiveUsers = activeUsers,
                BannedUsers = bannedUsers,
                NewUsersThisMonth = newUsersThisMonth
            };
        }

        public async Task<List<UserEmbeddingDTO>> GetAllUserEmbeddingsAsync()
        {
            // Lấy tất cả người dùng có face embeddings
            var usersWithEmbeddings = await _context.Users
                .Where(u => u.FaceEmbeddingsJson != null && u.FaceEmbeddingsJson != "")
                .Select(u => new { u.UserId, u.Email, u.FaceEmbeddingsJson })
                .ToListAsync();

            // Chuyển đổi sang DTO
            var usersWithEmbeddingsDTO = usersWithEmbeddings.Select(u => new UserEmbeddingDTO
            {
                UserId = u.UserId,
                Email = u.Email,
                FaceEmbeddingsJson = u.FaceEmbeddingsJson
            }).ToList();

            return usersWithEmbeddingsDTO;
        }

        public async Task<UserStatisticsDTO> GetUserStatisticsAsync()
        {
            var utcNow = DateTime.UtcNow;
            var startOfThisMonth = new DateTime(utcNow.Year, utcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var startOfLastMonth = startOfThisMonth.AddMonths(-1);
            var startOf6MonthsAgo = startOfThisMonth.AddMonths(-5);

            // ✅ SỬA LỖI: Gom các truy vấn đếm vào một lần gọi để tránh lỗi concurrency
            var statsSummary = await _context.Users
                .GroupBy(u => 1) // Trick để gom tất cả user vào một nhóm
                .Select(g => new
                {
                    Total = g.Count(),
                    NewThisMonth = g.Count(u => u.CreatedDate >= startOfThisMonth),
                    NewLastMonth = g.Count(u => u.CreatedDate >= startOfLastMonth && u.CreatedDate < startOfThisMonth)
                })
                .FirstOrDefaultAsync();

            // ✅ SỬA LỖI: Thực thi truy vấn này tuần tự, SAU truy vấn trên
            var newUsersLast6Months = await _context.Users
                .Where(u => u.CreatedDate >= startOf6MonthsAgo)
                .GroupBy(u => new { Year = u.CreatedDate.Value.Year, Month = u.CreatedDate.Value.Month })
                .Select(g => new MonthlyCountDto
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                })
                .OrderBy(r => r.Year).ThenBy(r => r.Month)
                .ToListAsync();

            return new UserStatisticsDTO
            {
                TotalUsers = statsSummary?.Total ?? 0,
                NewUsersThisMonth = statsSummary?.NewThisMonth ?? 0,
                NewUsersLastMonth = statsSummary?.NewLastMonth ?? 0,
                NewUsersLast6Months = newUsersLast6Months
            };
        }
    }
}
