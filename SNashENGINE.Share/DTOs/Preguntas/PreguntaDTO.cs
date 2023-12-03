using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNashENGINE.Share.DTOs.Preguntas
{
    public class PreguntaDTO : PreguntaInsertarDTO
    {
        public int Id { get; set; }
    }
}
