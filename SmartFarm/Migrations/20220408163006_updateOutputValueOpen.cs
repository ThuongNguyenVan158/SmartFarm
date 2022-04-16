using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartFarm.Migrations
{
    public partial class updateOutputValueOpen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ValueOpen",
                table: "OUTPUT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ThoiGianTruyXuat",
                table: "INPUT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueOpen",
                table: "OUTPUT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianTruyXuat",
                table: "INPUT",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
