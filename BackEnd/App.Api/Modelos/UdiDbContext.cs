using App.Api.Controllers.DTOs;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Modelos
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
    public DbSet<EstudianteDto> Estudiantes {get; set;}

    protected override void OnModelCreating(ModelBuilder builder){

        builder.Entity<Escuela>().HasData(
          new Escuela(){ Id=1, Nombre="Escuela 1", Ciudad = "Ciudad", Departamento = "Departamento" }
        );

        builder.Entity<Profesor>().HasData(
          new Profesor(){ Id=1, Nombre="Profesor 1", EscuelaId = 1 }
        );

        builder.Entity<Curso>().HasData(
          new Curso(){ Id=1, Nombre="Curso 1", ProfesorId = 1 }
        );

        builder.Entity<EstudianteDto>().HasData(
          new EstudianteDto(){ Id = 1, Nombre = "Estudiante 1", CursoId = 1, ProfesorId = 1, EscuelaId = 1  },
          new EstudianteDto(){ Id = 2, Nombre = "Estudiante 2", CursoId = 2, ProfesorId = 2, EscuelaId = 2  }
        );

    }
  }
}
