using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.DataAccess.Migrations
{
    public partial class FixedPatientRegistryRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegistryId",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_RegistryId",
                table: "Patients",
                column: "RegistryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Registries_RegistryId",
                table: "Patients",
                column: "RegistryId",
                principalTable: "Registries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Registries_RegistryId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_RegistryId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "RegistryId",
                table: "Patients");
        }
    }
}
