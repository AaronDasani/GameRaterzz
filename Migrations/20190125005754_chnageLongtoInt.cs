using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStarz.Migrations
{
    public partial class chnageLongtoInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    companyId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.companyId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    gameId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    rating = table.Column<double>(nullable: false),
                    popularity = table.Column<double>(nullable: false),
                    summary = table.Column<string>(nullable: true),
                    user_id = table.Column<int>(nullable: false),
                    release_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.gameId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    genre_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    slug = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    platform_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.platform_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstname = table.Column<string>(maxLength: 30, nullable: false),
                    lastname = table.Column<string>(maxLength: 30, nullable: false),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    cover_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gameId = table.Column<int>(nullable: false),
                    image_id = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.cover_id);
                    table.ForeignKey(
                        name: "FK_Covers_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvolvedCompanies",
                columns: table => new
                {
                    involveCompany_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    companyId = table.Column<int>(nullable: false),
                    gameId = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Screenshots",
                columns: table => new
                {
                    screenshot_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gameId = table.Column<int>(nullable: false),
                    image_id = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenshots", x => x.screenshot_id);
                    table.ForeignKey(
                        name: "FK_Screenshots_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    TheVideo_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gameId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    video_id = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.TheVideo_id);
                    table.ForeignKey(
                        name: "FK_Videos_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    gameGenre_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gameId = table.Column<int>(nullable: false),
                    genre_id = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => x.gameGenre_id);
                    table.ForeignKey(
                        name: "FK_GameGenres_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenres_Genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "Genres",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatforms",
                columns: table => new
                {
                    gamePlatform_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gameId = table.Column<int>(nullable: false),
                    platform_id = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatforms", x => x.gamePlatform_id);
                    table.ForeignKey(
                        name: "FK_GamePlatforms_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatforms_Platforms_platform_id",
                        column: x => x.platform_id,
                        principalTable: "Platforms",
                        principalColumn: "platform_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expansions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    cover_id = table.Column<int>(nullable: true),
                    gameId = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expansions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Expansions_Covers_cover_id",
                        column: x => x.cover_id,
                        principalTable: "Covers",
                        principalColumn: "cover_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expansions_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Covers_gameId",
                table: "Covers",
                column: "gameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expansions_cover_id",
                table: "Expansions",
                column: "cover_id");

            migrationBuilder.CreateIndex(
                name: "IX_Expansions_gameId",
                table: "Expansions",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_gameId",
                table: "GameGenres",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_genre_id",
                table: "GameGenres",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatforms_gameId",
                table: "GamePlatforms",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatforms_platform_id",
                table: "GamePlatforms",
                column: "platform_id");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanies_companyId",
                table: "InvolvedCompanies",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanies_gameId",
                table: "InvolvedCompanies",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenshots_gameId",
                table: "Screenshots",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_gameId",
                table: "Videos",
                column: "gameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expansions");

            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "GamePlatforms");

            migrationBuilder.DropTable(
                name: "InvolvedCompanies");

            migrationBuilder.DropTable(
                name: "Screenshots");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
