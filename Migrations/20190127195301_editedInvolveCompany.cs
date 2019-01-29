using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStarz.Migrations
{
    public partial class editedInvolveCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvolvedCompanies");

            migrationBuilder.RenameColumn(
                name: "companyId",
                table: "Companies",
                newName: "company_id");

            migrationBuilder.CreateTable(
                name: "GameCompanies",
                columns: table => new
                {
                    gameCompany_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<int>(nullable: false),
                    gameId = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCompanies", x => x.gameCompany_id);
                    table.ForeignKey(
                        name: "FK_GameCompanies_Companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCompanies_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameCompanies_company_id",
                table: "GameCompanies",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_GameCompanies_gameId",
                table: "GameCompanies",
                column: "gameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCompanies");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "Companies",
                newName: "companyId");

            migrationBuilder.CreateTable(
                name: "InvolvedCompanies",
                columns: table => new
                {
                    involveCompany_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    companyId = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    gameId = table.Column<int>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvolvedCompanies", x => x.involveCompany_id);
                    table.ForeignKey(
                        name: "FK_InvolvedCompanies_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "companyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvolvedCompanies_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanies_companyId",
                table: "InvolvedCompanies",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanies_gameId",
                table: "InvolvedCompanies",
                column: "gameId");
        }
    }
}
