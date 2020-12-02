using App.Api.Controllers.DTOs;
using App.Api.Modelos;

namespace App.Api.Controllers
{   
    public static class EstudianteExtensions
    {
        public static Estudiante ToModel(EstudianteDTO EstudianteDto, Curso curso)
        {
           Estudiante estudiante = new Estudiante();
           estudiante.Id = EstudianteDto.Id;
           estudiante.Nombre = EstudianteDto.Nombre;
           estudiante.CursoId = EstudianteDto.CursoId;

           return estudiante;
        }

        public static void Update(Estudiante EstudianteToUpdate, EstudianteDTO EstudianteDto, Curso curso)
        {
            
        }
        public static EstudianteDTO ToDTO(Estudiante Estudiante)
        {
            EstudianteDTO EstudianteDto = new EstudianteDTO();
            EstudianteDto.Id = Estudiante.Id;
            EstudianteDto.Nombre = Estudiante.Nombre;
            EstudianteDto.CursoId = Estudiante.CursoId;
            EstudianteDto.ProfesorId = Estudiante.Curso.ProfesorId;
            EstudianteDto.EscuelaId = Estudiante.Curso.Profesor.EscuelaId;

            return EstudianteDto;
        }
    }
}
