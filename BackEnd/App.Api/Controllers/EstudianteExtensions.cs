using System;
using App.Api.Controllers.DTOs;
using App.Api.Modelos;

namespace App.Api.Controllers
{   
    public static class EstudianteExtensions
    {
        public static Estudiante ToModel(EstudianteDTO EstudianteDto, Curso curso)
        {
           if (curso.Id != EstudianteDto.CursoId) throw new NotSupportedException();
            return new Estudiante
            {
                Id = EstudianteDto.Id,
                Nombre = EstudianteDto.Nombre,
                Curso = curso
            };
        }

        public static void Update(Estudiante EstudianteToUpdate, EstudianteDTO EstudianteDto, Curso curso)
        {
            if (EstudianteDto.Id != EstudianteToUpdate.Id) throw new NotSupportedException();
            EstudianteToUpdate.Nombre = EstudianteDto.Nombre;
            EstudianteToUpdate.Curso = curso;   
        }
        public static EstudianteDTO ToDTO(Estudiante Estudiante)
        {
            return new EstudianteDTO
            {
                Id = Estudiante.Id,
                Nombre = Estudiante.Nombre,
                CursoId = Estudiante.CursoId,
                ProfesorId = Estudiante.Curso.Profesor.Id,
                EscuelaId = Estudiante.Curso.Profesor.Escuela.Id
            };
        }
    }
}
