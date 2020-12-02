using System.Linq;
using App.Api.Modelos;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Servicios
{
    public static class EstudianteServicio
    {
        public static IQueryable<Estudiante> Estudiantes(this UdiDbContext _dbContext) {
            return _dbContext
                    .Estudiantes
                    .Include(e => e.Curso.Profesor.Escuela);
        }

        public static IQueryable<Curso> Cursos(this UdiDbContext _dbContext)
        {
            return _dbContext
                    .Cursos
                    .Include(c => c.Profesor);
        }
    }
}
