using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StadiumAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "ReadCourtDTO",
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StadiumsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadCourtDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadCourtDTO_Stadiums_StadiumsId",
                        column: x => x.StadiumsId,
                        principalTable: "Stadiums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReadStadiumImageDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StadiumId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StadiumsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadStadiumImageDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadStadiumImageDTO_Stadiums_StadiumsId",
                        column: x => x.StadiumsId,
                        principalTable: "Stadiums",
                        principalColumn: "Id");
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
                    { 1, "Nguyễn Văn Cừ, Quận Ninh Kiều, Cần Thơ", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân bóng đá cỏ nhân tạo chất lượng cao, phù hợp thi đấu và tập luyện.", true, 10.045162m, 105.746857m, "Sân Bóng Cỏ Nhân Tạo Nguyễn Văn Cừ", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Số 1 Lê Lợi, Quận Ninh Kiều, Cần Thơ", new TimeSpan(0, 21, 0, 0, 0), new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân cầu lông tiêu chuẩn, phù hợp thi đấu chuyên nghiệp.", true, 10.03711m, 105.78829m, "Trung Tâm Cầu Lông Lê Lợi", new TimeSpan(0, 7, 0, 0, 0), new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Phường Hưng Lợi, Quận Ninh Kiều, Cần Thơ", new TimeSpan(0, 20, 0, 0, 0), new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân bóng rổ ngoài trời, rộng rãi, thoáng mát.", true, 10.0298m, 105.7621m, "Sân Bóng Rổ Hưng Lợi", new TimeSpan(0, 8, 0, 0, 0), new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Phường An Bình, Quận Ninh Kiều, Cần Thơ", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân tennis tiêu chuẩn với hệ thống đèn ban đêm.", true, 10.0515m, 105.7723m, "Sân Tennis An Bình", new TimeSpan(0, 5, 30, 0, 0), new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Trường Đại học Cần Thơ, Quận Ninh Kiều, Cần Thơ", new TimeSpan(0, 18, 30, 0, 0), new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sân bóng chuyền ngoài trời cho sinh viên và cộng đồng.", true, 10.0299m, 105.7702m, "Sân Bóng Chuyền Cần Thơ University", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "CreatedAt", "IsAvailable", "Name", "PricePerHour", "SportType", "StadiumId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Số 1", 300000m, "Bóng đá", 1, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Số 2", 350000m, "Bóng đá", 1, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân A", 80000m, "Cầu lông", 2, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Sân B", 90000m, "Cầu lông", 2, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Rổ 1", 120000m, "Bóng rổ", 3, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Tennis 1", 200000m, "Tennis", 4, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Tennis 2", 220000m, "Tennis", 4, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Sân Chuyền 1", 100000m, "Bóng chuyền", 5, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StadiumImages",
                columns: new[] { "Id", "ImageUrl", "StadiumId", "UploadedAt" },
                values: new object[,]
                {
                    { 1, "https://example.com/sanbong-cantho-1.jpg", 1, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "https://example.com/sanbong-cantho-2.jpg", 1, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "https://example.com/sancaulong-cantho-1.jpg", 2, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "https://example.com/sancaulong-cantho-2.jpg", 2, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "https://example.com/sanro-cantho-1.jpg", 3, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "https://example.com/santennis-cantho-1.jpg", 4, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "https://example.com/sanchuyen-cantho-1.jpg", 5, new DateTime(2025, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courts_StadiumId",
                table: "Courts",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadCourtDTO_StadiumsId",
                table: "ReadCourtDTO",
                column: "StadiumsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadStadiumImageDTO_StadiumsId",
                table: "ReadStadiumImageDTO",
                column: "StadiumsId");

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
                name: "ReadCourtDTO");

            migrationBuilder.DropTable(
                name: "ReadStadiumImageDTO");

            migrationBuilder.DropTable(
                name: "StadiumImages");

            migrationBuilder.DropTable(
                name: "Stadiums");
        }
    }
}
