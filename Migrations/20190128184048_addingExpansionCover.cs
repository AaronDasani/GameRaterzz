using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStarz.Migrations
{
    public partial class addingExpansionCover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covers_Games_gameId",
                table: "Covers");

            migrationBuilder.DropForeignKey(
                name: "FK_Expansions_Covers_cover_id",
                table: "Expansions");

            migrationBuilder.DropColumn(
                name: "expansion_id",
                table: "Covers");

            migrationBuilder.RenameColumn(
                name: "cover_id",
                table: "Expansions",
                newName: "coverexpansionCover_id");

            migrationBuilder.RenameIndex(
                name: "IX_Expansions_cover_id",
                table: "Expansions",
                newName: "IX_Expansions_coverexpansionCover_id");

            migrationBuilder.AlterColumn<int>(
                name: "gameId",
                table: "Covers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ExpansionCover",
                columns: table => new
                {
                    expansionCover_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gameId = table.Column<int>(nullable: false),
                    expansion_id = table.Column<int>(nullable: false),
                    image_id = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpansionCover", x => x.expansionCover_id);
                });

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
                name: "FK_Expansions_ExpansionCover_coverexpansionCover_id",
                table: "Expansions",
                column: "coverexpansionCover_id",
                principalTable: "ExpansionCover",
                principalColumn: "expansionCover_id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covers_Games_gameId",
                table: "Covers");

            migrationBuilder.DropForeignKey(
                name: "FK_Expansions_ExpansionCover_coverexpansionCover_id",
                table: "Expansions");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenshots_Games_gameId",
                table: "Screenshots");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Games_gameId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "ExpansionCover");

            migrationBuilder.DropIndex(
                name: "IX_Videos_gameId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Screenshots_gameId",
                table: "Screenshots");

            migrationBuilder.RenameColumn(
                name: "coverexpansionCover_id",
                table: "Expansions",
                newName: "cover_id");

            migrationBuilder.RenameIndex(
                name: "IX_Expansions_coverexpansionCover_id",
                table: "Expansions",
                newName: "IX_Expansions_cover_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Expansions_Covers_cover_id",
                table: "Expansions",
                column: "cover_id",
                principalTable: "Covers",
                principalColumn: "cover_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
