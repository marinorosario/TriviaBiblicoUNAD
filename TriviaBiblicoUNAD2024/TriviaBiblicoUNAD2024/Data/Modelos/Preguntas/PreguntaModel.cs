using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaBiblicoUNAD2024.Data.Modelos.Preguntas
{
    [Table("Preguntas")]
    public class PreguntaModel
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int Tiempo { get; set; }
        public int Puntaje { get; set; }

        public IEnumerable<RespuestaModel>? Respuestas { get; set;}
    }
}
