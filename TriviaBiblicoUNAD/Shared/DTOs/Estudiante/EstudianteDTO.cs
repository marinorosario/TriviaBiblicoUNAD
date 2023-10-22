using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaBiblicoUNAD.Shared.DTOs.Estudiante
{
    public class EstudianteDTO
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

        public string? GetNombreCompleto { get; set; }

        public int Edad 
        {
            get
            {
                DateTime? fechaActual = DateTime.Now;

                if (FechNac <= fechaActual)
                {
                    int edad = fechaActual.Value.Year - FechNac.Value.Year;

                    // Comprueba que el mes de la fecha de nacimiento es mayor 
                    // que el mes de la fecha actual:
                    if (FechNac.Value.Month > fechaActual.Value.Month)
                    {
                        --edad;
                    }

                    return edad;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
