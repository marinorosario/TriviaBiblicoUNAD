using SNashENGINE.Share;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaBiblicoUNAD2024.Data
{
    public class PersonaBaseModel
    {
        [StringLength(255, MinimumLength = 3)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Apellidos { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? FechaNac { get; set; }

        [EnumDataType(typeof(eSexo))]
        public eSexo Sexo { get; set; }

        [ForeignKey(nameof(Usuario))]
        public string UsuarioId { get; set; } = string.Empty;
        public ApplicationUser? Usuario { get; set; }
    }
}
