using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Repositorios
{
    public interface IEstudianteRepo
    {
        //Get estudiante especifico
        Task<Estudiante> obtenerEstudiante(int id);

        //Get lista de estudiantes      
        Task<List<Estudiante>> obtenerEstudiantes();

        //Post crear estudiante
        Task crearEstudiante(Estudiante estudiante);

        //Put estudiante
        Task editarEstudiante(Estudiante estudiante);

        //Delete estudiante
        Task eliminarEstudiante(int id);
    }
}
