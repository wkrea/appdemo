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
        Task<IEnumerable<Estudiante>> obtenerEstudiantes();

        //Post crear estudiante
        Task crearEstudiante(Estudiante estudiante);

        //Get cursos
        Task<Curso>  obtenerCurso(int id);

        Curso  obtenerCurs(int id);

        //Put estudiante
        Task editarEstudiante();

        //Delete estudiante
        Task eliminarEstudiante(Estudiante estudiante); 
    }
}
