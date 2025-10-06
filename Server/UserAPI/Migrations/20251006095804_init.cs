using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                values: new object[] { 1, "123 Admin St", "https://example.com/avatar/admin.png", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "admin@example.com", null, "https://example.com/cccd/admin.png", "Admin User", null, null, null, true, new byte[] { 61, 245, 95, 239, 114, 51, 117, 227, 183, 88, 194, 170, 106, 144, 54, 13, 33, 71, 118, 189, 184, 225, 12, 65, 131, 253, 201, 255, 151, 229, 142, 245, 94, 254, 157, 12, 111, 7, 197, 205, 92, 121, 191, 176, 238, 210, 90, 21, 74, 229, 48, 186, 12, 115, 248, 70, 202, 75, 52, 134, 237, 133, 70, 90 }, new byte[] { 141, 64, 4, 134, 215, 100, 101, 229, 217, 66, 141, 203, 233, 199, 35, 51, 46, 248, 54, 179, 214, 28, 47, 122, 137, 17, 58, 11, 78, 111, 103, 96, 106, 85, 125, 215, 222, 76, 5, 9, 7, 231, 21, 163, 240, 155, 230, 86, 2, 94, 247, 158, 118, 220, 179, 233, 5, 31, 3, 218, 189, 53, 185, 7, 191, 200, 116, 172, 23, 52, 112, 188, 35, 213, 174, 98, 224, 96, 114, 244, 81, 83, 89, 30, 40, 248, 35, 0, 151, 183, 215, 16, 10, 38, 135, 11, 128, 232, 56, 203, 156, 119, 0, 96, 55, 12, 243, 165, 15, 213, 43, 158, 103, 115, 150, 193, 65, 32, 1, 122, 27, 182, 73, 33, 127, 132, 245, 240 }, "0123456789", null, "https://example.com/cccd/admin_rear.png", "Admin", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

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
