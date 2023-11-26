using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNashENGINE.Share.DTOs.Participantes
{
    public class ParticipanteInsertarDTO
    {
        [StringLength(255, MinimumLength = 3, ErrorMessage = "'{0}' Solo se permite valores desde {2} hasta  {1} ")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Apellidos { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? FechaNac { get; set; }

        [EnumDataType(typeof(eSexo))]
        public eSexo Sexo { get; set; }

        public int EquipoId { get; set; }
    }
}
