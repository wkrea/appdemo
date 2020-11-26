using Microsoft.EntityFrameworkCore;
namespace App.Api.Modelos
{
    public class UdiDbContext : DbContext
    {
        public UdiDbContext(DbContextOptions<UdiDbContext> opciones) : base(opciones)
        {
            Database.EnsureCreated();
        }

        public DbSet<Curso> Cursos {get; set;}
        public DbSet<Escuela> Escuelas {get; set;}
        public DbSet<Profesor> Profesores {get; set;}
        public DbSet <Estudiante> Estudiantes {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Curso>().HasKey(p => p.Id);
            builder.Entity<Curso>().HasData(
                new Curso(){ Id = 1, Nombre = "Servicios Web"},
                new Curso(){ Id = 2, Nombre = "Estadisticas y probabilidades"},
                new Curso(){ Id = 3, Nombre = "Sistemas Operativos"},
                new Curso(){ Id = 4, Nombre = "Redes II"},
                new Curso(){ Id = 5, Nombre = "Análisis numérico"},
                new Curso(){ Id = 6, Nombre = "Metodología de la investigación"}
            );

            builder.Entity<Escuela>().HasData(
                new Escuela(){ Id = 1, Nombre = "Universidad Pontificia Bolivariana", Ciudad = "Bucaramanga", Departamento = "Santander"},
                new Escuela(){ Id = 2, Nombre = "Universidad de Santander", Ciudad = "Bucaramanga", Departamento = "Santander"},
                new Escuela(){ Id = 3, Nombre = "Universidad de Investigación y Desarrollo", Ciudad = "Bucaramanga", Departamento = "Santander"},
                new Escuela(){ Id = 4, Nombre = "Universidad de los Andes", Ciudad = "Bogotá", Departamento = "Cundinamarca"},
                new Escuela(){ Id = 5, Nombre = "Universidad Nacional", Ciudad = "Bogotá", Departamento = "Cundinamarca"}         
            );

            builder.Entity<Estudiante>().HasData(
                new Estudiante(){ Id = 1, Nombre = "Juan Camilo Valencia Silva"},
                new Estudiante(){ Id = 2, Nombre = "Laura Juliana Lozano Calderón"},
                new Estudiante(){ Id = 3, Nombre = "Dennis Orlando Jaimes Suárez"},
                new Estudiante(){ Id = 4, Nombre = "Maria Alejandra Aceros Calderón"},
                new Estudiante(){ Id = 5, Nombre = "Fabian Andrés Rodriguez Villalba"},
                new Estudiante(){ Id = 6, Nombre = "Laura Daniela Rueda Céspedes"},
                new Estudiante(){ Id = 7, Nombre = "Jhoan Stiven Sachica Villabona"},
                new Estudiante(){ Id = 8, Nombre = "Pedro Pablo Perez Pereira"}
            );

            builder.Entity<Profesor>().HasData(
                new Profesor(){ Id = 1, Nombre = "William Javier Trigos Guevara"},
                new Profesor(){ Id = 2, Nombre = "Martín Perez Jaimes"},
                new Profesor(){ Id = 3, Nombre = "Sully Lineth Moreno Gomez"},
                new Profesor(){ Id = 4, Nombre = "Jean Pier Granados Bohorquez"},
                new Profesor(){ Id = 5, Nombre = "Elkin David Diaz Plata"}
            );       
        }
    }
}