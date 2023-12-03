using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TriviaBiblicoUNAD2024.Data.Modelos.Preguntas;

namespace TriviaBiblicoUNAD2024.Data.Modelos.Rounds
{
    [Table("Rounds")]
    public class RoundModel
    {

        [Key] //Clave primaria para la table ne la Base de Datos
        public int Id { get; set; }

        //Coleccion de Preguntas para la ronda o Round
        public ICollection<PreguntaModel>? Preguntas { get; set; }
        public int PuntajeRonda { get; set; }
    }
}
