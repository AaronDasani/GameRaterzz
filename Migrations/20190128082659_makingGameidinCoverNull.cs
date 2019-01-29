using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStarz.Migrations
{
    public partial class makingGameidinCoverNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covers_Games_gameId",
                table: "Covers");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenshots_Games_gameId",
                table: "Screenshots");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Games_gameId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_gameId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Screenshots_gameId",
                table: "Screenshots");

            migrationBuilder.AlterColumn<int>(
                name: "gameId",
                table: "Covers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "expansion_id",
                table: "Covers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_Games_gameId",
                table: "Covers",
                column: "gameId",
                principalTable: "Games",
                principalColumn: "gameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covers_Games_gameId",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "expansion_id",
                table: "Covers");

            migrationBuilder.AlterColumn<int>(
                name: "gameId",
                table: "Covers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_gameId",
                table: "Videos",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenshots_gameId",
                table: "Screenshots",
                column: "gameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_Games_gameId",
                table: "Covers",
                column: "gameId",
                principalTable: "Games",
                principalColumn: "gameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenshots_Games_gameId",
                table: "Screenshots",
                column: "gameId",
                principalTable: "Games",
                principalColumn: "gameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Games_gameId",
                table: "Videos",
                column: "gameId",
                principalTable: "Games",
                principalColumn: "gameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
