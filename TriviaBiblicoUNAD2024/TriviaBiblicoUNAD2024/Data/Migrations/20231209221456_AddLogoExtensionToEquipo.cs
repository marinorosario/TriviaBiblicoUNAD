using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriviaBiblicoUNAD2024.Migrations
{
    /// <inheritdoc />
    public partial class AddLogoExtensionToEquipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoExtension",
                table: "Equipos",
                type: "nvarchar(24)",
                maxLength: 24,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoExtension",
                table: "Equipos");
        }
    }
}
