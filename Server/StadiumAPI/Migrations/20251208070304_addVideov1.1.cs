using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StadiumAPI.Migrations
{
    /// <inheritdoc />
    public partial class addVideov11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StadiumVideos",
                keyColumn: "Id",
                keyValue: 1,
                column: "VideoUrl",
                value: "videos/dabanh.mp4");

            migrationBuilder.UpdateData(
                table: "StadiumVideos",
                keyColumn: "Id",
                keyValue: 2,
                column: "VideoUrl",
                value: "videos/sancau.mp4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StadiumVideos",
                keyColumn: "Id",
                keyValue: 1,
                column: "VideoUrl",
                value: "dabanh.mp4");

            migrationBuilder.UpdateData(
                table: "StadiumVideos",
                keyColumn: "Id",
                keyValue: 2,
                column: "VideoUrl",
                value: "sancau.mp4");
        }
    }
}
