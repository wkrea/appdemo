using App.Api.Controllers;
using App.Api.Modelos;
using System.Data;
using System;

namespace App.Api.Controller
{
    public class EstudianteExtensions
    {
        public EstudianteExtensions(UdiDbContext udiDbContext)
        {
        }

        public static Estudiante ToModel(Estudiante estudiante, Curso curso)
        {
            return new Estudiante();
        }

        public static void Update(Estudiante estudianteToUpdate, Estudiante estudianteDTO, Curso curso)
        {

        }
        public static Estudiante ToDTO(Estudiante estudiante)
        {
            return new Estudiante();
        }

    }
}