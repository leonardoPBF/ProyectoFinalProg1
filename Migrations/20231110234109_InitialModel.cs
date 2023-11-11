using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalProg1.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipalidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreMunicipalidad = table.Column<string>(type: "TEXT", nullable: true),
                    Departamento = table.Column<string>(type: "TEXT", nullable: true),
                    Distrito = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Referencia = table.Column<string>(type: "TEXT", nullable: true),
                    Aceptacion = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    Resumen = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alcalde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    InicioAlcaldia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Aceptacion = table.Column<int>(type: "INTEGER", nullable: false),
                    MunicipalidadId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alcalde", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alcalde_Municipalidad_MunicipalidadId",
                        column: x => x.MunicipalidadId,
                        principalTable: "Municipalidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormacionAcademica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Universidad = table.Column<string>(type: "TEXT", nullable: true),
                    Carrera = table.Column<string>(type: "TEXT", nullable: true),
                    AñoGraduacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdAlcalde = table.Column<int>(type: "INTEGER", nullable: false),
                    AlcaldeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormacionAcademica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormacionAcademica_Alcalde_AlcaldeId",
                        column: x => x.AlcaldeId,
                        principalTable: "Alcalde",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alcalde_MunicipalidadId",
                table: "Alcalde",
                column: "MunicipalidadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormacionAcademica_AlcaldeId",
                table: "FormacionAcademica",
                column: "AlcaldeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormacionAcademica");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "Alcalde");

            migrationBuilder.DropTable(
                name: "Municipalidad");
        }
    }
}
