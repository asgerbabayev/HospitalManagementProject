using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.DataAccess.Migrations
{
    public partial class FixedPrescriptionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsageTime",
                table: "Prescriptions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Prescriptions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Prescriptions");

            migrationBuilder.AddColumn<string>(
                name: "UsageTime",
                table: "Prescriptions",
                type: "text",
                nullable: true);
        }
    }
}
