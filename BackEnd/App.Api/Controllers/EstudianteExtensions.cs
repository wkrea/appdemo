using App.Api.Controllers.DTOs;
using App.Api.Modelos;

namespace App.Api.Controllers
{
    public class EstudianteExtensions
    {
        public EstudianteExtensions(UdiDbContext udiDbContext)
        {
        }

        public static Estudiante ToModel(EstudianteDTO estudianteDTO, Curso curso)
        {
            return new Estudiante();
        }

        public static void Update(Estudiante estudianteToUpdate, EstudianteDTO estudianteDTO, Curso curso)
        {

        }

        public static EstudianteDTO ToDTO(Estudiante estudiante)
        {
            return new EstudianteDTO();
        }
    }
}
