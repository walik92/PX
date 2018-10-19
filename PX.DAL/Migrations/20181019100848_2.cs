using Microsoft.EntityFrameworkCore.Migrations;

namespace PX.DAL.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Employees",
                newName: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employees",
                newName: "Surname");
        }
    }
}
