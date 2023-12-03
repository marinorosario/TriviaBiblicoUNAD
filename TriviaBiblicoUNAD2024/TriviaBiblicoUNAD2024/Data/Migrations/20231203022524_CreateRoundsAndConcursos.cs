using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriviaBiblicoUNAD2024.Migrations
{
    /// <inheritdoc />
    public partial class CreateRoundsAndConcursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoundModelId",
                table: "Preguntas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Concursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuntajeRonda = table.Column<int>(type: "int", nullable: false),
                    ConcursoModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Concursos_ConcursoModelId",
                        column: x => x.ConcursoModelId,
                        principalTable: "Concursos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_RoundModelId",
                table: "Preguntas",
                column: "RoundModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_ConcursoModelId",
                table: "Rounds",
                column: "ConcursoModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Preguntas_Rounds_RoundModelId",
                table: "Preguntas",
                column: "RoundModelId",
                principalTable: "Rounds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preguntas_Rounds_RoundModelId",
                table: "Preguntas");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Concursos");

            migrationBuilder.DropIndex(
                name: "IX_Preguntas_RoundModelId",
                table: "Preguntas");

            migrationBuilder.DropColumn(
                name: "RoundModelId",
                table: "Preguntas");
        }
    }
}
