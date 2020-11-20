using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Api.Modelos
{
    public class UdiDbContext : DbContext
    {
        public UdiDbContext(DbContextOptions<UdiDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.MigrateAsync();
        }

        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

        #region EFCore Code First appSettingsFile
        // https://www.sunjiangong.com/2020/03/30/EfCore-SqlLocalDb-Code-First-Database.html

        //private static string _connString;

        //private static string getConnString
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(_connString))
        //        {
        //            var appSettingsFile = Path.Combine(Environment.CurrentDirectory, "appsettings.json");
        //            var config = new ConfigurationBuilder()
        //                             .AddJsonFile(appSettingsFile)
        //                             .Build();
        //            _connString = config.GetSection("ConnectionStrings:UdiDb").Value;
        //        }
        //        return _connString;
        //    }
        //}
        ///// <summary>
        ///// https://www.sunjiangong.com/2020/03/30/EfCore-SqlLocalDb-Code-First-Database.html
        ///// https://www.thinktecture.com/en/entity-framework-core/changing-db-migration-schema-at-runtime-in-2-1/
        ///// </summary>
        ///// <param name="opts"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder opts)
        //{
        //    //opts.UseSqlServer(getConnString)
        //    //    .EnableSensitiveDataLogging();
        //    //opts.UseInMemoryDatabase("UdiDb")
        //    //    .EnableSensitiveDataLogging();
        //}
        #endregion

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
