using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Repositorios
{
    public interface IEstudianteRepo
    {
        Task<Estudiante> obtenerEstudiante(int id); 
        Task<IEnumerable<Estudiante>> obtenerEstudiantes();
        Task crearEstudiante(Estudiante estudiante);
        Task<Curso>  obtenerCurso(int id);
        Task editarEstudiante();
        Task eliminarEstudiante(Estudiante estudiante); 
    }
}
