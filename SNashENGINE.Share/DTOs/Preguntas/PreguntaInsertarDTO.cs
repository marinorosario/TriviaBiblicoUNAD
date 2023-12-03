using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNashENGINE.Share.DTOs.Preguntas
{
    public class PreguntaInsertarDTO
    {        
        public string Titulo { get; set; } = string.Empty;
        public int Tiempo { get; set; }
        public int Puntaje { get; set; }

        public IEnumerable<RespuestaDTO>? Respuestas { get; set; }
    }
}
