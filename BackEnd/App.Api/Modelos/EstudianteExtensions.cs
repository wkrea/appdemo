using System;
using App.Api.Controllers.DTOs;

namespace App.Api.Modelos
{
    public static class EstudianteDTOExtensions
    {
        
        public static void Update(this Estudiante EstudianteToUpdate, EstudianteDTO EstudianteDto, Curso curso)
        {
            if (EstudianteDto.Id != EstudianteToUpdate.Id) throw new NotSupportedException();
            EstudianteToUpdate.Nombre = EstudianteDto.nombre;
            EstudianteToUpdate.Curso = curso;
        }

        public static Estudiante ToModel(this EstudianteDTO EstudianteDto, Curso curso)
        {
            if (curso.Id != EstudianteDto.CursoId) throw new NotSupportedException();
            return new Estudiante
            {
                Id = EstudianteDto.Id,
                Nombre = EstudianteDto.nombre,
                Curso = curso
            };
        }

        public static EstudianteDTO ToDTO(this Estudiante Estudiante)
        {
            return new EstudianteDTO
            {
                Id = Estudiante.Id,
                nombre = Estudiante.Nombre,
                CursoId = Estudiante.CursoId,
                ProfesorId = Estudiante.Curso.profesor.Id,
                EscuelaId = Estudiante.Curso.profesor.Escuela.Id
            };
        }
    }
}
