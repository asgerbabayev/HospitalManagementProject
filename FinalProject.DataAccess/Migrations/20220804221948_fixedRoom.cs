using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.DataAccess.Migrations
{
    public partial class fixedRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Rooms",
                type: "text",
                nullable: true);
        }
    }
}
