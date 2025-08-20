using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCCCDUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CCCDUrl",
                table: "Users",
                newName: "RearCCCDUrl");

            migrationBuilder.AddColumn<string>(
                name: "FrontCCCDUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "FrontCCCDUrl", "RearCCCDUrl" },
                values: new object[] { "https://example.com/cccd/admin.png", "https://example.com/cccd/admin_rear.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrontCCCDUrl",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RearCCCDUrl",
                table: "Users",
                newName: "CCCDUrl");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CCCDUrl",
                value: "https://example.com/cccd/admin.png");
        }
    }
}
