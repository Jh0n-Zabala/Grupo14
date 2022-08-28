using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomePetCare.App.Persistencia.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entorno = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Individuos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorasLaborales = table.Column<int>(type: "int", nullable: true),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropietarioId = table.Column<int>(type: "int", nullable: true),
                    EnfermeraId = table.Column<int>(type: "int", nullable: true),
                    VeterinarioId = table.Column<int>(type: "int", nullable: true),
                    HistoriaId = table.Column<int>(type: "int", nullable: true),
                    Parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propietario_Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistroRethus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individuos_Historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Individuos_Individuos_EnfermeraId",
                        column: x => x.EnfermeraId,
                        principalTable: "Individuos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Individuos_Individuos_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Individuos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Individuos_Individuos_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Individuos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recomendaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recomendaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recomendaciones_Historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SignosVitales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: true),
                    Signo = table.Column<int>(type: "int", nullable: true),
                    MascotaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignosVitales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignosVitales_Individuos_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Individuos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Individuos_EnfermeraId",
                table: "Individuos",
                column: "EnfermeraId");

            migrationBuilder.CreateIndex(
                name: "IX_Individuos_HistoriaId",
                table: "Individuos",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Individuos_PropietarioId",
                table: "Individuos",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Individuos_VeterinarioId",
                table: "Individuos",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendaciones_HistoriaId",
                table: "Recomendaciones",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SignosVitales_MascotaId",
                table: "SignosVitales",
                column: "MascotaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recomendaciones");

            migrationBuilder.DropTable(
                name: "SignosVitales");

            migrationBuilder.DropTable(
                name: "Individuos");

            migrationBuilder.DropTable(
                name: "Historias");
        }
    }
}
