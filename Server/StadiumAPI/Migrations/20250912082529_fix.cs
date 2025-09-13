using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StadiumAPI.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Stadiums");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUser",
                table: "Stadiums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedByUser",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedByUser",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedByUser",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedByUser",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedByUser",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedByUser",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedByUser",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedByUser",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedByUser",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedByUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedByUser",
                value: 2);
        }
    }
}
