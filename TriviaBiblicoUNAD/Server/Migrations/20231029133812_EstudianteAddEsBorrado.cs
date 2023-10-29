using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriviaBiblicoUNAD.Server.Migrations
{
    /// <inheritdoc />
    public partial class EstudianteAddEsBorrado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaBorrado",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 1,
                column: "EstaBorrado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 2,
                column: "EstaBorrado",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaBorrado",
                table: "Estudiantes");
        }
    }
}
