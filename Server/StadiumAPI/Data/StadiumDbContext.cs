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
                // Dữ liệu mới thêm vào
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
                    Id = 22,
                    Name = "Sân bóng đá K22",
                    Address = "Đường 30 Tháng 4, Xuân Khánh, Ninh Kiều, Cần Thơ",
                    Description = "Sân bóng đá cỏ nhân tạo 7 người, vị trí trung tâm, thuận tiện di chuyển.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0305m,
                    Longitude = 105.7699m,
                    IsApproved = true,
                    CreatedBy = 3,
                    CreatedByUser = 3,
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
                // Sân Bóng Phi Long
                new Courts { Id = 1, StadiumId = 1, Name = "Sân 7 người", SportType = "Bóng đá", PricePerHour = 300000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 2, StadiumId = 1, Name = "Sân 5 người", SportType = "Bóng đá", PricePerHour = 200000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân Cầu Lông Quang Sport
                new Courts { Id = 3, StadiumId = 2, Name = "Sân A", SportType = "Cầu lông", PricePerHour = 50000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 4, StadiumId = 2, Name = "Sân B", SportType = "Cầu lông", PricePerHour = 50000m, IsAvailable = false, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân Tennis 6 Đời 6
                new Courts { Id = 5, StadiumId = 3, Name = "Sân Số 1", SportType = "Tennis", PricePerHour = 100000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 6, StadiumId = 3, Name = "Sân Số 2", SportType = "Tennis", PricePerHour = 100000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân bóng rổ DNC
                new Courts { Id = 7, StadiumId = 4, Name = "Sân chính", SportType = "Bóng rổ", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân Cầu Lông Tambo
                new Courts { Id = 8, StadiumId = 5, Name = "Sân 1", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 9, StadiumId = 5, Name = "Sân 2", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = false, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân Vận Động Cần Thơ
                new Courts { Id = 10, StadiumId = 6, Name = "Sân Chính", SportType = "Bóng đá", PricePerHour = 500000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Hồ bơi Ánh Viên
                new Courts { Id = 11, StadiumId = 7, Name = "Hồ bơi 50m", SportType = "Bơi lội", PricePerHour = 50000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân Tennis 586
                new Courts { Id = 12, StadiumId = 8, Name = "Sân 1", SportType = "Tennis", PricePerHour = 120000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 13, StadiumId = 8, Name = "Sân 2", SportType = "Tennis", PricePerHour = 120000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân Cầu Lông Bưu Điện Cần Thơ
                new Courts { Id = 14, StadiumId = 9, Name = "Sân Số 1", SportType = "Cầu lông", PricePerHour = 60000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 15, StadiumId = 9, Name = "Sân Số 2", SportType = "Cầu lông", PricePerHour = 60000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân Tennis Mường Thanh
                new Courts { Id = 16, StadiumId = 10, Name = "Sân Đơn", SportType = "Tennis", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân bóng chuyền 586
                new Courts { Id = 17, StadiumId = 11, Name = "Sân Chính", SportType = "Bóng chuyền", PricePerHour = 80000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Hồ bơi Vinpearl Cần Thơ
                new Courts { Id = 18, StadiumId = 12, Name = "Hồ bơi ngoài trời", SportType = "Bơi lội", PricePerHour = 80000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân Cầu Lông Hoàng Long
                new Courts { Id = 19, StadiumId = 13, Name = "Sân Số 3", SportType = "Cầu lông", PricePerHour = 75000m, IsAvailable = false, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân bóng đá Anh Tuấn
                new Courts { Id = 20, StadiumId = 14, Name = "Sân 7 người 1", SportType = "Bóng đá", PricePerHour = 280000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân Tennis Công An Cần Thơ
                new Courts { Id = 21, StadiumId = 15, Name = "Sân Công an 1", SportType = "Tennis", PricePerHour = 110000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân bóng rổ WestSide Tây Đô
                new Courts { Id = 22, StadiumId = 16, Name = "Sân chính", SportType = "Bóng rổ", PricePerHour = 100000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Nhà Thi Đấu Vị Thanh
                new Courts { Id = 23, StadiumId = 17, Name = "Sân A", SportType = "Cầu lông", PricePerHour = 50000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 24, StadiumId = 17, Name = "Sân Bóng Chuyền", SportType = "Bóng chuyền", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân bóng đá Vị Thanh
                new Courts { Id = 25, StadiumId = 18, Name = "Sân 7 người 1", SportType = "Bóng đá", PricePerHour = 250000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 26, StadiumId = 18, Name = "Sân 5 người", SportType = "Bóng đá", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Sân Tennis Phú Hưng
                new Courts { Id = 27, StadiumId = 19, Name = "Sân 1", SportType = "Tennis", PricePerHour = 90000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Nhà Thi Đấu Vĩnh Long
                new Courts { Id = 28, StadiumId = 20, Name = "Sân bóng chuyền", SportType = "Bóng chuyền", PricePerHour = 80000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                // Dữ liệu mới thêm vào
                new Courts { Id = 29, StadiumId = 21, Name = "Hồ bơi", SportType = "Bơi lội", PricePerHour = 30000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 30, StadiumId = 22, Name = "Sân 7 người", SportType = "Bóng đá", PricePerHour = 250000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 31, StadiumId = 23, Name = "Sân 1", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 32, StadiumId = 23, Name = "Sân 2", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 33, StadiumId = 24, Name = "Sân chính", SportType = "Bóng chuyền", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 34, StadiumId = 25, Name = "Sân 11 người", SportType = "Bóng đá", PricePerHour = 450000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate }
            );

            // ===== IMAGES =====
            modelBuilder.Entity<StadiumImages>().HasData(
                // Sân Bóng Phi Long
                new StadiumImages { Id = 1, StadiumId = 1, ImageUrl = "img/b1a94c40-8a6e-4686-a56e-edde8ce9a985.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 2, StadiumId = 1, ImageUrl = "https://i.ibb.co/v4B8zS5/san-bong-phi-long-2.jpg", UploadedAt = fixedDate },
                // Sân Cầu Lông Quang Sport
                new StadiumImages { Id = 3, StadiumId = 2, ImageUrl = "https://i.ibb.co/6803z65/san-quang-sport-1.jpg", UploadedAt = fixedDate },
                // Sân Tennis 6 Đời 6
                new StadiumImages { Id = 4, StadiumId = 3, ImageUrl = "https://i.ibb.co/T1H8g64/san-tennis-6-doi-6.jpg", UploadedAt = fixedDate },
                // Sân bóng rổ DNC
                new StadiumImages { Id = 5, StadiumId = 4, ImageUrl = "https://i.ibb.co/S68Jg03/san-ro-dnc-1.jpg", UploadedAt = fixedDate },
                // Sân Cầu Lông Tambo
                new StadiumImages { Id = 6, StadiumId = 5, ImageUrl = "https://i.ibb.co/wB7L3k5/san-tambo.jpg", UploadedAt = fixedDate },
                // Sân Vận Động Cần Thơ
                new StadiumImages { Id = 7, StadiumId = 6, ImageUrl = "https://i.ibb.co/sK085vT/san-van-dong-can-tho.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 8, StadiumId = 6, ImageUrl = "https://i.ibb.co/9V0p3V8/san-van-dong-can-tho-2.jpg", UploadedAt = fixedDate },
                // Hồ bơi Ánh Viên
                new StadiumImages { Id = 9, StadiumId = 7, ImageUrl = "https://i.ibb.co/0y7Yv83/ho-boi-anh-vien.jpg", UploadedAt = fixedDate },
                // Sân Tennis 586
                new StadiumImages { Id = 10, StadiumId = 8, ImageUrl = "https://i.ibb.co/wN90n7t/san-tennis-586.jpg", UploadedAt = fixedDate },
                // Sân Cầu Lông Bưu Điện Cần Thơ
                new StadiumImages { Id = 11, StadiumId = 9, ImageUrl = "https://i.ibb.co/TmkYf7V/san-buu-dien-can-tho-1.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 12, StadiumId = 10, ImageUrl = "https://i.ibb.co/Xz9tTq8/san-tennis-muong-thanh.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 13, StadiumId = 11, ImageUrl = "https://i.ibb.co/f4g1qQj/san-bong-chuyen-586.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 14, StadiumId = 12, ImageUrl = "https://i.ibb.co/3s682Hn/ho-boi-vinpearl-can-tho.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 15, StadiumId = 13, ImageUrl = "https://i.ibb.co/q5k26L1/san-cau-long-hoang-long.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 16, StadiumId = 14, ImageUrl = "https://i.ibb.co/hK5XjP1/san-bong-anh-tuan.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 17, StadiumId = 15, ImageUrl = "https://i.ibb.co/f4g1qQj/san-tennis-cong-an-ct.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 18, StadiumId = 16, ImageUrl = "https://i.ibb.co/S68Jg03/san-ro-dnc-1.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 19, StadiumId = 14, ImageUrl = "https://i.ibb.co/8Y4B4Gj/san-bong-anh-tuan-2.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 20, StadiumId = 16, ImageUrl = "https://i.ibb.co/q0Vw5L4/san-ro-westside.jpg", UploadedAt = fixedDate },
                // Nhà Thi Đấu Vị Thanh
                new StadiumImages { Id = 21, StadiumId = 17, ImageUrl = "https://i.ibb.co/xMvjX62/nha-thi-dau-vi-thanh.jpg", UploadedAt = fixedDate },
                // Sân bóng đá Vị Thanh
                new StadiumImages { Id = 22, StadiumId = 18, ImageUrl = "https://i.ibb.co/wB7L3k5/san-bong-vi-thanh-hau-giang.jpg", UploadedAt = fixedDate },
                // Sân Tennis Phú Hưng
                new StadiumImages { Id = 23, StadiumId = 19, ImageUrl = "https://i.ibb.co/F8S86P2/san-tennis-phu-hung-hg.jpg", UploadedAt = fixedDate },
                // Nhà Thi Đấu Vĩnh Long
                new StadiumImages { Id = 24, StadiumId = 20, ImageUrl = "https://i.ibb.co/6803z65/nha-thi-dau-vinh-long.jpg", UploadedAt = fixedDate },
                // Dữ liệu mới thêm vào
                new StadiumImages { Id = 25, StadiumId = 21, ImageUrl = "https://i.ibb.co/3s682Hn/ho-boi-minh-phuong.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 26, StadiumId = 22, ImageUrl = "https://i.ibb.co/3k5fH0k/san-bong-k22.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 27, StadiumId = 23, ImageUrl = "https://i.ibb.co/3c675z2/san-cau-long-win-sport.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 28, StadiumId = 24, ImageUrl = "https://i.ibb.co/3c675z2/san-bong-chuyen-bai-bien.jpg", UploadedAt = fixedDate },
                new StadiumImages { Id = 29, StadiumId = 25, ImageUrl = "https://i.ibb.co/3c675z2/san-bong-dhct.jpg", UploadedAt = fixedDate }
            );
        }
    }
}