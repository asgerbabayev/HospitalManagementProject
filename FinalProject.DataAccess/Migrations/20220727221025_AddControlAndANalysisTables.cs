using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinalProject.DataAccess.Migrations
{
    public partial class AddControlAndANalysisTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Rooms_RoomId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_RoomId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "Registries");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Patients");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Registries",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Registries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Analyses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Controls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegistryId = table.Column<int>(nullable: false),
                    Complaint = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Controls_Registries_RegistryId",
                        column: x => x.RegistryId,
                        principalTable: "Registries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ControlId = table.Column<int>(nullable: false),
                    AnalysisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlAnalyses_Analyses_AnalysisId",
                        column: x => x.AnalysisId,
                        principalTable: "Analyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControlAnalyses_Controls_ControlId",
                        column: x => x.ControlId,
                        principalTable: "Controls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registries_RoomId",
                table: "Registries",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlAnalyses_AnalysisId",
                table: "ControlAnalyses",
                column: "AnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlAnalyses_ControlId",
                table: "ControlAnalyses",
                column: "ControlId");

            migrationBuilder.CreateIndex(
                name: "IX_Controls_RegistryId",
                table: "Controls",
                column: "RegistryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registries_Rooms_RoomId",
                table: "Registries",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registries_Rooms_RoomId",
                table: "Registries");

            migrationBuilder.DropTable(
                name: "ControlAnalyses");

            migrationBuilder.DropTable(
                name: "Analyses");

            migrationBuilder.DropTable(
                name: "Controls");

            migrationBuilder.DropIndex(
                name: "IX_Registries_RoomId",
                table: "Registries");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Registries");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Registries",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "Registries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_RoomId",
                table: "Patients",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Rooms_RoomId",
                table: "Patients",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
