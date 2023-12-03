using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TriviaBiblicoUNAD2024.Data.Modelos.Rounds;

namespace TriviaBiblicoUNAD2024.Data.Modelos.Concursos
{
    [Table("Concursos")]
    public class ConcursoModel
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public ICollection<RoundModel>? Rounds { get; set; }
    }
}
