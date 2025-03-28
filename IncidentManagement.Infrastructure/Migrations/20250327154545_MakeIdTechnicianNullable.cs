using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeIdTechnicianNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Technicians_IdTechnician",
                table: "Incidents");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdTechnician",
                table: "Incidents",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Technicians_IdTechnician",
                table: "Incidents",
                column: "IdTechnician",
                principalTable: "Technicians",
                principalColumn: "IdTechnician");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Technicians_IdTechnician",
                table: "Incidents");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdTechnician",
                table: "Incidents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Technicians_IdTechnician",
                table: "Incidents",
                column: "IdTechnician",
                principalTable: "Technicians",
                principalColumn: "IdTechnician",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
