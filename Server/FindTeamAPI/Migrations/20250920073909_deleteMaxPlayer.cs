using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindTeamAPI.Migrations
{
    /// <inheritdoc />
    public partial class deleteMaxPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPlayers",
                table: "TeamPosts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxPlayers",
                table: "TeamPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
