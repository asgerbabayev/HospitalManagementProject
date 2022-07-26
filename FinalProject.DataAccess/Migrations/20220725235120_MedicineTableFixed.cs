using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.DataAccess.Migrations
{
    public partial class MedicineTableFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Medicines");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Medicines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Medicines");

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Medicines",
                type: "text",
                nullable: true);
        }
    }
}
