using System.Diagnostics.Tracing;
using System.IO;
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

        public DbSet<Curso> cursos {get; set;}
        public DbSet<Escuela> escuelas {get; set;}
        public DbSet<Profesor> profesores {get; set;}
        public DbSet<Estudiante>  estudiantes {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Estudiante>()
            .HasOne(e => e.Curso)
            .WithMany(c => c.Estudiantes)
            .HasForeignKey(e => e.CursoId);

            builder.Entity<Profesor>()
            .HasOne(p => p.Escuela)
            .WithMany(e => e.Profesores)
            .HasForeignKey(p => p.EscuelaId);

            builder.Entity<Curso>()
            .HasOne(c => c.Profesor)
            .WithMany(p => p.Cursos)
            .HasForeignKey(c => c.ProfesorId);
            /*
                -Cuales son los campos requeridos en los modelos
                -Nombre
                -Ciudad
                 No permitir que el id no se autogenere
            */
            //Id no autogenerado
            builder.Entity<Escuela>(esc =>
            {
                esc.HasKey(e => e.Id);
                esc.Property(p => p.Id).ValueGeneratedNever();
            });
            builder.Entity<Estudiante>(est =>
            {
                est.HasKey(e => e.Id);
                est.Property(p => p.Id).ValueGeneratedNever();
            });
            builder.Entity<Curso>(est =>
            {
                est.HasKey(c => c.Id);
                est.Property(p => p.Id).ValueGeneratedNever();
            });
            builder.Entity<Profesor>(est =>
            {
                est.HasKey(p => p.Id);
                est.Property(p => p.Id).ValueGeneratedNever();
            });

            //Relacion entre tablas
            /*builder.Entity<Curso>().HasMany(c => c.Estudiantes).WithOne(est => est.Curso);
            builder.Entity<Estudiante>().HasOne(e => e.Curso).WithMany(cur => cur.Estudiantes);
            
            builder.Entity<Curso>().HasOne(c => c.Profesor).WithMany(pro => pro.Cursos);
            builder.Entity<Profesor>().HasMany(p => p.Cursos).WithOne(cur => cur.Profesor);

            builder.Entity<Escuela>().HasMany(e => e.Profesores).WithOne(pro => pro.Escuela);
            builder.Entity<Profesor>().HasOne(p => p.Escuela).WithMany(esc => esc.Profesores);*/

            //Campos requeridos
            builder.Entity<Escuela>().Property(esc => esc.Nombre).IsRequired();
            builder.Entity<Escuela>().Property(esc => esc.Ciudad).IsRequired();
            builder.Entity<Estudiante>().Property(est => est.Nombre).IsRequired();
            builder.Entity<Profesor>().Property(pro => pro.Nombre).IsRequired();
            builder.Entity<Curso>().Property(cur => cur.Nombre).IsRequired();

            //Creacion de los datos que siempre estaran en la base de datos
            builder.Entity<Curso>().HasData(
                new Curso(){ Id = 1, Nombre = "6L", ProfesorId = 1},
                new Curso(){ Id = 2, Nombre = "7L", ProfesorId = 2}
            );
            builder.Entity<Escuela>().HasData(
                new Escuela(){ Id = 1, Nombre = "Universidad de Investigación y Desarrollo", Ciudad = "Bucaramanga", Departamento = "Santander"}
            );
            builder.Entity<Profesor>().HasData(
                new Profesor(){ Id=1, Nombre="William Javier Trigos Guevara", EscuelaId = 1 },
                new Profesor(){ Id=2, Nombre="Alexandra Beltran", EscuelaId = 1 }
            );
            builder.Entity<Estudiante>().HasData(
                new Estudiante(){ Id = 1, Nombre = "Marly Alexandra Acosta Arenales", CursoId = 1},
                new Estudiante(){ Id = 2, Nombre = "Estudiante Random", CursoId = 2}
            );
        }
    }
}
