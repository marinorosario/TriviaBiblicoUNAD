using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNashENGINE.Share.DTOs.Participantes
{
    public class ParticipanteDTO : ParticipanteInsertarDTO
    {
        public int Id { get; set; }

        [EnumDataType(typeof(ePlayerStatus))]
        public ePlayerStatus Estado { get; set; }

        public string UsuarioId { get; set; } = string.Empty;
    }
}
