using Microsoft.EntityFrameworkCore;
using App.api.Modelos;

namespace App.api.Modelos
{

  public class UdiDbContext: DbContext
  {

    public UdiDbContext(DbContextOptions<UdiDbContext> opts) :  base(opts)
    {
      Database.EnsureCreated();
    }

    public DbSet<Escuela> Escuelas {get; set;}
    public DbSet<Profesor> Profesores {get; set;}
    public DbSet<Curso> Cursos {get; set;}
    public DbSet<Estudiante> Estudiantes {get; set;}

    protected override void OnModelCreating(ModelBuilder builder){

    }
  }
}
