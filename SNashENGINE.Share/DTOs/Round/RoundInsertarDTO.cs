using SNashENGINE.Share.DTOs.Preguntas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNashENGINE.Share.DTOs.Round
{
    public class RoundInsertarDTO
    {      

        //Coleccion de Preguntas para la ronda o Round
        public ICollection<PreguntaDTO>? Preguntas { get; set; }
        public int PuntajeRonda { get; set; }
    }
}
