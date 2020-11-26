using Microsoft.EntityFrameworkCore;

namespace App.Api.Modelos
{
    public class UdiDbContext
    {
        public UdiDbContext() {
            
        }
        public DbSet<Curso>  cursos { get; set; }
        public DbSet<Escuela> escuelas { get; set; }
        public DbSet<Profesor> profesores { get; set; }
        public DbSet<Estudiante> estudiantes { get; set; }
     }
}
