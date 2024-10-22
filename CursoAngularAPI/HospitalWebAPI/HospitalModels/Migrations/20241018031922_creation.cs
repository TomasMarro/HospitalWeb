using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalModels.Migrations
{
    /// <inheritdoc />
    public partial class creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EsEspecialista = table.Column<bool>(type: "bit", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    Borrado = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Celular = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Borrado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumeroSala = table.Column<int>(type: "int", nullable: false),
                    NumeroCama = table.Column<int>(type: "int", nullable: false),
                    Diagnostico = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Observacion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false),
                    MedicoId = table.Column<long>(type: "bigint", nullable: false),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingresos_Medicos",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingresos_Pacientes",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Egresos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tratamiento = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Borrado = table.Column<bool>(type: "bit", nullable: false),
                    MedicoId = table.Column<long>(type: "bigint", nullable: false),
                    IngresoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Egresos_Ingresos",
                        column: x => x.IngresoId,
                        principalTable: "Ingresos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Egresos_Medicos",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Egresos_IngresoId",
                table: "Egresos",
                column: "IngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_Egresos_MedicoId",
                table: "Egresos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_MedicoId",
                table: "Ingresos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_PacienteId",
                table: "Ingresos",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Egresos");

            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
