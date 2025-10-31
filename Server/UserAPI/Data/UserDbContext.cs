using Microsoft.EntityFrameworkCore;
using UserAPI.Model;
using System.Security.Cryptography;
using System.Text;

namespace UserAPI.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public DbSet<BiometricCredential> BiometricCredentials { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- GIÁ TRỊ TĨNH CHO MẬT KHẨU 'nhan123@' ---
            // Các giá trị này được tạo ra một lần và giữ nguyên để đảm bảo model không thay đổi.
            byte[] passwordSalt = new byte[] {
                0x09, 0xF1, 0x40, 0x7A, 0xC0, 0xA2, 0xAE, 0x67, 0xB3, 0xE5, 0xCC, 0x86, 0x40, 0x7B, 0x37, 0x48,
                0x28, 0x6F, 0xA5, 0xB6, 0x33, 0x81, 0xDE, 0x1E, 0xAB, 0x75, 0x3B, 0xE8, 0x23, 0xEA, 0xAC, 0x56,
                0x27, 0x1F, 0xB4, 0x4A, 0xEA, 0x3B, 0x1C, 0xE1, 0x1B, 0x3B, 0xBE, 0xC1, 0xAE, 0x99, 0x2D, 0x10,
                0xB4, 0x28, 0x97, 0x25, 0xA9, 0x96, 0x8E, 0xE6, 0x4D, 0x6B, 0x47, 0x6F, 0x52, 0xA2, 0x86, 0x93,
                0xB5, 0x12, 0x38, 0xAA, 0xC6, 0xB7, 0xBF, 0x2B, 0xF5, 0x3A, 0xAB, 0x45, 0xFB, 0xCC, 0x94, 0x4D,
                0x03, 0xD1, 0x6B, 0x2D, 0xDE, 0x33, 0x9D, 0x06, 0x43, 0x93, 0xF4, 0x97, 0xE2, 0x8C, 0xCC, 0x9A,
                0x43, 0x2E, 0x11, 0x8A, 0x60, 0x0F, 0xC5, 0xDB, 0xE0, 0x5A, 0x13, 0x2E, 0xAF, 0x52, 0x73, 0xCB,
                0x43, 0x66, 0x5E, 0xF2, 0xEE, 0x30, 0xE8, 0x65, 0x53, 0x43, 0x19, 0x72, 0x22, 0xDB, 0x3F, 0x80
            };
            byte[] passwordHash = new byte[] {
                0xC5, 0x44, 0x83, 0xC4, 0xE0, 0x89, 0x2E, 0xB0, 0xE2, 0xB8, 0xD1, 0xFD, 0xD3, 0xB2, 0x01, 0x29,
                0xDF, 0x7F, 0x8C, 0xC2, 0xEC, 0x1F, 0xFA, 0xCC, 0xD5, 0xBC, 0x3D, 0xB5, 0x00, 0x19, 0xBD, 0xA8,
                0xF6, 0x49, 0x13, 0x08, 0x88, 0x65, 0x70, 0xAE, 0x37, 0x09, 0x37, 0x29, 0xFD, 0xFE, 0xA8, 0xFA,
                0xFD, 0x91, 0xF4, 0xF0, 0xCF, 0x22, 0x3C, 0x8E, 0x67, 0x49, 0x97, 0xBF, 0x6A, 0xF6, 0xE9, 0x3C
            };

            var fixedDate = new DateTime(2024, 06, 01, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FullName = "Chủ Sân Một", Email = "stadium.manager1@example.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = "StadiumManager", Address = "123 Đường A, Cần Thơ", PhoneNumber = "0901111111", IsActive = true, CreatedDate = fixedDate, UpdatedDate = fixedDate },
                new User { UserId = 2, FullName = "Chủ Sân Hai", Email = "stadium.manager2@example.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = "StadiumManager", Address = "456 Đường B, Cần Thơ", PhoneNumber = "0902222222", IsActive = true, CreatedDate = fixedDate, UpdatedDate = fixedDate },
                new User { UserId = 3, FullName = "Chủ Sân Ba", Email = "stadium.manager3@example.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = "StadiumManager", Address = "789 Đường C, Cần Thơ", PhoneNumber = "0903333333", IsActive = true, CreatedDate = fixedDate, UpdatedDate = fixedDate },
                new User { UserId = 4, FullName = "Chủ Sân Bốn", Email = "stadium.manager4@example.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = "StadiumManager", Address = "101 Đường D, Cần Thơ", PhoneNumber = "0904444444", IsActive = true, CreatedDate = fixedDate, UpdatedDate = fixedDate },
                new User { UserId = 5, FullName = "Admin User", Email = "admin@example.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = "Admin", Address = "1 Admin Street, System", PhoneNumber = "0905555555", IsActive = true, CreatedDate = fixedDate, UpdatedDate = fixedDate },
                new User { UserId = 2006, FullName = "Phạm Hiền Nhân", Email = "phamhiennhan3105@gmail.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = "Customer", Address = "2006 Đường E, Cần Thơ", PhoneNumber = "09020062006", IsActive = true, CreatedDate = fixedDate, UpdatedDate = fixedDate }
            );

            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId);
        }
    }
}