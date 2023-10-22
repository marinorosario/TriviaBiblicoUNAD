using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TriviaBiblicoUNAD.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeederEstudiantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "Id", "Apellidos", "Carrera", "FechNac", "Matricula", "Nombre" },
                values: new object[,]
                {
                    { 1, "Perez Campusano", "Ing de Softeware", new DateTime(2000, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "20230024", "Jose" },
                    { 2, "Mendez Gonzalez", "Ing de Softeware", new DateTime(2003, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "20230125", "Jennifer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
