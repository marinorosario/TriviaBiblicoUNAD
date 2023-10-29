using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaBiblicoUNAD.Server.Modelos.Estudiantes
{
    [Table("Estudiantes"), Index(nameof(Matricula), IsUnique = true)]
    public class EstudianteModelo
    {
        [Key]
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
        public bool EstaBorrado { get; set; } = false;

        [NotMapped]
        public string GetNombreCompleto { 
            get {
                return $"{Nombre} {Apellidos}";
            } 
        }

        public string NombreCompleto()
        {
            return GetNombreCompleto;
        }
    }

}