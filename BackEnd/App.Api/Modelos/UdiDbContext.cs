using Microsoft.EntityFrameworkCore;

namespace App.Api.Modelos
{
    public class UdiDbContext : DbContext{

        public UdiDbContext(DbContextOptions<UdiDbContext> opts) : base(opts)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated(); 
        }
        public DbSet<Escuela> escuelas {get;set;}
        public DbSet<Profesor> profesores {get;set;}
        public DbSet<Curso> cursos {get;set;}
        public DbSet<Estudiante> estudiantes {get;set;}
        
        

        protected override void OnModelCreating(ModelBuilder builder){

        
        builder.Entity<Escuela>(es =>
        {
            es.HasKey(e => e.Id);
            es.Property(e => e.Id).ValueGeneratedNever();
            es.Property(e => e.Nombre).IsRequired();
            es.Property(e => e.Ciudad).IsRequired();
            es.Property(e => e.Departamento);
            es.HasMany(e => e.Profesores).WithOne(e => e.Escuela);
        });

        builder.Entity<Profesor>(p =>
        {
            p.HasKey(p => p.Id);
            p.Property(p => p.Id).ValueGeneratedNever();
            p.Property(p => p.Nombre).IsRequired();
            p.HasOne(p => p.Escuela).WithMany(es => es.Profesores);
            p.HasMany(p => p.Cursos).WithOne(c => c.Profesor);
        });

        builder.Entity<Curso>(c =>
        {
            c.HasKey(c => c.Id);
            c.Property(c => c.Id).ValueGeneratedNever();
            c.Property(c => c.Nombre).IsRequired();
            c.HasOne(c => c.Profesor).WithMany(p => p.Cursos);
            c.HasMany(c => c.Estudiantes).WithOne(est => est.Curso);
        });

        builder.Entity<Estudiante>(est =>
        {
            est.HasKey(est => est.Id);
            est.Property(est => est.Id).ValueGeneratedNever();
            est.Property(est => est.Nombre).IsRequired();
            est.HasOne(est => est.Curso).WithMany(c => c.Estudiantes);
            
        });

        builder.Entity<Escuela>().HasData(
          new Escuela(){ Id=1, Nombre="Escuela 1", Ciudad="Bucaramanga", Departamento="Santander" },
          new Escuela(){ Id=2, Nombre="Escuela 2", Ciudad="Cucuta", Departamento="Norte de Santander" }
        );

        builder.Entity<Profesor>().HasData(
          new Profesor(){ Id=1, Nombre="William Trigos", EscuelaId=1 },
          new Profesor(){ Id=2, Nombre="Ricardo ", EscuelaId=2 }
        );

        builder.Entity<Curso>().HasData(
          new Curso(){ Id=1, Nombre="Curso 1", ProfesorId=1 },
          new Curso(){ Id=2, Nombre="Curso 2 ", ProfesorId=2 }
        );
        }
    }
}
