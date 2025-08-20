using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAPI.Migrations
{
    /// <inheritdoc />
    public partial class addVideoFace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FaceImageUrl",
                table: "Users",
                newName: "FaceVideoUrl");

            migrationBuilder.AddColumn<string>(
                name: "CCCDUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CCCDUrl", "FaceVideoUrl" },
                values: new object[] { "https://example.com/cccd/admin.png", "https://example.com/videos/admin.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CCCDUrl",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "FaceVideoUrl",
                table: "Users",
                newName: "FaceImageUrl");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "FaceImageUrl",
                value: "https://example.com/face/admin.png");
        }
    }
}
