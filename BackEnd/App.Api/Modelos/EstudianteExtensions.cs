using System;
using App.api.Modelos;
using App.Api.Controllers.DTOs;

namespace App.Api.Modelos
{
    public static class EstudianteDTOExtensions
    {

        public static void Update(this Estudiante EstudianteToUpdate, EstudianteDTO EstudianteDto, Curso curso)
        {
            if (EstudianteDto.Id != EstudianteToUpdate.Id) throw new NotSupportedException();
            EstudianteToUpdate.Nombre = EstudianteDto.Nombre;
            EstudianteToUpdate.Curso = curso;
        }

        public static Estudiante ToModel(this EstudianteDTO EstudianteDto, Curso curso)
        {
            if (curso.Id != EstudianteDto.CursoId) throw new NotSupportedException();
            return new Estudiante
            {
                Id = EstudianteDto.Id,
                Nombre = EstudianteDto.Nombre,
                Curso = curso
            };
        }

        public static EstudianteDTO ToDTO(this Estudiante Estudiante)
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
