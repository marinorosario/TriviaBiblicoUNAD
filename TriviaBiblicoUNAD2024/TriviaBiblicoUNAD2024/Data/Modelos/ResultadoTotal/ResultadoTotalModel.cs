using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaBiblicoUNAD2024.Data.Modelos.ResultadoTotal
{
    [Table("ResultadoTotal")]
    public class ResultadoTotalModel
    {
       public int Id { get; set; }

       public string DetallesConcurso { get; set;} = string.Empty;
    }
}
