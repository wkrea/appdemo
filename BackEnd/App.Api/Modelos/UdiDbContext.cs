using System;
using System.Buffers.Text;
using System.Runtime.Intrinsics.Arm.Arm64;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Modelos
{
    public class UdiDbContext : DbContext
    {
        public UdiDbContext(DbContextOptions<UdiDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Escuela>(esc =>
            {
                esc.HasKey(e => e.Id);
                esc.Property(p => p.Id).ValueGeneratedNever();
                esc.Property(e => e.Nombre).IsRequired();
                esc.Property(e => e.Ciudad).IsRequired();
                esc.Property(e => e.Departamento).IsRequired();
                esc.HasMany(e => e.Profesores).WithOne(p => p.Escuela);
            });

            modelBuilder.Entity<Profesor>(p =>
            {
                p.HasKey(p => p.Id);
                p.Property(p => p.Id).ValueGeneratedNever();
                p.Property(p => p.Nombre).IsRequired();
                p.HasOne(p => p.Escuela).WithMany(est => est.Profesores);
                p.HasMany(p => p.Cursos).WithOne(c => c.Profesor);
            });

            modelBuilder.Entity<Curso>(cur =>
            {
                cur.HasKey(c => c.Id);
                cur.Property(c => c.Id).ValueGeneratedNever();
                cur.Property(c => c.Nombre).IsRequired();
                cur.HasOne(c => c.Profesor).WithMany(p => p.Cursos);
                cur.HasMany(c => c.Estudiantes).WithOne(est => est.Curso);
            });

            modelBuilder.Entity<Estudiante>(est =>
            {
                est.HasKey(e => e.Id);
                est.Property(e => e.Id).ValueGeneratedNever();
                est.Property(e => e.Nombre).IsRequired();
                est.HasOne(e => e.Curso).WithMany(c => c.Estudiantes);
            });
        }
    }
}
