using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Modelos
{
    public class UdiDbContext : DbContext
    {
        public UdiDbContext(DbContextOptions<UdiDbContext> opts) : base(opts)
        {
            Database.EnsureCreated();
        }

        public DbSet<Curso> Cursos {get; set;}
        public DbSet<Escuela> Escuelas {get; set;}
        public DbSet<Profesor> Profesores {get; set;}
        public DbSet<Estudiante>  Estudiantes {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Curso>().HasKey(p => p.Id);
            builder.Entity<Curso>().HasData(
                new Curso(){ Id = 1, Nombre = "Sistemas Operativos"},
                new Curso(){ Id = 2, Nombre = "Servicios Web"},
                new Curso(){ Id = 3, Nombre = "Inteligencia Artificial I"}
            );
            builder.Entity<Escuela>().HasData(
                new Escuela(){ Id = 1, Nombre = "Universidad de Investigación y Desarrollo", Ciudad = "Bucaramanga", Departamento = "Santander"},
                new Escuela(){ Id = 2, Nombre = "Universidad Industrial de Santander", Ciudad = "Bucaramanga", Departamento = "Santander"}
            );
            /* builder.Entity<Profesor>().HasData(
                
            );
            builder.Entity<Estudiante>().HasData(

            ) */;
            
        }


    }
}
