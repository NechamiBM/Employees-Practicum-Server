using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employees.Data.Migrations
{
    public partial class remove_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
