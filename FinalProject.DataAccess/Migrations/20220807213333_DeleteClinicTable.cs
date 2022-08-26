using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinalProject.DataAccess.Migrations
{
    public partial class DeleteClinicTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Clinics_ClinicId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Registries_Clinics_ClinicId",
                table: "Registries");

            migrationBuilder.DropForeignKey(
                name: "FK_Registries_Patients_PatientId",
                table: "Registries");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Registries_ClinicId",
                table: "Registries");

            migrationBuilder.DropIndex(
                name: "IX_Registries_PatientId",
                table: "Registries");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ClinicId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Registries");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Registries");

            migrationBuilder.DropColumn(
                name: "TaxNo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Registries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegistryId",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registries_AddressId",
                table: "Registries",
                column: "AddressId");

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
                name: "FK_Registries_Addresses_AddressId",
                table: "Registries",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Registries_RegistryId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Registries_Addresses_AddressId",
                table: "Registries");

            migrationBuilder.DropIndex(
                name: "IX_Registries_AddressId",
                table: "Registries");

            migrationBuilder.DropIndex(
                name: "IX_Patients_RegistryId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Registries");

            migrationBuilder.DropColumn(
                name: "RegistryId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Registries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Registries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaxNo",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registries_ClinicId",
                table: "Registries",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Registries_PatientId",
                table: "Registries",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ClinicId",
                table: "Employees",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Clinics_ClinicId",
                table: "Employees",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registries_Clinics_ClinicId",
                table: "Registries",
                column: "ClinicId",
                principalTable: "Clinics",
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
    }
}
