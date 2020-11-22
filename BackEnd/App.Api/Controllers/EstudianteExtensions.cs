using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    public class EstudianteExtensions
    {
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
