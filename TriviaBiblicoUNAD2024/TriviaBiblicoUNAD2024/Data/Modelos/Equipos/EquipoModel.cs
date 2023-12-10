using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaBiblicoUNAD2024.Data.Modelos.Equipos
{
    //Team
    [Table("Equipos")]
    public class EquipoModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Iglesia { get; set; }

        [StringLength(255)]
        public string? Zona { get; set; }

        [StringLength(128)]
        public string? Logo { get; set; }

        [StringLength(24)]
        public string? LogoExtension { get; set; }

        public bool Estado { get; set; }

        public EquipoModel()
        {
            Estado = true;
        }
    }
}
