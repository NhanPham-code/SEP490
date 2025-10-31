using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StadiumAPI.Migrations
{
    /// <inheritdoc />
    public partial class addimgV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StadiumImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "StadiumId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "StadiumImages",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImageUrl",
                value: "img/san-pickleball-65-can-tho-4-1719439252.png");

            migrationBuilder.UpdateData(
                table: "StadiumImages",
                keyColumn: "Id",
                keyValue: 36,
                column: "ImageUrl",
                value: "img/san-pickleball-c-club-academy-5-1733860845.jpg");

            migrationBuilder.UpdateData(
                table: "StadiumImages",
                keyColumn: "Id",
                keyValue: 37,
                column: "ImageUrl",
                value: "img/san-pickleball-c-club-academy-2-1733860844.jpg");

            migrationBuilder.UpdateData(
                table: "StadiumImages",
                keyColumn: "Id",
                keyValue: 38,
                column: "ImageUrl",
                value: "img/san-pickleball-dat-cao-2-1730166260.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StadiumImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "StadiumId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "StadiumImages",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImageUrl",
                value: "img/san-pickleball-65-can-tho-4-1719439252.jpg");

            migrationBuilder.UpdateData(
                table: "StadiumImages",
                keyColumn: "Id",
                keyValue: 36,
                column: "ImageUrl",
                value: "img/7d4e3a2b-1c9a-4f8e-9e3c-4a2b1c9a4f8e.jpg");

            migrationBuilder.UpdateData(
                table: "StadiumImages",
                keyColumn: "Id",
                keyValue: 37,
                column: "ImageUrl",
                value: "img/8e5f4b3c-2d0b-5g9f-0f4d-5b3c2d0b5g9f.jpg");

            migrationBuilder.UpdateData(
                table: "StadiumImages",
                keyColumn: "Id",
                keyValue: 38,
                column: "ImageUrl",
                value: "img/9f6g5c4d-3e1c-6h0g-1g5e-6c4d3e1c6h0g.jpg");
        }
    }
}
