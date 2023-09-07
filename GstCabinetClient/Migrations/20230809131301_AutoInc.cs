using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GstCabinetClient.Migrations
{
    public partial class AutoInc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medcins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialité = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medcins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRendezvous = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horraire = table.Column<TimeSpan>(type: "time", nullable: true),
                    MedcinID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disponibilites_Medcins_MedcinID",
                        column: x => x.MedcinID,
                        principalTable: "Medcins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    Num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horraire = table.Column<TimeSpan>(type: "time", nullable: true),
                    MedcinID = table.Column<int>(type: "int", nullable: true),
                    PatientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => x.Num);
                    table.ForeignKey(
                        name: "FK_RendezVous_Medcins_MedcinID",
                        column: x => x.MedcinID,
                        principalTable: "Medcins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RendezVous_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilites_MedcinID",
                table: "Disponibilites",
                column: "MedcinID");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_MedcinID",
                table: "RendezVous",
                column: "MedcinID");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_PatientID",
                table: "RendezVous",
                column: "PatientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disponibilites");

            migrationBuilder.DropTable(
                name: "RendezVous");

            migrationBuilder.DropTable(
                name: "Medcins");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
