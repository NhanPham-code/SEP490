using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StadiumAPI.Migrations
{
    /// <inheritdoc />
    public partial class newData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedByUser = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StadiumId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SportType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courts_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StadiumImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StadiumId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StadiumImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StadiumImages_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedAt", "CreatedBy", "CreatedByUser", "Description", "IsApproved", "Latitude", "Longitude", "Name", "OpenTime", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Đường Cách Mạng Tháng Tám, Bình Thủy, Cần Thơ", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân bóng đá cỏ nhân tạo chất lượng cao với hệ thống đèn LED hiện đại.", true, 10.0528m, 105.7725m, "Sân Bóng Phi Long", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Số 45 Cách Mạng Tháng Tám, Cái Khế, Bình Thủy, Cần Thơ", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Cụm sân cầu lông rộng rãi, có hệ thống ánh sáng tốt và dịch vụ chuyên nghiệp.", true, 10.0401m, 105.7684m, "Sân Cầu Lông Quang Sport", new TimeSpan(0, 8, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Đường Nguyễn Đệ, An Hòa, Ninh Kiều, Cần Thơ", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân tennis tiêu chuẩn, phù hợp cho người mới bắt đầu và cả vận động viên chuyên nghiệp.", true, 10.0381m, 105.7788m, "Sân Tennis 6 Đời 6", new TimeSpan(0, 5, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "168 Nguyễn Văn Cừ Nối Dài, An Bình, Ninh Kiều, Cần Thơ", new TimeSpan(0, 21, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân bóng rổ rộng rãi với mặt sân và vành rổ đạt chuẩn, thích hợp cho việc tập luyện và thi đấu.", true, 10.0163m, 105.7539m, "Sân bóng rổ DNC", new TimeSpan(0, 7, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Số 15A/1 Hẻm 51, Đường 3-2, An Khánh, Ninh Kiều, Cần Thơ", new TimeSpan(0, 21, 30, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân cầu lông trong nhà với hệ thống chiếu sáng và không gian sạch sẽ.", true, 10.0249m, 105.7687m, "Sân Cầu Lông Tambo", new TimeSpan(0, 5, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Đường Lê Lợi, Cái Khế, Ninh Kiều, Cần Thơ", new TimeSpan(0, 21, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân vận động đa năng lớn nhất khu vực, phù hợp cho nhiều sự kiện thể thao lớn.", true, 10.0396m, 105.7725m, "Sân Vận Động Cần Thơ", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Số 9 Nguyễn Đệ, An Hoà, Bình Thủy, Cần Thơ", new TimeSpan(0, 20, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Hồ bơi đạt chuẩn quốc gia, sạch sẽ và an toàn, phù hợp cho cả người lớn và trẻ em.", true, 10.0381m, 105.7788m, "Hồ bơi Ánh Viên", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Phú Thứ, Cái Răng, Cần Thơ", new TimeSpan(0, 21, 30, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Cụm sân tennis với mặt sân chất lượng cao, phục vụ luyện tập và thi đấu.", true, 10.0094m, 105.7877m, "Sân Tennis 586", new TimeSpan(0, 5, 30, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "79 Trần Phú, Cái Khế, Ninh Kiều, Cần Thơ", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Sân cầu lông trong nhà với không gian rộng rãi, thoáng mát, thích hợp cho việc tập luyện và thi đấu.", true, 10.0331m, 105.7770m, "Sân Cầu Lông Bưu Điện Cần Thơ", new TimeSpan(0, 7, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Cái Khế, Ninh Kiều, Cần Thơ", new TimeSpan(0, 23, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Sân tennis thuộc khuôn viên khách sạn Mường Thanh, đạt tiêu chuẩn quốc tế, có đèn chiếu sáng ban đêm.", true, 10.0347m, 105.7761m, "Sân Tennis Mường Thanh", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "96 Chu Văn An, An Khánh, Ninh Kiều, Cần Thơ", new TimeSpan(0, 21, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân bóng chuyền ngoài trời, là nơi giao lưu của các đội bóng mạnh trong khu vực.", true, 10.0240m, 105.7725m, "Sân bóng chuyền 586", new TimeSpan(0, 5, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "209 Đường 30 Tháng 4, Xuân Khánh, Ninh Kiều, Cần Thơ", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "Hồ bơi trong nhà và ngoài trời tại khách sạn 5 sao, phục vụ cả khách lưu trú và khách lẻ.", true, 10.0343m, 105.7758m, "Hồ bơi Vinpearl Cần Thơ", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Hẻm liên tổ 4-5, Hưng Lợi, Ninh Kiều, Cần Thơ", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân cầu lông tư nhân, có nhiều sân con, không gian thoáng đãng.", true, 10.0152m, 105.7629m, "Sân Cầu Lông Hoàng Long", new TimeSpan(0, 7, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "37 Đường B3, Hưng Lợi, Ninh Kiều, Cần Thơ", new TimeSpan(0, 22, 30, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Sân bóng đá cỏ nhân tạo 7 người, là địa điểm quen thuộc của các đội bóng phong trào.", true, 10.0195m, 105.7620m, "Sân bóng đá Anh Tuấn", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Đường Trần Phú, Cái Khế, Ninh Kiều, Cần Thơ", new TimeSpan(0, 21, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Sân tennis thuộc khu vực Công an thành phố, chất lượng tốt, có hệ thống đèn.", true, 10.0315m, 105.7765m, "Sân Tennis Công An Cần Thơ", new TimeSpan(0, 5, 30, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Khu dân cư Hậu Thạnh Mỹ, Lê Bình, Cái Răng, Cần Thơ", new TimeSpan(0, 21, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "Sân bóng rổ ngoài trời, rộng rãi, thường xuyên tổ chức các giải đấu phong trào.", true, 10.0035m, 105.7876m, "Sân bóng rổ WestSide Tây Đô", new TimeSpan(0, 7, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Quốc lộ 61, Vị Tân, Vị Thanh, Hậu Giang", new TimeSpan(0, 21, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Nhà thi đấu đa năng, tổ chức các môn thể thao trong nhà như bóng chuyền, cầu lông, bóng rổ.", true, 9.7761m, 105.4746m, "Nhà Thi Đấu Vị Thanh", new TimeSpan(0, 8, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Đường 19/8, Vị Tân, Vị Thanh, Hậu Giang", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Sân bóng đá cỏ nhân tạo chất lượng cao, thường xuyên tổ chức các giải đấu phong trào tại Hậu Giang.", true, 9.7825m, 105.4851m, "Sân bóng đá Vị Thanh", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Phường 7, Vị Thanh, Hậu Giang", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Cụm sân tennis tiêu chuẩn, có đèn chiếu sáng ban đêm.", true, 9.7912m, 105.4820m, "Sân Tennis Phú Hưng", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Đường 1/5, Phường 1, Vĩnh Long", new TimeSpan(0, 21, 30, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Nhà thi đấu trung tâm tỉnh Vĩnh Long, thường tổ chức các sự kiện thể thao lớn.", true, 10.2458m, 105.9723m, "Nhà Thi Đấu Vĩnh Long", new TimeSpan(0, 7, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "32P Trương Vĩnh Nguyên, Hưng Phú, Cái Răng, Cần Thơ", new TimeSpan(0, 20, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Hồ bơi ngoài trời sạch sẽ, có khu vực riêng cho trẻ em và người lớn.", true, 10.0165m, 105.7879m, "Hồ bơi Minh Phương", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "21 Phạm Hùng, Ba Láng, Cái Răng, Cần Thơ", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "Cụm sân cầu lông hiện đại, hệ thống ánh sáng tốt, có ghế chờ cho người chơi.", true, 10.0121m, 105.7954m, "Sân Cầu Lông Win Sport", new TimeSpan(0, 7, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "Khu du lịch sinh thái Cồn Ấu, Hưng Phú, Cái Răng, Cần Thơ", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân bóng chuyền bãi biển tiêu chuẩn, không gian thoáng đãng.", true, 10.0289m, 105.7997m, "Sân bóng chuyền bãi biển Cần Thơ", new TimeSpan(0, 8, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "Đường 3 Tháng 2, Xuân Khánh, Ninh Kiều, Cần Thơ", new TimeSpan(0, 20, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Sân bóng đá 11 người của Trường Đại học Cần Thơ, phục vụ sinh viên và cộng đồng.", true, 10.0299m, 105.7702m, "Sân bóng đá Đại học Cần Thơ", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "CreatedAt", "IsAvailable", "Name", "PricePerHour", "SportType", "StadiumId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 7 người", 300000m, "Bóng đá", 1, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 5 người", 200000m, "Bóng đá", 1, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân A", 50000m, "Cầu lông", 2, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Sân B", 50000m, "Cầu lông", 2, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Số 1", 100000m, "Tennis", 3, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Số 2", 100000m, "Tennis", 3, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân chính", 150000m, "Bóng rổ", 4, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 1", 70000m, "Cầu lông", 5, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Sân 2", 70000m, "Cầu lông", 5, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Chính", 500000m, "Bóng đá", 6, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Hồ bơi 50m", 50000m, "Bơi lội", 7, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 1", 120000m, "Tennis", 8, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 2", 120000m, "Tennis", 8, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Số 1", 60000m, "Cầu lông", 9, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Số 2", 60000m, "Cầu lông", 9, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Đơn", 150000m, "Tennis", 10, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Chính", 80000m, "Bóng chuyền", 11, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Hồ bơi ngoài trời", 80000m, "Bơi lội", 12, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Sân Số 3", 75000m, "Cầu lông", 13, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 7 người 1", 280000m, "Bóng đá", 14, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Công an 1", 110000m, "Tennis", 15, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân chính", 100000m, "Bóng rổ", 16, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân A", 50000m, "Cầu lông", 17, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Bóng Chuyền", 70000m, "Bóng chuyền", 17, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 7 người 1", 250000m, "Bóng đá", 18, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 5 người", 150000m, "Bóng đá", 18, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 1", 90000m, "Tennis", 19, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân bóng chuyền", 80000m, "Bóng chuyền", 20, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Hồ bơi", 30000m, "Bơi lội", 21, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 1", 70000m, "Cầu lông", 23, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 2", 70000m, "Cầu lông", 23, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân chính", 150000m, "Bóng chuyền", 24, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 11 người", 450000m, "Bóng đá", 25, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StadiumImages",
                columns: new[] { "Id", "ImageUrl", "StadiumId", "UploadedAt" },
                values: new object[,]
                {
                    { 1, "img/b1a94c40-8a6e-4686-a56e-edde8ce9a985.jpg", 1, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "img/b1a94c40-8a6e-4686-a56e-edde8ce9a985.jpg", 1, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "img/bb61649d-80de-4dda-bda0-2e5de31b77a6.jpg", 2, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "img/b5768826-c8f4-4af1-9e1f-1dcee9d6ec56.jpg", 3, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "img/ab4060d7-7676-4728-b6bd-c54de7031f16.jpg", 2, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "img/57cd9906-494d-48b9-9448-c446191b295d.jpg", 2, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "img/2647a365-74eb-4c0e-8fc3-2c5c4fd3cda1.jpg", 3, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "img/2a4f38ac-e941-45cc-ad2b-c76d9d37d392.jpg", 3, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "img/874f1c5a-e37a-4f1e-a002-5fcf803e6a03.jpg", 4, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "img/bb5b3b93-05ba-4701-9a56-52a300fe1504.jpeg", 5, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "img/0ebe27dc-12ab-44cd-8ea7-95e234a94e6a.jpg", 5, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "img/e36d13a7-23b3-4bfd-a421-0d370a2313ad.jpg", 5, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "img/12bad99d-2b1b-48bc-a3a2-5b91cf0a9cff.jpg", 6, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "img/adc0fc5e-6260-4a29-9e18-ac508157db11.jpg", 6, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "img/9fc70741-ab78-4396-8165-067736a70416.jpg", 6, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "img/5d9d6396-900d-4f78-84ee-c260d4d91ee9.jpg", 7, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "img/497dc572-6091-4419-bf8c-cafcd3ee9263.jpg", 7, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "img/89da6dac-5053-4870-a3d7-eea22bc3ea67.jpg", 7, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "img/b2f0a4aa-c4e1-45c6-90f2-e14faa85c406.png", 8, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "img/37d7b03f-34cd-441d-ba51-2ae85c88188a.jpg", 9, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "img/52e1d9bf-2f4f-48fc-a543-7f23e61e1395.jpg", 9, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "img/9f0dc411-87a2-4a2d-b028-69dcf82fae39.jpg", 10, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "img/e1b8daf3-81eb-4bf7-b9c0-522dd9f80838.jpg", 11, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "img/b2c0e10d-5585-46cf-a576-cb24732e1538.jpg", 11, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "img/f71d6ced-8fbc-4890-915a-ac2a971a6b19.jpg", 12, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "img/896651d3-9b0f-47c1-bdfb-ec343e259829.jpg", 12, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "img/9f464a6f-62e9-4326-9734-a1ac85a8b74e.jpg", 12, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "img/ba1b77bf-0ae7-4a44-bf2a-e6d9c31fe6e0.jpg", 13, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "img/2ec2068b-e1d7-48eb-abb6-fd5a1612ec29.jpg", 13, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, "img/1c002bd0-f1ab-47c9-8871-87aa55f99d15.jpg", 14, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 31, "img/7c2f592e-9db8-4ad7-b378-ceb4ee75b3db.jpg", 14, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 32, "img/8da36e7f-6699-4da4-9622-da8310ba734b.jpg", 16, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 33, "img/a4b0822d-b2cc-4102-9192-056740ea1e11.jpg", 17, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 34, "img/21a9b32a-bede-4c9b-984f-db32070b4a22.jpg", 18, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 35, "img/364ddf95-6df0-426f-86a1-7923eedc03de.jpg", 19, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 36, "img/93d0cd83-6917-4d56-870c-871c4d63e036.jpg", 20, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 37, "img/3749c185-1c42-4ead-88a1-e88dcfb23dca.jpg", 21, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 38, "img/fc1d6192-449c-4322-bea1-bd8b655d5cdf.jpg", 21, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 39, "img/25e1be93-6df3-4507-a7f7-201e602afa7f.jpg", 21, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 40, "img/25e1be93-6df3-4507-a7f7-201e602afa7f.jpg", 23, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 41, "img/25e1be93-6df3-4507-a7f7-201e602afa7f.jpg", 24, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) },
                    { 42, "img/25e1be93-6df3-4507-a7f7-201e602afa7f.jpg", 25, new DateTime(2025, 8, 17, 13, 38, 21, 454, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courts_StadiumId",
                table: "Courts",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_StadiumImages_StadiumId",
                table: "StadiumImages",
                column: "StadiumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "StadiumImages");

            migrationBuilder.DropTable(
                name: "Stadiums");
        }
    }
}
