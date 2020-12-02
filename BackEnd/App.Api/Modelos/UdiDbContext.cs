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
            // Datos semilla
            
            modelBuilder.Entity<Escuela>().HasData(
                new Escuela(){ Id = 1, Nombre = "Universidad Pontificia Bolivariana", Ciudad = "Bucaramanga", Departamento = "Santander"},
                new Escuela(){ Id = 2, Nombre = "Universidad de Santander", Ciudad = "Bucaramanga", Departamento = "Santander"},
                new Escuela(){ Id = 3, Nombre = "Universidad de Investigación y Desarrollo", Ciudad = "Bucaramanga", Departamento = "Santander"},
                new Escuela(){ Id = 4, Nombre = "Universidad de los Andes", Ciudad = "Bogotá", Departamento = "Cundinamarca"},
                new Escuela(){ Id = 5, Nombre = "Universidad Nacional", Ciudad = "Bogotá", Departamento = "Cundinamarca"}         
            );

            modelBuilder.Entity<Profesor>().HasData(
                new Profesor(){ Id = 1, Nombre = "William Trigos", EscuelaId=3},
                new Profesor(){ Id = 2, Nombre = "Martín Jaimes", EscuelaId=3},
                new Profesor(){ Id = 3, Nombre = "Sully Gomez", EscuelaId=3},
                new Profesor(){ Id = 4, Nombre = "Jean Bohorquez", EscuelaId=3},
                new Profesor(){ Id = 5, Nombre = "Elkin Plata", EscuelaId=3}
            ); 

            modelBuilder.Entity<Curso>().HasData( 
                new Curso(){ Id = 1, Nombre = "Servicios Web", ProfesorId=1 },
                new Curso(){ Id = 2, Nombre = "Estadística y probabilidades" , ProfesorId=3 },
                new Curso(){ Id = 3, Nombre = "Sistemas Operativos", ProfesorId=1 },
                new Curso(){ Id = 4, Nombre = "Redes II" , ProfesorId=2},
                new Curso(){ Id = 5, Nombre = "Análisis numérico" , ProfesorId=5 },
                new Curso(){ Id = 6, Nombre = "Metodología de la investigación" , ProfesorId=4 }
            );
            
            modelBuilder.Entity<Estudiante>().HasData(
                new Estudiante(){ Id = 1, Nombre = "Juan Camilo Valencia Silva", CursoId = 1 },
                new Estudiante(){ Id = 2, Nombre = "Laura  Calderón", CursoId = 1},
                new Estudiante(){ Id = 3, Nombre = "Dennis Suárez" , CursoId = 2},
                new Estudiante(){ Id = 4, Nombre = "Maria Calderón", CursoId = 3},
                new Estudiante(){ Id = 5, Nombre = "Fabian Villalba", CursoId = 4},
                new Estudiante(){ Id = 6, Nombre = "Laura Céspedes", CursoId = 5},
                new Estudiante(){ Id = 7, Nombre = "Jhoan Villabona", CursoId = 1},
                new Estudiante(){ Id = 8, Nombre = "Pedro Pereira", CursoId = 6}
            );
        }
