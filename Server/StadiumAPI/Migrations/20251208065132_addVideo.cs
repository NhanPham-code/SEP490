using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StadiumAPI.Migrations
{
    /// <inheritdoc />
    public partial class addVideo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StadiumVideos",
                columns: new[] { "Id", "StadiumId", "UploadedAt", "VideoUrl" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "dabanh.mp4" },
                    { 2, 2, new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "sancau.mp4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StadiumVideos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StadiumVideos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
