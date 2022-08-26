using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.DataAccess.Migrations
{
    public partial class FixedRegistry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Registries_RegistryId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Registries_Employees_DoctorId",
                table: "Registries");

            migrationBuilder.DropIndex(
                name: "IX_Registries_DoctorId",
                table: "Registries");

            migrationBuilder.DropIndex(
                name: "IX_Patients_RegistryId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Registries");

            migrationBuilder.DropColumn(
                name: "RegistryId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Registries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Registries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registries_EmployeeId",
                table: "Registries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Registries_PatientId",
                table: "Registries",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registries_Employees_EmployeeId",
                table: "Registries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registries_Patients_PatientId",
                table: "Registries",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registries_Employees_EmployeeId",
                table: "Registries");

            migrationBuilder.DropForeignKey(
                name: "FK_Registries_Patients_PatientId",
                table: "Registries");

            migrationBuilder.DropIndex(
                name: "IX_Registries_EmployeeId",
                table: "Registries");

            migrationBuilder.DropIndex(
                name: "IX_Registries_PatientId",
                table: "Registries");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Registries");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Registries");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Registries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegistryId",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registries_DoctorId",
                table: "Registries",
                column: "DoctorId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Registries_Employees_DoctorId",
                table: "Registries",
                column: "DoctorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
