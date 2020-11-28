using Microsoft.EntityFrameworkCore;

namespace App.Api.Modelos
{
    public class UdiDbContext : DbContext{
<<<<<<< HEAD
        public DbSet<Curso> cursos {get;set;}
        public DbSet<Estudiante> estudiantes {get;set;}

        public DbSet<Profesor> profesores {get;set;}
        public DbSet<Escuela> escuelas {get;set;}

        protected override void OnModelCreating(ModelBuilder builder){
    
        }
=======
        
>>>>>>> 45cdb5b30db6e84a80c4c50bdbe033d9441fdb58
    }
}
