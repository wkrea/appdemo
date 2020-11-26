using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.Controllers.DTOs;
using App.Api.Modelos;

namespace App.Api.Repositorio
{
  public interface IEstudianteRepo
  {
    // CRUD
    Task<Estudiante> obtenerEstudiante(int id);
    Task<List<EstudianteDto>> obtenerEstudiantes();

    // Post
    Task crearEstudiante(Estudiante estudiante);

    // Put
    Task editarEstudiante(Estudiante estudiante);
  }
}
