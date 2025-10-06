using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindTeamAPI.Migrations
{
    /// <inheritdoc />
    public partial class addStadiumNamev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StadiumName",
                table: "TeamPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StadiumName",
                table: "TeamPosts");
        }
    }
}
