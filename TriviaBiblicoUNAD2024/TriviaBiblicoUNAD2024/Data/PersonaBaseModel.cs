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

        [NotMapped]
        public int? Edad
        {
            get
            {
                // Obtiene la fecha actual:
                DateOnly fechaActual = Kadomony.HoySoloFecha;

                // Comprueba que la se haya introducido una fecha válida; si 
                // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje 
                // de advertencia:
                if (FechaNac > fechaActual)
                {
                    Console.WriteLine("La fecha de nacimiento es mayor que la actual.");
                    return -1;
                }
                else
                {
                    int? edad = fechaActual.Year - FechaNac?.Year;

                    // Comprueba que el mes de la fecha de nacimiento es mayor 
                    // que el mes de la fecha actual:
                    if (FechaNac?.Month > fechaActual.Month)
                    {
                        --edad;
                    }

                    return edad;
                }
            }
        }
    }
}
