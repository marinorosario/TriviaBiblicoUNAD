using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNashENGINE.Share.DTOs.Equipo
{
    public class EquipoInsertarDTO
    {        
        [StringLength(255, MinimumLength = 3)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Iglesia { get; set; }

        [StringLength(255)]
        public string? Zona { get; set; }

        [StringLength(128)]
        public string? Logo { get; set; }

        public bool Estado { get; set; }

        public EquipoInsertarDTO()
        {
            Estado = false;
        }
    }
}
