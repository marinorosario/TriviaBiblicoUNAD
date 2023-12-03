using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TriviaBiblicoUNAD2024.Data.Modelos.Concursos;
using TriviaBiblicoUNAD2024.Data.Modelos.Equipos;
using TriviaBiblicoUNAD2024.Data.Modelos.Participantes;
using TriviaBiblicoUNAD2024.Data.Modelos.Preguntas;
using TriviaBiblicoUNAD2024.Data.Modelos.Rounds;

namespace TriviaBiblicoUNAD2024.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<EquipoModel> Equipos => Set<EquipoModel>();
        public DbSet<ParticipanteModel> Participantes => Set<ParticipanteModel>();
        public DbSet<RespuestaModel> Respuestas => Set<RespuestaModel>();
        public DbSet<PreguntaModel> Preguntas => Set<PreguntaModel>();
        public DbSet<RoundModel> Rounds => Set<RoundModel>();
        public DbSet<ConcursoModel> Concursos => Set<ConcursoModel>();
    }
}
