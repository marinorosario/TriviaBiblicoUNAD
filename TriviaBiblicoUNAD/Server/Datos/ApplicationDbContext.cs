using Microsoft.EntityFrameworkCore;

namespace TriviaBiblicoUNAD.Server.Datos
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones) { }
       
    }
}
