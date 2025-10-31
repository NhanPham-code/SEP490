using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceEmbeddingsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontCCCDUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RearCCCDUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GoogleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BiometricCredentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiometricCredentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BiometricCredentials_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "AvatarUrl", "CreatedDate", "DateOfBirth", "Email", "FaceEmbeddingsJson", "FrontCCCDUrl", "FullName", "Gender", "GoogleId", "IdentityNumber", "IsActive", "PasswordHash", "PasswordSalt", "PhoneNumber", "Provider", "RearCCCDUrl", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "123 Đường A, Cần Thơ", null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "stadium.manager1@example.com", null, null, "Chủ Sân Một", null, null, null, true, new byte[] { 78, 75, 76, 158, 140, 141, 62, 59, 224, 42, 7, 141, 142, 103, 159, 140, 115, 69, 55, 79, 99, 25, 19, 108, 89, 127, 41, 47, 140, 61, 152, 68, 86, 30, 65, 38, 141, 40, 74, 156, 145, 14, 95, 151, 137, 100, 53, 68, 18, 139, 8, 122, 43, 133, 155, 131, 94, 108, 103, 46, 16, 40, 72, 91 }, new byte[] { 1, 26, 92, 195, 147, 44, 72, 141, 136, 24, 58, 28, 93, 94, 154, 126, 103, 123, 42, 74, 5, 124, 142, 146, 63, 44, 104, 91, 245, 22, 132, 173, 242, 58, 212, 90, 122, 156, 93, 11, 14, 141, 140, 58, 10, 196, 155, 35, 127, 110, 248, 95, 4, 55, 65, 61, 138, 28, 193, 154, 109, 100, 12, 91, 233, 122, 94, 101, 24, 124, 6, 44, 144, 58, 161, 83, 60, 156, 123, 42, 21, 72, 122, 127, 26, 243, 245, 92, 75, 108, 116, 73, 193, 126, 69, 77, 141, 88, 126, 22, 68, 131, 156, 3, 28, 70, 17, 44, 95, 62, 59, 79, 60, 152, 66, 19, 89, 120, 83, 94, 84, 111, 131, 114, 90, 14, 124, 108 }, "0901111111", null, null, "StadiumManager", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "456 Đường B, Cần Thơ", null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "stadium.manager2@example.com", null, null, "Chủ Sân Hai", null, null, null, true, new byte[] { 78, 75, 76, 158, 140, 141, 62, 59, 224, 42, 7, 141, 142, 103, 159, 140, 115, 69, 55, 79, 99, 25, 19, 108, 89, 127, 41, 47, 140, 61, 152, 68, 86, 30, 65, 38, 141, 40, 74, 156, 145, 14, 95, 151, 137, 100, 53, 68, 18, 139, 8, 122, 43, 133, 155, 131, 94, 108, 103, 46, 16, 40, 72, 91 }, new byte[] { 1, 26, 92, 195, 147, 44, 72, 141, 136, 24, 58, 28, 93, 94, 154, 126, 103, 123, 42, 74, 5, 124, 142, 146, 63, 44, 104, 91, 245, 22, 132, 173, 242, 58, 212, 90, 122, 156, 93, 11, 14, 141, 140, 58, 10, 196, 155, 35, 127, 110, 248, 95, 4, 55, 65, 61, 138, 28, 193, 154, 109, 100, 12, 91, 233, 122, 94, 101, 24, 124, 6, 44, 144, 58, 161, 83, 60, 156, 123, 42, 21, 72, 122, 127, 26, 243, 245, 92, 75, 108, 116, 73, 193, 126, 69, 77, 141, 88, 126, 22, 68, 131, 156, 3, 28, 70, 17, 44, 95, 62, 59, 79, 60, 152, 66, 19, 89, 120, 83, 94, 84, 111, 131, 114, 90, 14, 124, 108 }, "0902222222", null, null, "StadiumManager", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "789 Đường C, Cần Thơ", null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "stadium.manager3@example.com", null, null, "Chủ Sân Ba", null, null, null, true, new byte[] { 78, 75, 76, 158, 140, 141, 62, 59, 224, 42, 7, 141, 142, 103, 159, 140, 115, 69, 55, 79, 99, 25, 19, 108, 89, 127, 41, 47, 140, 61, 152, 68, 86, 30, 65, 38, 141, 40, 74, 156, 145, 14, 95, 151, 137, 100, 53, 68, 18, 139, 8, 122, 43, 133, 155, 131, 94, 108, 103, 46, 16, 40, 72, 91 }, new byte[] { 1, 26, 92, 195, 147, 44, 72, 141, 136, 24, 58, 28, 93, 94, 154, 126, 103, 123, 42, 74, 5, 124, 142, 146, 63, 44, 104, 91, 245, 22, 132, 173, 242, 58, 212, 90, 122, 156, 93, 11, 14, 141, 140, 58, 10, 196, 155, 35, 127, 110, 248, 95, 4, 55, 65, 61, 138, 28, 193, 154, 109, 100, 12, 91, 233, 122, 94, 101, 24, 124, 6, 44, 144, 58, 161, 83, 60, 156, 123, 42, 21, 72, 122, 127, 26, 243, 245, 92, 75, 108, 116, 73, 193, 126, 69, 77, 141, 88, 126, 22, 68, 131, 156, 3, 28, 70, 17, 44, 95, 62, 59, 79, 60, 152, 66, 19, 89, 120, 83, 94, 84, 111, 131, 114, 90, 14, 124, 108 }, "0903333333", null, null, "StadiumManager", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "101 Đường D, Cần Thơ", null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "stadium.manager4@example.com", null, null, "Chủ Sân Bốn", null, null, null, true, new byte[] { 78, 75, 76, 158, 140, 141, 62, 59, 224, 42, 7, 141, 142, 103, 159, 140, 115, 69, 55, 79, 99, 25, 19, 108, 89, 127, 41, 47, 140, 61, 152, 68, 86, 30, 65, 38, 141, 40, 74, 156, 145, 14, 95, 151, 137, 100, 53, 68, 18, 139, 8, 122, 43, 133, 155, 131, 94, 108, 103, 46, 16, 40, 72, 91 }, new byte[] { 1, 26, 92, 195, 147, 44, 72, 141, 136, 24, 58, 28, 93, 94, 154, 126, 103, 123, 42, 74, 5, 124, 142, 146, 63, 44, 104, 91, 245, 22, 132, 173, 242, 58, 212, 90, 122, 156, 93, 11, 14, 141, 140, 58, 10, 196, 155, 35, 127, 110, 248, 95, 4, 55, 65, 61, 138, 28, 193, 154, 109, 100, 12, 91, 233, 122, 94, 101, 24, 124, 6, 44, 144, 58, 161, 83, 60, 156, 123, 42, 21, 72, 122, 127, 26, 243, 245, 92, 75, 108, 116, 73, 193, 126, 69, 77, 141, 88, 126, 22, 68, 131, 156, 3, 28, 70, 17, 44, 95, 62, 59, 79, 60, 152, 66, 19, 89, 120, 83, 94, 84, 111, 131, 114, 90, 14, 124, 108 }, "0904444444", null, null, "StadiumManager", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "1 Admin Street, System", null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "admin@example.com", null, null, "Admin User", null, null, null, true, new byte[] { 78, 75, 76, 158, 140, 141, 62, 59, 224, 42, 7, 141, 142, 103, 159, 140, 115, 69, 55, 79, 99, 25, 19, 108, 89, 127, 41, 47, 140, 61, 152, 68, 86, 30, 65, 38, 141, 40, 74, 156, 145, 14, 95, 151, 137, 100, 53, 68, 18, 139, 8, 122, 43, 133, 155, 131, 94, 108, 103, 46, 16, 40, 72, 91 }, new byte[] { 1, 26, 92, 195, 147, 44, 72, 141, 136, 24, 58, 28, 93, 94, 154, 126, 103, 123, 42, 74, 5, 124, 142, 146, 63, 44, 104, 91, 245, 22, 132, 173, 242, 58, 212, 90, 122, 156, 93, 11, 14, 141, 140, 58, 10, 196, 155, 35, 127, 110, 248, 95, 4, 55, 65, 61, 138, 28, 193, 154, 109, 100, 12, 91, 233, 122, 94, 101, 24, 124, 6, 44, 144, 58, 161, 83, 60, 156, 123, 42, 21, 72, 122, 127, 26, 243, 245, 92, 75, 108, 116, 73, 193, 126, 69, 77, 141, 88, 126, 22, 68, 131, 156, 3, 28, 70, 17, 44, 95, 62, 59, 79, 60, 152, 66, 19, 89, 120, 83, 94, 84, 111, 131, 114, 90, 14, 124, 108 }, "0905555555", null, null, "Admin", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2006, "2006 Đường E, Cần Thơ", null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "phamhiennhan3105@gmail.com", null, null, "Phạm Hiền Nhân", null, null, null, true, new byte[] { 78, 75, 76, 158, 140, 141, 62, 59, 224, 42, 7, 141, 142, 103, 159, 140, 115, 69, 55, 79, 99, 25, 19, 108, 89, 127, 41, 47, 140, 61, 152, 68, 86, 30, 65, 38, 141, 40, 74, 156, 145, 14, 95, 151, 137, 100, 53, 68, 18, 139, 8, 122, 43, 133, 155, 131, 94, 108, 103, 46, 16, 40, 72, 91 }, new byte[] { 1, 26, 92, 195, 147, 44, 72, 141, 136, 24, 58, 28, 93, 94, 154, 126, 103, 123, 42, 74, 5, 124, 142, 146, 63, 44, 104, 91, 245, 22, 132, 173, 242, 58, 212, 90, 122, 156, 93, 11, 14, 141, 140, 58, 10, 196, 155, 35, 127, 110, 248, 95, 4, 55, 65, 61, 138, 28, 193, 154, 109, 100, 12, 91, 233, 122, 94, 101, 24, 124, 6, 44, 144, 58, 161, 83, 60, 156, 123, 42, 21, 72, 122, 127, 26, 243, 245, 92, 75, 108, 116, 73, 193, 126, 69, 77, 141, 88, 126, 22, 68, 131, 156, 3, 28, 70, 17, 44, 95, 62, 59, 79, 60, 152, 66, 19, 89, 120, 83, 94, 84, 111, 131, 114, 90, 14, 124, 108 }, "09020062006", null, null, "Customer", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiometricCredentials_UserId",
                table: "BiometricCredentials",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiometricCredentials");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
