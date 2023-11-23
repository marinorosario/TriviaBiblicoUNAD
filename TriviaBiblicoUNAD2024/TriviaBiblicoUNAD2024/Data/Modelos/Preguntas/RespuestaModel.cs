using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaBiblicoUNAD2024.Data.Modelos.Preguntas
{
    [Table("Respuestas")]
    public class RespuestaModel
    {
        [Key]
        public int Id { get; set; }
        public string Respuesta { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public bool Estado { get; set; }

        public RespuestaModel()
        {
            Estado = true;
            IsCorrect = false;
        }
    }
}
