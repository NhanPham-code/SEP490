using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StadiumAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedstadiumdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedBy",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedBy",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedBy",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedBy",
                value: 8);
        }
    }
}
