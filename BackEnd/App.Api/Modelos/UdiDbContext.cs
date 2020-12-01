using Microsoft.EntityFrameworkCore;
namespace App.Api.Modelos
{
    public class UdiDbContext : DbContext
    {
        public UdiDbContext(DbContextOptions<UdiDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Curso> Cursos {get; set;}
        public DbSet<Escuela> Escuelas {get; set;}
        public DbSet<Estudiante> Estudiantes {get; set;}
        public DbSet<Profesor> Profesores {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){

            builder.Entity<Curso>().HasMany(c => c.Estudiantes).WithOne(est => est.Curso);
            builder.Entity<Curso>().HasOne(c => c.profesor).WithMany(p => p.Cursos);

            builder.Entity<Escuela>().HasMany(e => e.profesores).WithOne(p => p.Escuela);

            builder.Entity<Estudiante>().HasOne(est => est.Curso).WithMany(c => c.Estudiantes);

            builder.Entity<Profesor>().HasOne(p => p.Escuela).WithMany(e => e.profesores);
            builder.Entity<Profesor>().HasMany(p => p.Cursos).WithOne(c => c.profesor);

            builder.Entity<Curso>().HasData(
                new Curso(){Id = 1, Nombre = "Servicios Web"},
                new Curso(){Id = 2, Nombre = "Sistemas Operativos"}
            );
            builder.Entity<Escuela>().HasData(
                new Escuela(){Id = 1, Nombre = "Universidad de Investigacion y Desarrollo", Ciudad = "Bucaramanga", Departamento = "Santander"}
            );
            builder.Entity<Estudiante>().HasData(
                new Estudiante(){Id = 1, Nombre = "Gabriel Alexander Castro Vargas"}
            );
            builder.Entity<Profesor>().HasData(
                new Profesor(){Id = 1, Nombre = "William Javier Trigos Guevara"}
            );
        }

    }
}
