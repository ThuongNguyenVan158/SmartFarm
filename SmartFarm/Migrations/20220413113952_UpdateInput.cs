using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartFarm.Migrations
{
    public partial class UpdateInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonVi",
                table: "INPUT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonVi",
                table: "INPUT");
        }
    }
}
