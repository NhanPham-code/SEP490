using Microsoft.EntityFrameworkCore;
using StadiumAPI.Models;
using StadiumAPI.DTOs;
using System;

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

            var fixedDate = new DateTime(2025, 8, 14, 10, 0, 0);

            // ===== STADIUMS =====
            modelBuilder.Entity<Stadiums>().HasData(
                new Stadiums
                {
                    Id = 1,
                    Name = "Sân Bóng Phi Long",
                    Address = "Đường Cách Mạng Tháng Tám, Bình Thủy, Cần Thơ",
                    Description = "Sân bóng đá cỏ nhân tạo chất lượng cao với hệ thống đèn LED hiện đại.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0528m,
                    Longitude = 105.7725m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 2,
                    Name = "Sân Cầu Lông Quang Sport",
                    Address = "Số 45 Cách Mạng Tháng Tám, Cái Khế, Bình Thủy, Cần Thơ",
                    Description = "Cụm sân cầu lông rộng rãi, có hệ thống ánh sáng tốt và dịch vụ chuyên nghiệp.",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0401m,
                    Longitude = 105.7684m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 3,
                    Name = "Sân Tennis 6 Đời 6",
                    Address = "Đường Nguyễn Đệ, An Hòa, Ninh Kiều, Cần Thơ",
                    Description = "Sân tennis tiêu chuẩn, phù hợp cho người mới bắt đầu và cả vận động viên chuyên nghiệp.",
                    OpenTime = new TimeSpan(5, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0381m,
                    Longitude = 105.7788m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 4,
                    Name = "Sân bóng rổ DNC",
                    Address = "168 Nguyễn Văn Cừ Nối Dài, An Bình, Ninh Kiều, Cần Thơ",
                    Description = "Sân bóng rổ rộng rãi với mặt sân và vành rổ đạt chuẩn, thích hợp cho việc tập luyện và thi đấu.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.0163m,
                    Longitude = 105.7539m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 5,
                    Name = "Sân Cầu Lông Tambo",
                    Address = "Số 15A/1 Hẻm 51, Đường 3-2, An Khánh, Ninh Kiều, Cần Thơ",
                    Description = "Sân cầu lông trong nhà với hệ thống chiếu sáng và không gian sạch sẽ.",
                    OpenTime = new TimeSpan(5, 0, 0),
                    CloseTime = new TimeSpan(21, 30, 0),
                    Latitude = 10.0249m,
                    Longitude = 105.7687m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 6,
                    Name = "Sân Vận Động Cần Thơ",
                    Address = "Đường Lê Lợi, Cái Khế, Ninh Kiều, Cần Thơ",
                    Description = "Sân vận động đa năng lớn nhất khu vực, phù hợp cho nhiều sự kiện thể thao lớn.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.0396m,
                    Longitude = 105.7725m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 7,
                    Name = "Hồ bơi Ánh Viên",
                    Address = "Số 9 Nguyễn Đệ, An Hoà, Bình Thủy, Cần Thơ",
                    Description = "Hồ bơi đạt chuẩn quốc gia, sạch sẽ và an toàn, phù hợp cho cả người lớn và trẻ em.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(20, 0, 0),
                    Latitude = 10.0381m,
                    Longitude = 105.7788m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 8,
                    Name = "Sân Tennis 586",
                    Address = "Phú Thứ, Cái Răng, Cần Thơ",
                    Description = "Cụm sân tennis với mặt sân chất lượng cao, phục vụ luyện tập và thi đấu.",
                    OpenTime = new TimeSpan(5, 30, 0),
                    CloseTime = new TimeSpan(21, 30, 0),
                    Latitude = 10.0094m,
                    Longitude = 105.7877m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 9,
                    Name = "Sân Cầu Lông Bưu Điện Cần Thơ",
                    Address = "79 Trần Phú, Cái Khế, Ninh Kiều, Cần Thơ",
                    Description = "Sân cầu lông trong nhà với không gian rộng rãi, thoáng mát, thích hợp cho việc tập luyện và thi đấu.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0331m,
                    Longitude = 105.7770m,
                    IsApproved = true,
                    CreatedBy = 2,
                    CreatedByUser = 2,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 10,
                    Name = "Sân Tennis Mường Thanh",
                    Address = "Cái Khế, Ninh Kiều, Cần Thơ",
                    Description = "Sân tennis thuộc khuôn viên khách sạn Mường Thanh, đạt tiêu chuẩn quốc tế, có đèn chiếu sáng ban đêm.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(23, 0, 0),
                    Latitude = 10.0347m,
                    Longitude = 105.7761m,
                    IsApproved = true,
                    CreatedBy = 3,
                    CreatedByUser = 3,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 11,
                    Name = "Sân bóng chuyền 586",
                    Address = "96 Chu Văn An, An Khánh, Ninh Kiều, Cần Thơ",
                    Description = "Sân bóng chuyền ngoài trời, là nơi giao lưu của các đội bóng mạnh trong khu vực.",
                    OpenTime = new TimeSpan(5, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.0240m,
                    Longitude = 105.7725m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 12,
                    Name = "Hồ bơi Vinpearl Cần Thơ",
                    Address = "209 Đường 30 Tháng 4, Xuân Khánh, Ninh Kiều, Cần Thơ",
                    Description = "Hồ bơi trong nhà và ngoài trời tại khách sạn 5 sao, phục vụ cả khách lưu trú và khách lẻ.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0343m,
                    Longitude = 105.7758m,
                    IsApproved = true,
                    CreatedBy = 4,
                    CreatedByUser = 4,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 13,
                    Name = "Sân Cầu Lông Hoàng Long",
                    Address = "Hẻm liên tổ 4-5, Hưng Lợi, Ninh Kiều, Cần Thơ",
                    Description = "Sân cầu lông tư nhân, có nhiều sân con, không gian thoáng đãng.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0152m,
                    Longitude = 105.7629m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 14,
                    Name = "Sân bóng đá Anh Tuấn",
                    Address = "37 Đường B3, Hưng Lợi, Ninh Kiều, Cần Thơ",
                    Description = "Sân bóng đá cỏ nhân tạo 7 người, là địa điểm quen thuộc của các đội bóng phong trào.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(22, 30, 0),
                    Latitude = 10.0195m,
                    Longitude = 105.7620m,
                    IsApproved = true,
                    CreatedBy = 2,
                    CreatedByUser = 2,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 15,
                    Name = "Sân Tennis Công An Cần Thơ",
                    Address = "Đường Trần Phú, Cái Khế, Ninh Kiều, Cần Thơ",
                    Description = "Sân tennis thuộc khu vực Công an thành phố, chất lượng tốt, có hệ thống đèn.",
                    OpenTime = new TimeSpan(5, 30, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.0315m,
                    Longitude = 105.7765m,
                    IsApproved = true,
                    CreatedBy = 3,
                    CreatedByUser = 3,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 16,
                    Name = "Sân bóng rổ WestSide Tây Đô",
                    Address = "Khu dân cư Hậu Thạnh Mỹ, Lê Bình, Cái Răng, Cần Thơ",
                    Description = "Sân bóng rổ ngoài trời, rộng rãi, thường xuyên tổ chức các giải đấu phong trào.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.0035m,
                    Longitude = 105.7876m,
                    IsApproved = true,
                    CreatedBy = 4,
                    CreatedByUser = 4,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 17,
                    Name = "Nhà Thi Đấu Vị Thanh",
                    Address = "Quốc lộ 61, Vị Tân, Vị Thanh, Hậu Giang",
                    Description = "Nhà thi đấu đa năng, tổ chức các môn thể thao trong nhà như bóng chuyền, cầu lông, bóng rổ.",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 9.7761m,
                    Longitude = 105.4746m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 18,
                    Name = "Sân bóng đá Vị Thanh",
                    Address = "Đường 19/8, Vị Tân, Vị Thanh, Hậu Giang",
                    Description = "Sân bóng đá cỏ nhân tạo chất lượng cao, thường xuyên tổ chức các giải đấu phong trào tại Hậu Giang.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 9.7825m,
                    Longitude = 105.4851m,
                    IsApproved = true,
                    CreatedBy = 2,
                    CreatedByUser = 2,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 19,
                    Name = "Sân Tennis Phú Hưng",
                    Address = "Phường 7, Vị Thanh, Hậu Giang",
                    Description = "Cụm sân tennis tiêu chuẩn, có đèn chiếu sáng ban đêm.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 9.7912m,
                    Longitude = 105.4820m,
                    IsApproved = true,
                    CreatedBy = 3,
                    CreatedByUser = 3,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 20,
                    Name = "Nhà Thi Đấu Vĩnh Long",
                    Address = "Đường 1/5, Phường 1, Vĩnh Long",
                    Description = "Nhà thi đấu trung tâm tỉnh Vĩnh Long, thường tổ chức các sự kiện thể thao lớn.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(21, 30, 0),
                    Latitude = 10.2458m,
                    Longitude = 105.9723m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 21,
                    Name = "Hồ bơi Minh Phương",
                    Address = "32P Trương Vĩnh Nguyên, Hưng Phú, Cái Răng, Cần Thơ",
                    Description = "Hồ bơi ngoài trời sạch sẽ, có khu vực riêng cho trẻ em và người lớn.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(20, 0, 0),
                    Latitude = 10.0165m,
                    Longitude = 105.7879m,
                    IsApproved = true,
                    CreatedBy = 2,
                    CreatedByUser = 2,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 23,
                    Name = "Sân Cầu Lông Win Sport",
                    Address = "21 Phạm Hùng, Ba Láng, Cái Răng, Cần Thơ",
                    Description = "Cụm sân cầu lông hiện đại, hệ thống ánh sáng tốt, có ghế chờ cho người chơi.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0121m,
                    Longitude = 105.7954m,
                    IsApproved = true,
                    CreatedBy = 4,
                    CreatedByUser = 4,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 24,
                    Name = "Sân bóng chuyền bãi biển Cần Thơ",
                    Address = "Khu du lịch sinh thái Cồn Ấu, Hưng Phú, Cái Răng, Cần Thơ",
                    Description = "Sân bóng chuyền bãi biển tiêu chuẩn, không gian thoáng đãng.",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(18, 0, 0),
                    Latitude = 10.0289m,
                    Longitude = 105.7997m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedByUser = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new Stadiums
                {
                    Id = 25,
                    Name = "Sân bóng đá Đại học Cần Thơ",
                    Address = "Đường 3 Tháng 2, Xuân Khánh, Ninh Kiều, Cần Thơ",
                    Description = "Sân bóng đá 11 người của Trường Đại học Cần Thơ, phục vụ sinh viên và cộng đồng.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(20, 0, 0),
                    Latitude = 10.0299m,
                    Longitude = 105.7702m,
                    IsApproved = true,
                    CreatedBy = 2,
                    CreatedByUser = 2,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                }
            );

            // ===== COURTS =====
            modelBuilder.Entity<Courts>().HasData(
                new Courts { Id = 1, StadiumId = 1, Name = "Sân 7 người", SportType = "Bóng đá", PricePerHour = 300000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 2, StadiumId = 1, Name = "Sân 5 người", SportType = "Bóng đá", PricePerHour = 200000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 3, StadiumId = 2, Name = "Sân A", SportType = "Cầu lông", PricePerHour = 50000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 4, StadiumId = 2, Name = "Sân B", SportType = "Cầu lông", PricePerHour = 50000m, IsAvailable = false, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 5, StadiumId = 3, Name = "Sân Số 1", SportType = "Tennis", PricePerHour = 100000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 6, StadiumId = 3, Name = "Sân Số 2", SportType = "Tennis", PricePerHour = 100000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 7, StadiumId = 4, Name = "Sân chính", SportType = "Bóng rổ", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 8, StadiumId = 5, Name = "Sân 1", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 9, StadiumId = 5, Name = "Sân 2", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = false, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 10, StadiumId = 6, Name = "Sân Chính", SportType = "Bóng đá", PricePerHour = 500000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 11, StadiumId = 7, Name = "Hồ bơi 50m", SportType = "Bơi lội", PricePerHour = 50000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 12, StadiumId = 8, Name = "Sân 1", SportType = "Tennis", PricePerHour = 120000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 13, StadiumId = 8, Name = "Sân 2", SportType = "Tennis", PricePerHour = 120000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 14, StadiumId = 9, Name = "Sân Số 1", SportType = "Cầu lông", PricePerHour = 60000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 15, StadiumId = 9, Name = "Sân Số 2", SportType = "Cầu lông", PricePerHour = 60000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 16, StadiumId = 10, Name = "Sân Đơn", SportType = "Tennis", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 17, StadiumId = 11, Name = "Sân Chính", SportType = "Bóng chuyền", PricePerHour = 80000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 18, StadiumId = 12, Name = "Hồ bơi ngoài trời", SportType = "Bơi lội", PricePerHour = 80000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 19, StadiumId = 13, Name = "Sân Số 3", SportType = "Cầu lông", PricePerHour = 75000m, IsAvailable = false, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 20, StadiumId = 14, Name = "Sân 7 người 1", SportType = "Bóng đá", PricePerHour = 280000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 21, StadiumId = 15, Name = "Sân Công an 1", SportType = "Tennis", PricePerHour = 110000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 22, StadiumId = 16, Name = "Sân chính", SportType = "Bóng rổ", PricePerHour = 100000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 23, StadiumId = 17, Name = "Sân A", SportType = "Cầu lông", PricePerHour = 50000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 24, StadiumId = 17, Name = "Sân Bóng Chuyền", SportType = "Bóng chuyền", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 25, StadiumId = 18, Name = "Sân 7 người 1", SportType = "Bóng đá", PricePerHour = 250000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 26, StadiumId = 18, Name = "Sân 5 người", SportType = "Bóng đá", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 27, StadiumId = 19, Name = "Sân 1", SportType = "Tennis", PricePerHour = 90000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 28, StadiumId = 20, Name = "Sân bóng chuyền", SportType = "Bóng chuyền", PricePerHour = 80000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 29, StadiumId = 21, Name = "Hồ bơi", SportType = "Bơi lội", PricePerHour = 30000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 31, StadiumId = 23, Name = "Sân 1", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 32, StadiumId = 23, Name = "Sân 2", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 33, StadiumId = 24, Name = "Sân chính", SportType = "Bóng chuyền", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 34, StadiumId = 25, Name = "Sân 11 người", SportType = "Bóng đá", PricePerHour = 450000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate }
            );

            // ===== IMAGES =====
            modelBuilder.Entity<StadiumImages>().HasData(
                new StadiumImages { Id = 1, StadiumId = 1, ImageUrl = "img/b1a94c40-8a6e-4686-a56e-edde8ce9a985.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 2, StadiumId = 1, ImageUrl = "img/b1a94c40-8a6e-4686-a56e-edde8ce9a985.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 3, StadiumId = 2, ImageUrl = "img/bb61649d-80de-4dda-bda0-2e5de31b77a6.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 4, StadiumId = 3, ImageUrl = "img/b5768826-c8f4-4af1-9e1f-1dcee9d6ec56.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 5, StadiumId = 2, ImageUrl = "img/ab4060d7-7676-4728-b6bd-c54de7031f16.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 6, StadiumId = 2, ImageUrl = "img/57cd9906-494d-48b9-9448-c446191b295d.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 7, StadiumId = 3, ImageUrl = "img/2647a365-74eb-4c0e-8fc3-2c5c4fd3cda1.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 8, StadiumId = 3, ImageUrl = "img/2a4f38ac-e941-45cc-ad2b-c76d9d37d392.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 9, StadiumId = 4, ImageUrl = "img/874f1c5a-e37a-4f1e-a002-5fcf803e6a03.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 10, StadiumId = 5, ImageUrl = "img/bb5b3b93-05ba-4701-9a56-52a300fe1504.jpeg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 11, StadiumId = 5, ImageUrl = "img/0ebe27dc-12ab-44cd-8ea7-95e234a94e6a.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 12, StadiumId = 5, ImageUrl = "img/e36d13a7-23b3-4bfd-a421-0d370a2313ad.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 13, StadiumId = 6, ImageUrl = "img/12bad99d-2b1b-48bc-a3a2-5b91cf0a9cff.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 14, StadiumId = 6, ImageUrl = "img/adc0fc5e-6260-4a29-9e18-ac508157db11.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 15, StadiumId = 6, ImageUrl = "img/9fc70741-ab78-4396-8165-067736a70416.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 16, StadiumId = 7, ImageUrl = "img/5d9d6396-900d-4f78-84ee-c260d4d91ee9.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 17, StadiumId = 7, ImageUrl = "img/497dc572-6091-4419-bf8c-cafcd3ee9263.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 18, StadiumId = 7, ImageUrl = "img/89da6dac-5053-4870-a3d7-eea22bc3ea67.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 19, StadiumId = 8, ImageUrl = "img/b2f0a4aa-c4e1-45c6-90f2-e14faa85c406.png", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 20, StadiumId = 9, ImageUrl = "img/37d7b03f-34cd-441d-ba51-2ae85c88188a.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 21, StadiumId = 9, ImageUrl = "img/52e1d9bf-2f4f-48fc-a543-7f23e61e1395.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 22, StadiumId = 10, ImageUrl = "img/9f0dc411-87a2-4a2d-b028-69dcf82fae39.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 23, StadiumId = 11, ImageUrl = "img/e1b8daf3-81eb-4bf7-b9c0-522dd9f80838.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 24, StadiumId = 11, ImageUrl = "img/b2c0e10d-5585-46cf-a576-cb24732e1538.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 25, StadiumId = 12, ImageUrl = "img/f71d6ced-8fbc-4890-915a-ac2a971a6b19.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 26, StadiumId = 12, ImageUrl = "img/896651d3-9b0f-47c1-bdfb-ec343e259829.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 27, StadiumId = 12, ImageUrl = "img/9f464a6f-62e9-4326-9734-a1ac85a8b74e.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 28, StadiumId = 13, ImageUrl = "img/ba1b77bf-0ae7-4a44-bf2a-e6d9c31fe6e0.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 29, StadiumId = 13, ImageUrl = "img/2ec2068b-e1d7-48eb-abb6-fd5a1612ec29.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 30, StadiumId = 14, ImageUrl = "img/1c002bd0-f1ab-47c9-8871-87aa55f99d15.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 31, StadiumId = 14, ImageUrl = "img/7c2f592e-9db8-4ad7-b378-ceb4ee75b3db.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 32, StadiumId = 16, ImageUrl = "img/8da36e7f-6699-4da4-9622-da8310ba734b.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 33, StadiumId = 17, ImageUrl = "img/a4b0822d-b2cc-4102-9192-056740ea1e11.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 34, StadiumId = 18, ImageUrl = "img/21a9b32a-bede-4c9b-984f-db32070b4a22.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 35, StadiumId = 19, ImageUrl = "img/364ddf95-6df0-426f-86a1-7923eedc03de.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 36, StadiumId = 20, ImageUrl = "img/93d0cd83-6917-4d56-870c-871c4d63e036.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 37, StadiumId = 21, ImageUrl = "img/3749c185-1c42-4ead-88a1-e88dcfb23dca.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 38, StadiumId = 21, ImageUrl = "img/fc1d6192-449c-4322-bea1-bd8b655d5cdf.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 39, StadiumId = 21, ImageUrl = "img/25e1be93-6df3-4507-a7f7-201e602afa7f.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                                new StadiumImages { Id = 40, StadiumId = 23, ImageUrl = "img/25e1be93-6df3-4507-a7f7-201e602afa7f.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                                                new StadiumImages { Id = 41, StadiumId = 24, ImageUrl = "img/25e1be93-6df3-4507-a7f7-201e602afa7f.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                                                                new StadiumImages { Id = 42, StadiumId = 25, ImageUrl = "img/25e1be93-6df3-4507-a7f7-201e602afa7f.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) }

            );
        }
    }
}