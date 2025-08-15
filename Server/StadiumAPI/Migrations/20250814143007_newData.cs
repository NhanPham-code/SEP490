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
                    { 22, "Đường 30 Tháng 4, Xuân Khánh, Ninh Kiều, Cần Thơ", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Sân bóng đá cỏ nhân tạo 7 người, vị trí trung tâm, thuận tiện di chuyển.", true, 10.0305m, 105.7699m, "Sân bóng đá K22", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
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
                    { 30, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân 7 người", 250000m, "Bóng đá", 22, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
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
                    { 2, "https://i.ibb.co/v4B8zS5/san-bong-phi-long-2.jpg", 1, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "https://i.ibb.co/6803z65/san-quang-sport-1.jpg", 2, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "https://i.ibb.co/T1H8g64/san-tennis-6-doi-6.jpg", 3, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "https://i.ibb.co/S68Jg03/san-ro-dnc-1.jpg", 4, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "https://i.ibb.co/wB7L3k5/san-tambo.jpg", 5, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "https://i.ibb.co/sK085vT/san-van-dong-can-tho.jpg", 6, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "https://i.ibb.co/9V0p3V8/san-van-dong-can-tho-2.jpg", 6, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "https://i.ibb.co/0y7Yv83/ho-boi-anh-vien.jpg", 7, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "https://i.ibb.co/wN90n7t/san-tennis-586.jpg", 8, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "https://i.ibb.co/TmkYf7V/san-buu-dien-can-tho-1.jpg", 9, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "https://i.ibb.co/Xz9tTq8/san-tennis-muong-thanh.jpg", 10, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "https://i.ibb.co/f4g1qQj/san-bong-chuyen-586.jpg", 11, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "https://i.ibb.co/3s682Hn/ho-boi-vinpearl-can-tho.jpg", 12, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "https://i.ibb.co/q5k26L1/san-cau-long-hoang-long.jpg", 13, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "https://i.ibb.co/hK5XjP1/san-bong-anh-tuan.jpg", 14, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "https://i.ibb.co/f4g1qQj/san-tennis-cong-an-ct.jpg", 15, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "https://i.ibb.co/S68Jg03/san-ro-dnc-1.jpg", 16, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "https://i.ibb.co/8Y4B4Gj/san-bong-anh-tuan-2.jpg", 14, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "https://i.ibb.co/q0Vw5L4/san-ro-westside.jpg", 16, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "https://i.ibb.co/xMvjX62/nha-thi-dau-vi-thanh.jpg", 17, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "https://i.ibb.co/wB7L3k5/san-bong-vi-thanh-hau-giang.jpg", 18, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "https://i.ibb.co/F8S86P2/san-tennis-phu-hung-hg.jpg", 19, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "https://i.ibb.co/6803z65/nha-thi-dau-vinh-long.jpg", 20, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "https://i.ibb.co/3s682Hn/ho-boi-minh-phuong.jpg", 21, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "https://i.ibb.co/3k5fH0k/san-bong-k22.jpg", 22, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "https://i.ibb.co/3c675z2/san-cau-long-win-sport.jpg", 23, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "https://i.ibb.co/3c675z2/san-bong-chuyen-bai-bien.jpg", 24, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "https://i.ibb.co/3c675z2/san-bong-dhct.jpg", 25, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) }
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
