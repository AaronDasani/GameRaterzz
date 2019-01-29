using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStarz.Migrations
{
    public partial class addstuffss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Games_gameId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_gameId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "gameId",
                table: "Genres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "gameId",
                table: "Genres",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_gameId",
                table: "Genres",
                column: "gameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Games_gameId",
                table: "Genres",
                column: "gameId",
                principalTable: "Games",
                principalColumn: "gameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
