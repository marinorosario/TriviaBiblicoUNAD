using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TriviaBiblicoUNAD2024.Data.Modelos.Equipos;
using TriviaBiblicoUNAD2024.Data.Modelos.Participantes;
using TriviaBiblicoUNAD2024.Data.Modelos.Preguntas;

namespace TriviaBiblicoUNAD2024.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<EquipoModel> Equipos => Set<EquipoModel>();
        public DbSet<ParticipanteModel> Participantes => Set<ParticipanteModel>();
        public DbSet<RespuestaModel> Respuestas => Set<RespuestaModel>();
        public DbSet<PreguntaModel> Preguntas => Set<PreguntaModel>();
    }
}
