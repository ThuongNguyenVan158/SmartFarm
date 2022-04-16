using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartFarm.Migrations
{
    public partial class UpdateAioKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AioKey",
                table: "FARM",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AioKey",
                table: "FARM");
        }
    }
}
