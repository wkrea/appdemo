using Microsoft.EntityFrameworkCore;

namespace App.api.Modelos {
    public class UdiDbContext : DbContext 
    {

    public UdiDbContext(DbContextOptions<UdiDbContext> opts) : base(opts)
    {



        
    }

    public DbSet<Estudiante>Estudiantes {get; set;}
    public DbSet<Escuela>Escuelas {get; set;}
    public DbSet<Profesor>Profesores {get; set;}
    public DbSet<Curso>Cursos {get; set;}
    
    }





}
