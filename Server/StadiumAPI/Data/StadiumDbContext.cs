using Microsoft.EntityFrameworkCore;
using StadiumAPI.DTOs;
using StadiumAPI.Models;
using System;
using System.Collections.Generic;

namespace StadiumAPI.Data
{
    public class StadiumDbContext : DbContext
    {
        public StadiumDbContext(DbContextOptions<StadiumDbContext> options) : base(options)
        {
        }

        public DbSet<Courts> Courts { get; set; }
        public DbSet<CourtRelations> CourtRelations { get; set; }
        public DbSet<Stadiums> Stadiums { get; set; }
        public DbSet<StadiumImages> StadiumImages { get; set; }
        public DbSet<StadiumVideos> StadiumVideos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicitly map tables
            modelBuilder.Entity<Courts>().ToTable("Courts");
            modelBuilder.Entity<Stadiums>().ToTable("Stadiums");
            modelBuilder.Entity<StadiumImages>().ToTable("StadiumImages");
            modelBuilder.Entity<CourtRelations>().ToTable("CourtRelations");
            modelBuilder.Entity<StadiumVideos>().ToTable("StadiumVideos");

            // ===== ADD INDEXES =====
            // Courts: StadiumId, Name
            modelBuilder.Entity<Courts>()
                .HasIndex(c => c.StadiumId)
                .HasDatabaseName("IX_Courts_StadiumId");
            modelBuilder.Entity<Courts>()
                .HasIndex(c => c.Name)
                .HasDatabaseName("IX_Courts_Name");

            // Stadiums: Name, NameUnsigned, AddressUnsigned, IsApproved
            modelBuilder.Entity<Stadiums>()
                .HasIndex(s => s.Name)
                .HasDatabaseName("IX_Stadiums_Name");
            modelBuilder.Entity<Stadiums>()
                .HasIndex(s => s.NameUnsigned)
                .HasDatabaseName("IX_Stadiums_NameUnsigned");
            modelBuilder.Entity<Stadiums>()
                .HasIndex(s => s.AddressUnsigned)
                .HasDatabaseName("IX_Stadiums_AddressUnsigned");
            modelBuilder.Entity<Stadiums>()
                .HasIndex(s => s.IsApproved)
                .HasDatabaseName("IX_Stadiums_IsApproved");

            // StadiumImages: StadiumId
            modelBuilder.Entity<StadiumImages>()
                .HasIndex(si => si.StadiumId)
                .HasDatabaseName("IX_StadiumImages_StadiumId");

            // StadiumVideos: StadiumId
            modelBuilder.Entity<StadiumVideos>()
                .HasIndex(sv => sv.StadiumId)
                .HasDatabaseName("IX_StadiumVideos_StadiumId");

            // CourtRelations: ParentCourtId, ChildCourtId
            modelBuilder.Entity<CourtRelations>()
                .HasIndex(cr => cr.ParentCourtId)
                .HasDatabaseName("IX_CourtRelations_ParentCourtId");
            modelBuilder.Entity<CourtRelations>()
                .HasIndex(cr => cr.ChildCourtId)
                .HasDatabaseName("IX_CourtRelations_ChildCourtId");

            // Courts - Stadium
            modelBuilder.Entity<Courts>()
                .HasOne(c => c.Stadium)
                .WithMany(s => s.Courts)
                .HasForeignKey(c => c.StadiumId)
                .OnDelete(DeleteBehavior.Cascade);

            // StadiumImages - Stadium
            modelBuilder.Entity<StadiumImages>()
                .HasOne(si => si.Stadium)
                .WithMany(s => s.StadiumImages)
                .HasForeignKey(si => si.StadiumId)
                .OnDelete(DeleteBehavior.Cascade);

            // StadiumVideos - Stadium
            modelBuilder.Entity<StadiumVideos>()
                .HasOne(sv => sv.Stadium)
                .WithMany(s => s.StadiumVideos)
                .HasForeignKey(sv => sv.StadiumId)
                .OnDelete(DeleteBehavior.Cascade);

            var fixedDate = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<CourtRelations>()
           .HasOne(cr => cr.ChildCourt)
           .WithMany(c => c.ParentRelations)
           .HasForeignKey(cr => cr.ChildCourtId)
           .OnDelete(DeleteBehavior.Cascade); // Keep cascade for ChildCourtId

            modelBuilder.Entity<CourtRelations>()
                .HasOne(cr => cr.ParentCourt)
                .WithMany(c => c.ChildRelations)
                .HasForeignKey(cr => cr.ParentCourtId)
                .OnDelete(DeleteBehavior.NoAction); // Use NoAction for ParentCourtId

            modelBuilder.Entity<Courts>()
                .HasOne(c => c.Stadium)
                .WithMany(s => s.Courts)
                .HasForeignKey(c => c.StadiumId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust as needed
            // ===== STADIUMS =====
            modelBuilder.Entity<Stadiums>().HasData(
                new Stadiums
                {
                    Id = 1,
                    Name = "Sân Bóng Phi Long",
                    NameUnsigned = "san bong phi long",
                    Address = "Đường Cách Mạng Tháng Tám, Bình Thủy, Cần Thơ",
                    AddressUnsigned = "duong cach mang thang tam, binh thuy, can tho",
                    Description = "Sân bóng đá cỏ nhân tạo chất lượng cao với hệ thống đèn LED hiện đại.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0528m,
                    Longitude = 105.7725m,
                    IsApproved = true,
                    CreatedBy = 3,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 2,
                    Name = "Sân Cầu Lông Quang Sport",
                    NameUnsigned = "san cau long quang sport",
                    Address = "Số 45 Cách Mạng Tháng Tám, Cái Khế, Bình Thủy, Cần Thơ",
                    AddressUnsigned = "so 45 cach mang thang tam, cai khe, binh thuy, can tho",
                    Description = "Cụm sân cầu lông rộng rãi, có hệ thống ánh sáng tốt và dịch vụ chuyên nghiệp.",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0401m,
                    Longitude = 105.7684m,
                    IsApproved = true,
                    CreatedBy = 3,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 3,
                    Name = "Sân Tennis 6 Đời 6",
                    NameUnsigned = "san tennis 6 doi 6",
                    Address = "Đường Nguyễn Đệ, An Hòa, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "duong nguyen de, an hoa, ninh kieu, can tho",
                    Description = "Sân tennis tiêu chuẩn, phù hợp cho người mới bắt đầu và cả vận động viên chuyên nghiệp.",
                    OpenTime = new TimeSpan(5, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0381m,
                    Longitude = 105.7788m,
                    IsApproved = true,
                    CreatedBy = 4,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 4,
                    Name = "Sân bóng rổ DNC",
                    NameUnsigned = "san bong ro dnc",
                    Address = "168 Nguyễn Văn Cừ Nối Dài, An Bình, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "168 nguyen van cu noi dai, an binh, ninh kieu, can tho",
                    Description = "Sân bóng rổ rộng rãi với mặt sân và vành rổ đạt chuẩn, thích hợp cho việc tập luyện và thi đấu.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.0163m,
                    Longitude = 105.7539m,
                    IsApproved = true,
                    CreatedBy = 4,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 5,
                    Name = "Sân Cầu Lông Tambo",
                    NameUnsigned = "san cau long tambo",
                    Address = "Số 15A/1 Hẻm 51, Đường 3-2, An Khánh, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "so 15a/1 hem 51, duong 3-2, an khanh, ninh kieu, can tho",
                    Description = "Sân cầu lông trong nhà với hệ thống chiếu sáng và không gian sạch sẽ.",
                    OpenTime = new TimeSpan(5, 0, 0),
                    CloseTime = new TimeSpan(21, 30, 0),
                    Latitude = 10.0249m,
                    Longitude = 105.7687m,
                    IsApproved = true,
                    CreatedBy = 4,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 6,
                    Name = "Sân Vận Động Cần Thơ",
                    NameUnsigned = "san van dong can tho",
                    Address = "Đường Lê Lợi, Cái Khế, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "duong le loi, cai khe, ninh kieu, can tho",
                    Description = "Sân vận động đa năng lớn nhất khu vực, phù hợp cho nhiều sự kiện thể thao lớn.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.0396m,
                    Longitude = 105.7725m,
                    IsApproved = true,
                    CreatedBy = 8,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 8,
                    Name = "Sân Tennis 586",
                    NameUnsigned = "san tennis 586",
                    Address = "Phú Thứ, Cái Răng, Cần Thơ",
                    AddressUnsigned = "phu thu, cai rang, can tho",
                    Description = "Cụm sân tennis với mặt sân chất lượng cao, phục vụ luyện tập và thi đấu.",
                    OpenTime = new TimeSpan(5, 30, 0),
                    CloseTime = new TimeSpan(21, 30, 0),
                    Latitude = 10.0094m,
                    Longitude = 105.7877m,
                    IsApproved = true,
                    CreatedBy = 8,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 9,
                    Name = "Sân Cầu Lông Bưu Điện Cần Thơ",
                    NameUnsigned = "san cau long buu dien can tho",
                    Address = "79 Trần Phú, Cái Khế, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "79 tran phu, cai khe, ninh kieu, can tho",
                    Description = "Sân cầu lông trong nhà với không gian rộng rãi, thoáng mát, thích hợp cho việc tập luyện và thi đấu.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0331m,
                    Longitude = 105.7770m,
                    IsApproved = true,
                    CreatedBy = 3,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 10,
                    Name = "Sân Tennis Mường Thanh",
                    NameUnsigned = "san tennis muong thanh",
                    Address = "Cái Khế, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "cai khe, ninh kieu, can tho",
                    Description = "Sân tennis thuộc khuôn viên khách sạn Mường Thanh, đạt tiêu chuẩn quốc tế, có đèn chiếu sáng ban đêm.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(23, 0, 0),
                    Latitude = 10.0347m,
                    Longitude = 105.7761m,
                    IsApproved = true,
                    CreatedBy = 3,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 11,
                    Name = "Sân bóng chuyền 586",
                    NameUnsigned = "san bong chuyen 586",
                    Address = "96 Chu Văn An, An Khánh, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "96 chu van an, an khanh, ninh kieu, can tho",
                    Description = "Sân bóng chuyền ngoài trời, là nơi giao lưu của các đội bóng mạnh trong khu vực.",
                    OpenTime = new TimeSpan(5, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.0240m,
                    Longitude = 105.7725m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 13,
                    Name = "Sân Cầu Lông Hoàng Long",
                    NameUnsigned = "san cau long hoang long",
                    Address = "Hẻm liên tổ 4-5, Hưng Lợi, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "hem lien to 4-5, hung loi, ninh kieu, can tho",
                    Description = "Sân cầu lông tư nhân, có nhiều sân con, không gian thoáng đãng.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0152m,
                    Longitude = 105.7629m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 14,
                    Name = "Sân bóng đá Anh Tuấn",
                    NameUnsigned = "san bong da anh tuan",
                    Address = "37 Đường B3, Hưng Lợi, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "37 duong b3, hung loi, ninh kieu, can tho",
                    Description = "Sân bóng đá cỏ nhân tạo 7 người, là địa điểm quen thuộc của các đội bóng phong trào.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(22, 30, 0),
                    Latitude = 10.0195m,
                    Longitude = 105.7620m,
                    IsApproved = true,
                    CreatedBy = 2,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 15,
                    Name = "Sân Tennis Công An Cần Thơ",
                    NameUnsigned = "san tennis cong an can tho",
                    Address = "Đường Trần Phú, Cái Khế, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "duong tran phu, cai khe, ninh kieu, can tho",
                    Description = "Sân tennis thuộc khu vực Công an thành phố, chất lượng tốt, có hệ thống đèn.",
                    OpenTime = new TimeSpan(5, 30, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.0315m,
                    Longitude = 105.7765m,
                    IsApproved = true,
                    CreatedBy = 3,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 16,
                    Name = "Sân bóng rổ WestSide Tây Đô",
                    NameUnsigned = "san bong ro westside tay do",
                    Address = "Khu dân cư Hậu Thạnh Mỹ, Lê Bình, Cái Răng, Cần Thơ",
                    AddressUnsigned = "khu dan cu hau thanh my, le binh, cai rang, can tho",
                    Description = "Sân bóng rổ ngoài trời, rộng rãi, thường xuyên tổ chức các giải đấu phong trào.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.0035m,
                    Longitude = 105.7876m,
                    IsApproved = true,
                    CreatedBy = 4,
      
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 17,
                    Name = "Nhà Thi Đấu Vị Thanh",
                    NameUnsigned = "nha thi dau vi thanh",
                    Address = "Quốc lộ 61, Vị Tân, Vị Thanh, Hậu Giang",
                    AddressUnsigned = "quoc lo 61, vi tan, vi thanh, hau giang",
                    Description = "Nhà thi đấu đa năng, tổ chức các môn thể thao trong nhà như bóng chuyền, cầu lông, bóng rổ.",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 9.7761m,
                    Longitude = 105.4746m,
                    IsApproved = true,
                    CreatedBy = 1,
            
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 18,
                    Name = "Sân bóng đá Vị Thanh",
                    NameUnsigned = "san bong da vi thanh",
                    Address = "Đường 19/8, Vị Tân, Vị Thanh, Hậu Giang",
                    AddressUnsigned = "duong 19/8, vi tan, vi thanh, hau giang",
                    Description = "Sân bóng đá cỏ nhân tạo chất lượng cao, thường xuyên tổ chức các giải đấu phong trào tại Hậu Giang.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 9.7825m,
                    Longitude = 105.4851m,
                    IsApproved = true,
                    CreatedBy = 2,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 19,
                    Name = "Sân Tennis Phú Hưng",
                    NameUnsigned = "san tennis phu hung",
                    Address = "Phường 7, Vị Thanh, Hậu Giang",
                    AddressUnsigned = "phuong 7, vi thanh, hau giang",
                    Description = "Cụm sân tennis tiêu chuẩn, có đèn chiếu sáng ban đêm.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 9.7912m,
                    Longitude = 105.4820m,
                    IsApproved = true,
                    CreatedBy = 3,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 20,
                    Name = "Nhà Thi Đấu Vĩnh Long",
                    NameUnsigned = "nha thi dau vinh long",
                    Address = "Đường 1/5, Phường 1, Vĩnh Long",
                    AddressUnsigned = "duong 1/5, phuong 1, vinh long",
                    Description = "Nhà thi đấu trung tâm tỉnh Vĩnh Long, thường tổ chức các sự kiện thể thao lớn.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(21, 30, 0),
                    Latitude = 10.2458m,
                    Longitude = 105.9723m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 22,
                    Name = "Sân Pickleball Cần Thơ",
                    NameUnsigned = "san pickleball can tho",
                    Address = "Đường 3 Tháng 2, Hưng Lợi, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "duong 3 thang 2, hung loi, ninh kieu, can tho",
                    Description = "Sân Pickleball mới mở, phù hợp cho mọi lứa tuổi.",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(21, 0, 0),
                    Latitude = 10.0240m,
                    Longitude = 105.7725m,
                    IsApproved = true,
                    CreatedBy = 4,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 23,
                    Name = "Sân Cầu Lông Win Sport",
                    NameUnsigned = "san cau long win sport",
                    Address = "21 Phạm Hùng, Ba Láng, Cái Răng, Cần Thơ",
                    AddressUnsigned = "21 pham hung, ba lang, cai rang, can tho",
                    Description = "Cụm sân cầu lông hiện đại, hệ thống ánh sáng tốt, có ghế chờ cho người chơi.",
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0),
                    Latitude = 10.0121m,
                    Longitude = 105.7954m,
                    IsApproved = true,
                    CreatedBy = 4,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 24,
                    Name = "Sân bóng chuyền bãi biển Cần Thơ",
                    NameUnsigned = "san bong chuyen bai bien can tho",
                    Address = "Khu du lịch sinh thái Cồn Ấu, Hưng Phú, Cái Răng, Cần Thơ",
                    AddressUnsigned = "khu du lich sinh thai con au, hung phu, cai rang, can tho",
                    Description = "Sân bóng chuyền bãi biển tiêu chuẩn, không gian thoáng đãng.",
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(18, 0, 0),
                    Latitude = 10.0289m,
                    Longitude = 105.7997m,
                    IsApproved = true,
                    CreatedBy = 1,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                },
                new Stadiums
                {
                    Id = 25,
                    Name = "Sân bóng đá Đại học Cần Thơ",
                    NameUnsigned = "san bong da dai hoc can tho",
                    Address = "Đường 3 Tháng 2, Xuân Khánh, Ninh Kiều, Cần Thơ",
                    AddressUnsigned = "duong 3 thang 2, xuan khanh, ninh kieu, can tho",
                    Description = "Sân bóng đá 11 người của Trường Đại học Cần Thơ, phục vụ sinh viên và cộng đồng.",
                    OpenTime = new TimeSpan(6, 0, 0),
                    CloseTime = new TimeSpan(20, 0, 0),
                    Latitude = 10.0299m,
                    Longitude = 105.7702m,
                    IsApproved = true,
                    CreatedBy = 2,
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate,
                    IsLocked = false
                }
            );

            // ===== COURTS =====
            modelBuilder.Entity<Courts>().HasData(
                new Courts { Id = 1, StadiumId = 1, Name = "Sân 7 người", SportType = "Bóng đá sân 7", PricePerHour = 300000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 2, StadiumId = 1, Name = "Sân 5 người A", SportType = "Bóng đá sân 5", PricePerHour = 200000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 3, StadiumId = 1, Name = "Sân 5 người B", SportType = "Bóng đá sân 5", PricePerHour = 200000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 4, StadiumId = 2, Name = "Sân A", SportType = "Cầu lông", PricePerHour = 50000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 5, StadiumId = 2, Name = "Sân B", SportType = "Cầu lông", PricePerHour = 50000m, IsAvailable = false, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 6, StadiumId = 3, Name = "Sân Số 1", SportType = "Tennis", PricePerHour = 100000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 7, StadiumId = 3, Name = "Sân Số 2", SportType = "Tennis", PricePerHour = 100000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 8, StadiumId = 4, Name = "Sân chính", SportType = "Bóng rổ", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 9, StadiumId = 5, Name = "Sân 1", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 10, StadiumId = 5, Name = "Sân 2", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = false, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 11, StadiumId = 6, Name = "Sân Chính", SportType = "Bóng đá sân 11", PricePerHour = 500000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 12, StadiumId = 8, Name = "Sân 1", SportType = "Tennis", PricePerHour = 120000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 13, StadiumId = 8, Name = "Sân 2", SportType = "Tennis", PricePerHour = 120000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 14, StadiumId = 9, Name = "Sân Số 1", SportType = "Cầu lông", PricePerHour = 60000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 15, StadiumId = 9, Name = "Sân Số 2", SportType = "Cầu lông", PricePerHour = 60000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 16, StadiumId = 10, Name = "Sân Đơn", SportType = "Tennis", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 17, StadiumId = 11, Name = "Sân Chính", SportType = "Bóng chuyền", PricePerHour = 80000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 18, StadiumId = 13, Name = "Sân Số 3", SportType = "Cầu lông", PricePerHour = 75000m, IsAvailable = false, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 19, StadiumId = 14, Name = "Sân 7 người 1", SportType = "Bóng đá sân 7", PricePerHour = 280000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 20, StadiumId = 14, Name = "Sân 5 người A", SportType = "Bóng đá sân 5", PricePerHour = 180000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 21, StadiumId = 14, Name = "Sân 5 người B", SportType = "Bóng đá sân 5", PricePerHour = 180000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 22, StadiumId = 15, Name = "Sân Công an 1", SportType = "Tennis", PricePerHour = 110000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 23, StadiumId = 16, Name = "Sân chính", SportType = "Bóng rổ", PricePerHour = 100000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 24, StadiumId = 17, Name = "Sân A", SportType = "Cầu lông", PricePerHour = 50000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 25, StadiumId = 17, Name = "Sân Bóng Chuyền", SportType = "Bóng chuyền", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 26, StadiumId = 18, Name = "Sân 7 người 1", SportType = "Bóng đá sân 7", PricePerHour = 250000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 27, StadiumId = 18, Name = "Sân 5 người", SportType = "Bóng đá sân 5", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 28, StadiumId = 19, Name = "Sân 1", SportType = "Tennis", PricePerHour = 90000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 29, StadiumId = 20, Name = "Sân bóng chuyền", SportType = "Bóng chuyền", PricePerHour = 80000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 30, StadiumId = 22, Name = "Sân Pickleball 1", SportType = "Pickleball", PricePerHour = 100000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 31, StadiumId = 23, Name = "Sân 1", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 32, StadiumId = 23, Name = "Sân 2", SportType = "Cầu lông", PricePerHour = 70000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 33, StadiumId = 24, Name = "Sân chính", SportType = "Bóng chuyền", PricePerHour = 150000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 34, StadiumId = 25, Name = "Sân 11 người", SportType = "Bóng đá sân 11", PricePerHour = 450000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 35, StadiumId = 25, Name = "Sân 7 người A", SportType = "Bóng đá sân 7", PricePerHour = 300000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
                new Courts { Id = 36, StadiumId = 25, Name = "Sân 7 người B", SportType = "Bóng đá sân 7", PricePerHour = 300000m, IsAvailable = true, CreatedAt = fixedDate, UpdatedAt = fixedDate }
            );

            // ===== COURT RELATIONS =====
            modelBuilder.Entity<CourtRelations>().HasData(
                // Example: Sân 7 người (Id=1) at Sân Bóng Phi Long (StadiumId=1) is parent to two 5-a-side courts (Id=2, Id=3)
                new CourtRelations { Id = 1, ParentCourtId = 1, ChildCourtId = 2 },
                new CourtRelations { Id = 2, ParentCourtId = 1, ChildCourtId = 3 },
                // Example: Sân 7 người 1 (Id=19) at Sân bóng đá Anh Tuấn (StadiumId=14) is parent to two 5-a-side courts (Id=20, Id=21)
                new CourtRelations { Id = 3, ParentCourtId = 19, ChildCourtId = 20 },
                new CourtRelations { Id = 4, ParentCourtId = 19, ChildCourtId = 21 },
                // Example: Sân 11 người (Id=34) at Sân bóng đá Đại học Cần Thơ (StadiumId=25) is parent to two 7-a-side courts (Id=35, Id=36)
                new CourtRelations { Id = 5, ParentCourtId = 34, ChildCourtId = 35 },
                new CourtRelations { Id = 6, ParentCourtId = 34, ChildCourtId = 36 }
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
                new StadiumImages { Id = 16, StadiumId = 8, ImageUrl = "img/b2f0a4aa-c4e1-45c6-90f2-e14faa85c406.png", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 17, StadiumId = 9, ImageUrl = "img/37d7b03f-34cd-441d-ba51-2ae85c88188a.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 18, StadiumId = 9, ImageUrl = "img/52e1d9bf-2f4f-48fc-a543-7f23e61e1395.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 19, StadiumId = 10, ImageUrl = "img/9f0dc411-87a2-4a2d-b028-69dcf82fae39.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 20, StadiumId = 11, ImageUrl = "img/e1b8daf3-81eb-4bf7-b9c0-522dd9f80838.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 21, StadiumId = 11, ImageUrl = "img/b2c0e10d-5585-46cf-a576-cb24732e1538.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 22, StadiumId = 13, ImageUrl = "img/ba1b77bf-0ae7-4a44-bf2a-e6d9c31fe6e0.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 23, StadiumId = 13, ImageUrl = "img/2ec2068b-e1d7-48eb-abb6-fd5a1612ec29.jpg", UploadedAt = new DateTime(2025, 8, 14, 10, 0, 0) },
                new StadiumImages { Id = 24, StadiumId = 14, ImageUrl = "img/1c002bd0-f1ab-47c9-8871-87aa55f99d15.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 25, StadiumId = 14, ImageUrl = "img/7c2f592e-9db8-4ad7-b378-ceb4ee75b3db.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 26, StadiumId = 16, ImageUrl = "img/8da36e7f-6699-4da4-9622-da8310ba734b.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 27, StadiumId = 17, ImageUrl = "img/a4b0822d-b2cc-4102-9192-056740ea1e11.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 28, StadiumId = 18, ImageUrl = "img/21a9b32a-bede-4c9b-984f-db32070b4a22.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 29, StadiumId = 19, ImageUrl = "img/364ddf95-6df0-426f-86a1-7923eedc03de.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 30, StadiumId = 20, ImageUrl = "img/93d0cd83-6917-4d56-870c-871c4d63e036.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 31, StadiumId = 22, ImageUrl = "img/41b18406-815d-4f10-9140-5e3a3c9e6d08.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 32, StadiumId = 23, ImageUrl = "img/25e1be93-6df3-4507-a7f7-201e602afa7f.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 33, StadiumId = 24, ImageUrl = "img/25e1be93-6df3-4507-a7f7-201e602afa7f.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) },
                new StadiumImages { Id = 34, StadiumId = 25, ImageUrl = "img/25e1be93-6df3-4507-a7f7-201e602afa7f.jpg", UploadedAt = new DateTime(2025, 8, 17, 13, 38, 21, 454) }
            );
        }
    }
}