using System.ComponentModel.DataAnnotations;

namespace TriviaBiblicoUNAD.Shared.DTOs.Estudiante
{
    public class EstudianteEditarDTO
    {
        public int Id { get; set; }

        [StringLength(24), Required]
        public string Matricula { get; set; } = string.Empty;

        [StringLength(64), Required]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(64)]
        public string? Apellidos { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechNac { get; set; }

        [DataType(DataType.MultilineText), StringLength(128)]
        public string? Carrera { get; set; }
    }
}
