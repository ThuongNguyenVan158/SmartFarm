using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartFarm.Migrations
{
    public partial class _updateLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "EQUIPMENT");

            migrationBuilder.AddColumn<string>(
                name: "Imgage",
                table: "EQUIPMENT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imgage",
                table: "EQUIPMENT");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "EQUIPMENT",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
