using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStarz.Migrations
{
    public partial class revertback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Api_Id",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Api_Id",
                table: "Screenshots");

            migrationBuilder.DropColumn(
                name: "Api_id",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "Api_id",
                table: "InvolvedCompanies");

            migrationBuilder.DropColumn(
                name: "Api_id",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Api_Id",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Api_Id",
                table: "Expansions");

            migrationBuilder.DropColumn(
                name: "Api_id",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Api_id",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "expansion_id",
                table: "Expansions",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Expansions",
                newName: "expansion_id");

            migrationBuilder.AddColumn<int>(
                name: "Api_Id",
                table: "Videos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Api_Id",
                table: "Screenshots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Api_id",
                table: "Platforms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Api_id",
                table: "InvolvedCompanies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Api_id",
                table: "Genres",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Api_Id",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Api_Id",
                table: "Expansions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Api_id",
                table: "Covers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Api_id",
                table: "Companies",
                nullable: false,
                defaultValue: 0);
        }
    }
}
