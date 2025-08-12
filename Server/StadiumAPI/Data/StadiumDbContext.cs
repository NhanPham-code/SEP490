using Microsoft.EntityFrameworkCore;
using StadiumAPI.Models;
using StadiumAPI.DTOs;

namespace StadiumAPI.Data
{
    public class StadiumDbContext : DbContext
    {
    
            public StadiumDbContext(DbContextOptions<StadiumDbContext> options) : base(options)
            {
            }
            public DbSet<Courts> Courts { get; set; }
            public DbSet<Stadiums> Stadiums { get; set; }
            public DbSet<StadiumImages> StadiumImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Courts>().ToTable("Courts");
            modelBuilder.Entity<Stadiums>().ToTable("Stadiums");
            modelBuilder.Entity<StadiumImages>().ToTable("StadiumImages");

            // Dùng giá trị tĩnh thay cho DateTime.Now để tránh lỗi PendingModelChangesWarning
            var fixedDate = new DateTime(2025, 8, 11, 10, 0, 0);

            // ===== STADIUMS =====
            modelBuilder.Entity<Stadiums>().HasData(
                new Stadiums
                {
                    Id = 1,
                    Name = "Sân Bóng Cỏ Nhân Tạo Nguyễn Văn Cừ",
                    Address = "Nguyễn Văn Cừ, Quận Ninh Kiều, Cần Thơ",
                    Description = "Sân bóng đá cỏ nhân tạo chất lượng cao, phù hợp thi đấu và tập luyện.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.045162m,
                    Longitude = 105.746857m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 2,
                    Name = "Trung Tâm Cầu Lông Lê Lợi",
                    Address = "Số 1 Lê Lợi, Quận Ninh Kiều, Cần Thơ",
                    Description = "Sân cầu lông tiêu chuẩn, phù hợp thi đấu chuyên nghiệp.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.03711m,
                    Longitude = 105.78829m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 3,
                    Name = "Sân Bóng Rổ Hưng Lợi",
                    Address = "Phường Hưng Lợi, Quận Ninh Kiều, Cần Thơ",
                    Description = "Sân bóng rổ ngoài trời, rộng rãi, thoáng mát.",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(20, 0, 0),
                    Latitude = 10.0298m,
                    Longitude = 105.7621m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 4,
                    Name = "Sân Tennis An Bình",
                    Address = "Phường An Bình, Quận Ninh Kiều, Cần Thơ",
                    Description = "Sân tennis tiêu chuẩn với hệ thống đèn ban đêm.",
                    OpenTime = new TimeSpan(5, 30, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0515m,
                    Longitude = 105.7723m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 5,
                    Name = "Sân Bóng Chuyền Cần Thơ University",
                    Address = "Trường Đại học Cần Thơ, Quận Ninh Kiều, Cần Thơ",
                    Description = "Sân bóng chuyền ngoài trời cho sinh viên và cộng đồng.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(18, 30, 0),
                    Latitude = 10.0299m,
                    Longitude = 105.7702m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                }
            );

            // ===== COURTS =====
            modelBuilder.Entity<Courts>().HasData(
                // Stadium 1 - Bóng đá
                new Courts { Id = 1, StadiumId = 1, Name = "Sân Số 1", SportType = "Bóng đá", PricePerHour = 300000, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 2, StadiumId = 1, Name = "Sân Số 2", SportType = "Bóng đá", PricePerHour = 350000, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },

                // Stadium 2 - Cầu lông
                new Courts { Id = 3, StadiumId = 2, Name = "Sân A", SportType = "Cầu lông", PricePerHour = 80000, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 4, StadiumId = 2, Name = "Sân B", SportType = "Cầu lông", PricePerHour = 90000, IsAvailable = false, CreatedAt = fixedDate, UpdatedAt = fixedDate },

                // Stadium 3 - Bóng rổ
                new Courts { Id = 5, StadiumId = 3, Name = "Sân Rổ 1", SportType = "Bóng rổ", PricePerHour = 120000, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },

                // Stadium 4 - Tennis
                new Courts { Id = 6, StadiumId = 4, Name = "Tennis 1", SportType = "Tennis", PricePerHour = 200000, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 7, StadiumId = 4, Name = "Tennis 2", SportType = "Tennis", PricePerHour = 220000, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },

                // Stadium 5 - Bóng chuyền
                new Courts { Id = 8, StadiumId = 5, Name = "Sân Chuyền 1", SportType = "Bóng chuyền", PricePerHour = 100000, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate }
            );

            // ===== IMAGES =====
            modelBuilder.Entity<StadiumImages>().HasData(
                // Stadium 1
                new StadiumImages { Id = 1, StadiumId = 1, ImageUrl = "https://example.com/sanbong-cantho-1.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 2, StadiumId = 1, ImageUrl = "https://example.com/sanbong-cantho-2.jpg", UploadedAt = fixedDate },

                // Stadium 2
                new StadiumImages { Id = 3, StadiumId = 2, ImageUrl = "https://example.com/sancaulong-cantho-1.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 4, StadiumId = 2, ImageUrl = "https://example.com/sancaulong-cantho-2.jpg", UploadedAt = fixedDate },

                // Stadium 3
                new StadiumImages { Id = 5, StadiumId = 3, ImageUrl = "https://example.com/sanro-cantho-1.jpg", UploadedAt = fixedDate },

                // Stadium 4
                new StadiumImages { Id = 6, StadiumId = 4, ImageUrl = "https://example.com/santennis-cantho-1.jpg", UploadedAt = fixedDate },

                // Stadium 5
                new StadiumImages { Id = 7, StadiumId = 5, ImageUrl = "https://example.com/sanchuyen-cantho-1.jpg", UploadedAt = fixedDate }
            );
        }

    }
}
