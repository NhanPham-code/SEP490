using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindTeamAPI.Migrations
{
    /// <inheritdoc />
    public partial class addJoinedMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JoinedPlayers",
                table: "TeamPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinedPlayers",
                table: "TeamPosts");
        }
    }
}
