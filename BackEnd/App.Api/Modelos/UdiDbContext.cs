using Microsoft.EntityFrameworkCore;

namespace App.Api.Modelos
{
    public class UdiDbContext : DbContext
    {
        public UdiDbContext(DbContextOptions<UdiDbContext> opts) : base(opts)
        {

        }

        public DbSet<Escuela> escuelas { get; set; }
        public DbSet<Profesor> profesores { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<Estudiante> estudiantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Model Builder
            base.OnModelCreating(modelBuilder);

            //Curso
            modelBuilder.Entity<Curso>().HasKey(curso => curso.id);
            modelBuilder.Entity<Curso>().Property(curso => curso.id).ValueGeneratedNever();
            modelBuilder.Entity<Curso>().HasOne(curso => curso.profesor).WithMany(profesores => profesores.cursos);
            modelBuilder.Entity<Curso>().HasMany(curso => curso.estudiantes).WithOne(estudiantes => estudiantes.curso);

            //Profesor
            modelBuilder.Entity<Profesor>().HasKey(profesor => profesor.id);
            modelBuilder.Entity<Profesor>().Property(profesor => profesor.id).ValueGeneratedNever();
            modelBuilder.Entity<Profesor>().HasOne(profesor => profesor.escuela).WithMany(escuelas => escuelas.profesores);
            modelBuilder.Entity<Profesor>().HasMany(profesor => profesor.cursos).WithOne(cursos => cursos.profesor);

            //Estudiante
            modelBuilder.Entity<Estudiante>().HasKey(estudiante => estudiante.id);
            modelBuilder.Entity<Estudiante>().Property(estudiante => estudiante.id).ValueGeneratedNever();
            modelBuilder.Entity<Estudiante>().HasOne(estudiante => estudiante.curso).WithMany(cursos => cursos.estudiantes);

            //Escuela
            modelBuilder.Entity<Escuela>().HasKey(escuela => escuela.id);
            modelBuilder.Entity<Escuela>().Property(escuela => escuela.id).ValueGeneratedNever();
            modelBuilder.Entity<Escuela>().HasMany(escuela => escuela.profesores).WithOne(profesores => profesores.escuela);
        }
    }
}
