using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserAPI.Migrations
{
    /// <inheritdoc />
    public partial class newData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2006);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Address", "Email", "FullName", "PhoneNumber", "Role" },
                values: new object[] { "1 Admin Street, System", "admin@example.com", "Admin User", "0905555555", "Admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Address", "Email", "FullName", "PhoneNumber" },
                values: new object[] { "123 Đường A, Cần Thơ", "stadium.manager1@example.com", "Chủ Sân Một", "0901111111" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Address", "Email", "FullName", "PhoneNumber" },
                values: new object[] { "456 Đường B, Cần Thơ", "stadium.manager2@example.com", "Chủ Sân Hai", "0902222222" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "Address", "Email", "FullName", "PhoneNumber" },
                values: new object[] { "789 Đường C, Cần Thơ", "stadium.manager3@example.com", "Chủ Sân Ba", "0903333333" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "Address", "Email", "FullName", "PhoneNumber", "Role" },
                values: new object[] { "2006 Đường E, Cần Thơ", "phamhiennhan3105@gmail.com", "Phạm Hiền Nhân", "09020062006", "Customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "AvatarUrl", "CreatedDate", "DateOfBirth", "Email", "FaceEmbeddingsJson", "FrontCCCDUrl", "FullName", "Gender", "GoogleId", "IdentityNumber", "IsActive", "PasswordHash", "PasswordSalt", "PhoneNumber", "Provider", "RearCCCDUrl", "Role", "UpdatedDate" },
                values: new object[,]
                {
                    { 6, "Đại học FPT Cần Thơ", null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "NhanPHCE180604@fpt.edu.vn", null, null, "FPT Customer", null, null, null, true, new byte[] { 197, 68, 131, 196, 224, 137, 46, 176, 226, 184, 209, 253, 211, 178, 1, 41, 223, 127, 140, 194, 236, 31, 250, 204, 213, 188, 61, 181, 0, 25, 189, 168, 246, 73, 19, 8, 136, 101, 112, 174, 55, 9, 55, 41, 253, 254, 168, 250, 253, 145, 244, 240, 207, 34, 60, 142, 103, 73, 151, 191, 106, 246, 233, 60 }, new byte[] { 9, 241, 64, 122, 192, 162, 174, 103, 179, 229, 204, 134, 64, 123, 55, 72, 40, 111, 165, 182, 51, 129, 222, 30, 171, 117, 59, 232, 35, 234, 172, 86, 39, 31, 180, 74, 234, 59, 28, 225, 27, 59, 190, 193, 174, 153, 45, 16, 180, 40, 151, 37, 169, 150, 142, 230, 77, 107, 71, 111, 82, 162, 134, 147, 181, 18, 56, 170, 198, 183, 191, 43, 245, 58, 171, 69, 251, 204, 148, 77, 3, 209, 107, 45, 222, 51, 157, 6, 67, 147, 244, 151, 226, 140, 204, 154, 67, 46, 17, 138, 96, 15, 197, 219, 224, 90, 19, 46, 175, 82, 115, 203, 67, 102, 94, 242, 238, 48, 232, 101, 83, 67, 25, 114, 34, 219, 63, 128 }, "0123456789", null, null, "Customer", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, "123 Đường Tiến, Cần Thơ", null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "customer7@example.com", null, null, "Tiến", null, null, null, true, new byte[] { 197, 68, 131, 196, 224, 137, 46, 176, 226, 184, 209, 253, 211, 178, 1, 41, 223, 127, 140, 194, 236, 31, 250, 204, 213, 188, 61, 181, 0, 25, 189, 168, 246, 73, 19, 8, 136, 101, 112, 174, 55, 9, 55, 41, 253, 254, 168, 250, 253, 145, 244, 240, 207, 34, 60, 142, 103, 73, 151, 191, 106, 246, 233, 60 }, new byte[] { 9, 241, 64, 122, 192, 162, 174, 103, 179, 229, 204, 134, 64, 123, 55, 72, 40, 111, 165, 182, 51, 129, 222, 30, 171, 117, 59, 232, 35, 234, 172, 86, 39, 31, 180, 74, 234, 59, 28, 225, 27, 59, 190, 193, 174, 153, 45, 16, 180, 40, 151, 37, 169, 150, 142, 230, 77, 107, 71, 111, 82, 162, 134, 147, 181, 18, 56, 170, 198, 183, 191, 43, 245, 58, 171, 69, 251, 204, 148, 77, 3, 209, 107, 45, 222, 51, 157, 6, 67, 147, 244, 151, 226, 140, 204, 154, 67, 46, 17, 138, 96, 15, 197, 219, 224, 90, 19, 46, 175, 82, 115, 203, 67, 102, 94, 242, 238, 48, 232, 101, 83, 67, 25, 114, 34, 219, 63, 128 }, "0907777777", null, null, "Customer", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, "456 Đường Abu, Cần Thơ", null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "customer8@example.com", null, null, "Abu", null, null, null, true, new byte[] { 197, 68, 131, 196, 224, 137, 46, 176, 226, 184, 209, 253, 211, 178, 1, 41, 223, 127, 140, 194, 236, 31, 250, 204, 213, 188, 61, 181, 0, 25, 189, 168, 246, 73, 19, 8, 136, 101, 112, 174, 55, 9, 55, 41, 253, 254, 168, 250, 253, 145, 244, 240, 207, 34, 60, 142, 103, 73, 151, 191, 106, 246, 233, 60 }, new byte[] { 9, 241, 64, 122, 192, 162, 174, 103, 179, 229, 204, 134, 64, 123, 55, 72, 40, 111, 165, 182, 51, 129, 222, 30, 171, 117, 59, 232, 35, 234, 172, 86, 39, 31, 180, 74, 234, 59, 28, 225, 27, 59, 190, 193, 174, 153, 45, 16, 180, 40, 151, 37, 169, 150, 142, 230, 77, 107, 71, 111, 82, 162, 134, 147, 181, 18, 56, 170, 198, 183, 191, 43, 245, 58, 171, 69, 251, 204, 148, 77, 3, 209, 107, 45, 222, 51, 157, 6, 67, 147, 244, 151, 226, 140, 204, 154, 67, 46, 17, 138, 96, 15, 197, 219, 224, 90, 19, 46, 175, 82, 115, 203, 67, 102, 94, 242, 238, 48, 232, 101, 83, 67, 25, 114, 34, 219, 63, 128 }, "0908888888", null, null, "Customer", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Address", "Email", "FullName", "PhoneNumber", "Role" },
                values: new object[] { "123 Đường A, Cần Thơ", "stadium.manager1@example.com", "Chủ Sân Một", "0901111111", "StadiumManager" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Address", "Email", "FullName", "PhoneNumber" },
                values: new object[] { "456 Đường B, Cần Thơ", "stadium.manager2@example.com", "Chủ Sân Hai", "0902222222" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Address", "Email", "FullName", "PhoneNumber" },
                values: new object[] { "789 Đường C, Cần Thơ", "stadium.manager3@example.com", "Chủ Sân Ba", "0903333333" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "Address", "Email", "FullName", "PhoneNumber" },
                values: new object[] { "101 Đường D, Cần Thơ", "stadium.manager4@example.com", "Chủ Sân Bốn", "0904444444" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "Address", "Email", "FullName", "PhoneNumber", "Role" },
                values: new object[] { "1 Admin Street, System", "admin@example.com", "Admin User", "0905555555", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "AvatarUrl", "CreatedDate", "DateOfBirth", "Email", "FaceEmbeddingsJson", "FrontCCCDUrl", "FullName", "Gender", "GoogleId", "IdentityNumber", "IsActive", "PasswordHash", "PasswordSalt", "PhoneNumber", "Provider", "RearCCCDUrl", "Role", "UpdatedDate" },
                values: new object[] { 2006, "2006 Đường E, Cần Thơ", null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "phamhiennhan3105@gmail.com", null, null, "Phạm Hiền Nhân", null, null, null, true, new byte[] { 197, 68, 131, 196, 224, 137, 46, 176, 226, 184, 209, 253, 211, 178, 1, 41, 223, 127, 140, 194, 236, 31, 250, 204, 213, 188, 61, 181, 0, 25, 189, 168, 246, 73, 19, 8, 136, 101, 112, 174, 55, 9, 55, 41, 253, 254, 168, 250, 253, 145, 244, 240, 207, 34, 60, 142, 103, 73, 151, 191, 106, 246, 233, 60 }, new byte[] { 9, 241, 64, 122, 192, 162, 174, 103, 179, 229, 204, 134, 64, 123, 55, 72, 40, 111, 165, 182, 51, 129, 222, 30, 171, 117, 59, 232, 35, 234, 172, 86, 39, 31, 180, 74, 234, 59, 28, 225, 27, 59, 190, 193, 174, 153, 45, 16, 180, 40, 151, 37, 169, 150, 142, 230, 77, 107, 71, 111, 82, 162, 134, 147, 181, 18, 56, 170, 198, 183, 191, 43, 245, 58, 171, 69, 251, 204, 148, 77, 3, 209, 107, 45, 222, 51, 157, 6, 67, 147, 244, 151, 226, 140, 204, 154, 67, 46, 17, 138, 96, 15, 197, 219, 224, 90, 19, 46, 175, 82, 115, 203, 67, 102, 94, 242, 238, 48, 232, 101, 83, 67, 25, 114, 34, 219, 63, 128 }, "09020062006", null, null, "Customer", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
