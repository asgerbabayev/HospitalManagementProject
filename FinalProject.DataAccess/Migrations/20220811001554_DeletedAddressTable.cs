using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinalProject.DataAccess.Migrations
{
    public partial class DeletedAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Registries_RegistryId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Registries_Addresses_AddressId",
                table: "Registries");

            migrationBuilder.DropTable(
                name: "Addresses");

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

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Patients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
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

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApartmentNumber = table.Column<int>(type: "integer", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

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
    }
}
