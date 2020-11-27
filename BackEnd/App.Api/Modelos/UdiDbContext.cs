using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Modelos
{
    public class UdiDbContext : DbContext
    {
        public UdiDbContext(DbContextOptions<UdiDbContext> opts) : base(opts)
        {
        }
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Curso  #######################################################################
            // Nombre es requerido
            modelBuilder.Entity<Curso>().HasKey(curso => curso.Id);
            modelBuilder.Entity<Curso>()
                .Property(curso => curso.Id)
                .ValueGeneratedNever(); //no es incremental
            // Relaciones entre entidades 
            modelBuilder.Entity<Curso>()
                .HasOne(curso => curso.Profesor).WithMany(p => p.Cursos);
            modelBuilder.Entity<Curso>()
                .HasMany(curso => curso.Estudiantes).WithOne(est => est.Curso);

            //Profesor #######################################################################
            // Nombre es requerido
            modelBuilder.Entity<Profesor>().HasKey(profesor => profesor.Id);
            modelBuilder.Entity<Profesor>()
                .Property(profesor => profesor.Id)
                .ValueGeneratedNever();
            modelBuilder.Entity<Profesor>()
                .Property(profesor => profesor.Nombre)
                .IsRequired();
            // Relaciones entre entidades 
            modelBuilder.Entity<Profesor>()
                .HasOne(profesor => profesor.Escuela).WithMany(es => es.Profesores);
            modelBuilder.Entity<Profesor>()
                .HasMany(profesor => profesor.Cursos).WithOne(c => c.Profesor);


            //Estudiante  #######################################################################
            // Nombre es requerido
            modelBuilder.Entity<Estudiante>().HasKey(estudiante => estudiante.Id);
            modelBuilder.Entity<Estudiante>()
                .Property(estudiante => estudiante.Id)
                .ValueGeneratedNever();
            modelBuilder.Entity<Estudiante>()
                .Property(estudiante => estudiante.Nombre)
                .IsRequired();
            // Relaciones entre entidades 
            modelBuilder.Entity<Estudiante>()
                .HasOne(estudiante => estudiante.Curso).WithMany(cu => cu.Estudiantes);

            //Escuela  #######################################################################
            // Nombre y ciudad es requerido
            modelBuilder.Entity<Escuela>().HasKey(escuela => escuela.Id);
            modelBuilder.Entity<Escuela>()
                .Property(escuela => escuela.Id)
                .ValueGeneratedNever();
            modelBuilder.Entity<Escuela>()
                .Property(escuela => escuela.Nombre)
                .IsRequired();
            modelBuilder.Entity<Escuela>()
                .Property(escuela => escuela.Ciudad)
                .IsRequired();
            //Relaciones entre entidades 
            modelBuilder.Entity<Escuela>()
                .HasMany(escuela => escuela.Profesores).WithOne(pro => pro.Escuela);

        }
    }
}
