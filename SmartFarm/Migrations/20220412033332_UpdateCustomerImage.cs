using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartFarm.Migrations
{
    public partial class UpdateCustomerImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "CUSTOMER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "CUSTOMER");
        }
    }
}
