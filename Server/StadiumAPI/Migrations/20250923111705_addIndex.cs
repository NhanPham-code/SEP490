using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StadiumAPI.Migrations
{
    /// <inheritdoc />
    public partial class addIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameUnsigned",
                table: "Stadiums",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AddressUnsigned",
                table: "Stadiums",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_AddressUnsigned",
                table: "Stadiums",
                column: "AddressUnsigned");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_IsApproved",
                table: "Stadiums",
                column: "IsApproved");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_Name",
                table: "Stadiums",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_NameUnsigned",
                table: "Stadiums",
                column: "NameUnsigned");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_Name",
                table: "Courts",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stadiums_AddressUnsigned",
                table: "Stadiums");

            migrationBuilder.DropIndex(
                name: "IX_Stadiums_IsApproved",
                table: "Stadiums");

            migrationBuilder.DropIndex(
                name: "IX_Stadiums_Name",
                table: "Stadiums");

            migrationBuilder.DropIndex(
                name: "IX_Stadiums_NameUnsigned",
                table: "Stadiums");

            migrationBuilder.DropIndex(
                name: "IX_Courts_Name",
                table: "Courts");

            migrationBuilder.AlterColumn<string>(
                name: "NameUnsigned",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AddressUnsigned",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
