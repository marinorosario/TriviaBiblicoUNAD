using Microsoft.EntityFrameworkCore;
using TriviaBiblicoUNAD.Server.Modelos.Estudiantes;

namespace TriviaBiblicoUNAD.Server.Datos
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeder Estudiantes
            modelBuilder.Entity<EstudianteModelo>()
                .HasData(
                new EstudianteModelo { Id = 1, Matricula = "20230024", Nombre = "Jose", Apellidos = "Perez Campusano", Carrera = "Ing de Softeware", FechNac = new DateTime(2000,3,20) },
                new EstudianteModelo { Id = 2, Matricula = "20230125", Nombre = "Jennifer", Apellidos = "Mendez Gonzalez", Carrera = "Ing de Softeware", FechNac = new DateTime(2003, 5, 10) }
                );

            base.OnModelCreating(modelBuilder);
        }

        //Regsitro de Tablas
        public DbSet<EstudianteModelo> Estudiantes => Set<EstudianteModelo>();

        //Registro de Relaciones
       
        //Tablas temporales

        //Tablas Json


        //seeders

    }
}
