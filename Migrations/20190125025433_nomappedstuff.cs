using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStarz.Migrations
{
    public partial class nomappedstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covers_Games_gameId",
                table: "Covers");

            migrationBuilder.DropIndex(
                name: "IX_Covers_gameId",
                table: "Covers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Covers_gameId",
                table: "Covers",
                column: "gameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_Games_gameId",
                table: "Covers",
                column: "gameId",
                principalTable: "Games",
                principalColumn: "gameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
