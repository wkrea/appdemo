using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using App.Api.Repositorios;

namespace App.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {

        private readonly IEstudianteRepo context;
        public EstudiantesController(IEstudianteRepo estudianteRepo)
        {
            context = estudianteRepo;
        }

        /// <summary>
        /// GET (Read all) /Estudiantes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EstudianteDTO>>> GetAll()
        {
            var Estudiantes = await context.obtenerEstudiantes();
            // return Ok(Estudiantes);
            return Ok(Estudiantes.Select(s => s.ToDTO()));
        }

        /// <summary>
        /// GET (Read) /Estudiante/{id}
        /// https://localhost:5001/estudiantes/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstudianteDTO>> Get(int id)
        {
            var Estudiante = await context.obtenerEstudiante(id);

            if (Estudiante == null)
                return NotFound();

            return Ok(Estudiante.ToDTO());
        }

        /// <summary>
        /// POST (Create) /Estudiante
        /// </summary>
        /// <param name="EstudianteDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<EstudianteDTO>> Create([FromBody] EstudianteDTO EstudianteDto)
        {
            // verificar que el campo nombre no venga nulo -> BadRequest
            if(EstudianteDto.Nombre == null){
                BadRequest();
            } 
            //verificar que el curso que quiere matricularse el estudiante, exista
            // si no existe, retornar NotFound
            if(context.obtenerCurso(EstudianteDto.CursoId) == null){
                NotFound();
            }
            // verificar que el estudiante no exista en la base
            // si existe, retortar conflicto
            if(context.obtenerEstudiante(EstudianteDto.Id) != null){
                Conflict();
            }
            // convertir los datos de DTO a Model
            Estudiante estu = EstudianteDto.ToModel(context.obtenerCurs(EstudianteDto.CursoId));
            // agregar el estudiante a la base de datos
            await context.crearEstudiante(estu);

            // retornar el estudiante DTO con los datos actualizados (updatedEstudianteDto)
           // var updatedEstudianteDto = new EstudianteDTO();
            var updatedEstudianteDto = estu.ToDTO();
            return CreatedAtAction(nameof(Get), new {id = EstudianteDto.Id}, updatedEstudianteDto);
        }

        /// <summary>
        /// DELETE /Estudiante/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstudianteDTO>> Delete(int id)
        {
            // verificar que el curso que quiere matricularse el estudiante, exista
            // si no existe, retornar NotFound
            var Estudiante = await context.obtenerEstudiante(id);
            if (Estudiante == null)
            {
                return NotFound();
            }
            // eliminar el estudiante de la base de datos
            await context.eliminarEstudiante(id, Estudiante);
            // retornar el estudiante DTO que se eliminó on un Ok()
            return Ok(Estudiante.ToDTO());
        }

         /// <summary>
        /// PUT (Update) a Estudiante by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="EstudianteDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] EstudianteDTO EstudianteDto)
        {
            // verificar que el id del estudiante corresponda al de un estudiante de la base -> BadRequest
            if(EstudianteDto.Id == id){
                BadRequest();
            }
            // verificar que el campo nombre no venga nulo -> BadRequest
            if(EstudianteDto.Nombre == null){
                BadRequest();
            } 
            // verificar que el estudiante que quiere modificarse, exista
            // si no existe, retornar NotFound
            var Estudiante = await context.obtenerEstudiante(id);
            if (Estudiante == null)
            {
                NotFound();
            }
            // verificar que el curso id, que viene en el DTO para modificar matricula (actualizar)
            // exista en la base, de lo contrario manterner el mismo curso en el que esté matriculado
            // Si no se encuentra que el estudiante este en un curso, retornar NotFound
            if(context.obtenerCurs(EstudianteDto.CursoId) == null){
                NotFound();
            }
            // Actualizar el estudiante, recuerden que existe un método Update en Extensions
            EstudianteExtensions.Update(Estudiante, EstudianteDto,context.obtenerCurs(EstudianteDto.CursoId));
            return NoContent();

        } 
    }
}
