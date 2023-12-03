using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNashENGINE.Share.DTOs.Preguntas
{
    public class RespuestaInsertarDTO
    {        
        public string Respuesta { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public bool Estado { get; set; }
    }
}
