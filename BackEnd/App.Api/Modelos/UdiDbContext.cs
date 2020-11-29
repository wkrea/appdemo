
using Microsoft.EntityFrameworkCore;

namespace App.Api.Modelos
{
    public class UdiDbContext : DbContext
    {
        public UdiDbContext(DbContextOptions<UdiDbContext> opts) : base(opts)
        {
    
        }

        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<curso> cursos { get; set; }
        public DbSet<Estudiante> estudiantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
