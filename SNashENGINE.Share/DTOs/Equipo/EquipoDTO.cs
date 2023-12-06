using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNashENGINE.Share.DTOs.Equipo
{
    public class EquipoDTO : EquipoInsertarDTO
    {
        [Key]
        public int Id { get; set; }

        public bool Estado { get; set; }
    }
}
