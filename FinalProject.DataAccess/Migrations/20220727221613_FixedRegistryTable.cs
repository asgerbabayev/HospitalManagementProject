using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.DataAccess.Migrations
{
    public partial class FixedRegistryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Patients");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Registries",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Registries");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Patients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
