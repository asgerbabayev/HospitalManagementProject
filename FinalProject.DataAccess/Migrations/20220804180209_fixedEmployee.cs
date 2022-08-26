using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.DataAccess.Migrations
{
    public partial class fixedEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertificateNo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Collage",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CertificateNo",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Collage",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employees",
                type: "text",
                nullable: true);
        }
    }
}
