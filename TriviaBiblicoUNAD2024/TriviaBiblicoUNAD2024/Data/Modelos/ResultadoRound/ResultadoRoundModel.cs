using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaBiblicoUNAD2024.Data.Modelos.ResultadoRound
{
    [Table("ResultadoRound")]
    public class ResultadoRoundModel
    {
        public int Id {  get; set; }
        public string DetallesRound { get; set; } = string.Empty;
        public int Puntaje { get; set; }
    }
}
