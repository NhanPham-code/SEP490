using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindTeamAPI.Migrations
{
    /// <inheritdoc />
    public partial class addIndexDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TeamPosts_CreatedBy",
                table: "TeamPosts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPosts_PlayDate",
                table: "TeamPosts",
                column: "PlayDate");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPosts_StadiumId_PlayDate",
                table: "TeamPosts",
                columns: new[] { "StadiumId", "PlayDate" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamPostId_UserId",
                table: "TeamMembers",
                columns: new[] { "TeamPostId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeamPosts_CreatedBy",
                table: "TeamPosts");

            migrationBuilder.DropIndex(
                name: "IX_TeamPosts_PlayDate",
                table: "TeamPosts");

            migrationBuilder.DropIndex(
                name: "IX_TeamPosts_StadiumId_PlayDate",
                table: "TeamPosts");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_TeamPostId_UserId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers");
        }
    }
}
