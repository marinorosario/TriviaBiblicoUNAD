using SNashENGINE.Share;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TriviaBiblicoUNAD2024.Data.Modelos.Equipos;

namespace TriviaBiblicoUNAD2024.Data.Modelos.Participantes
{
    //Player
    [Table("Participantes")]
    public class ParticipanteModel : PersonaBaseModel
    {
        [Key]
        public int Id { get; set; }

        [EnumDataType(typeof(ePlayerStatus))]
        public ePlayerStatus Estado { get; set; }

        [ForeignKey(nameof(Equipo))]
        public int EquipoId { get; set; }
        public EquipoModel? Equipo { get; set; }

        public ParticipanteModel()
        {
            Estado = ePlayerStatus.Activo;
        }
    }
}
