﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetStomatologic.Migrations
{
    public partial class SpecializariDoctori_Cont : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecializariDoctori");

            migrationBuilder.CreateTable(
                name: "SpecializariDoctor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializareID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializariDoctor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpecializariDoctor_Doctor_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializariDoctor_Specializare_SpecializareID",
                        column: x => x.SpecializareID,
                        principalTable: "Specializare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecializariDoctor_DoctorID",
                table: "SpecializariDoctor",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializariDoctor_SpecializareID",
                table: "SpecializariDoctor",
                column: "SpecializareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecializariDoctor");

            migrationBuilder.CreateTable(
                name: "SpecializariDoctori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    SpecializareID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializariDoctori", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpecializariDoctori_Doctor_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializariDoctori_Specializare_SpecializareID",
                        column: x => x.SpecializareID,
                        principalTable: "Specializare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecializariDoctori_DoctorID",
                table: "SpecializariDoctori",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializariDoctori_SpecializareID",
                table: "SpecializariDoctori",
                column: "SpecializareID");
        }
    }
}
