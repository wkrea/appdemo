using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Api.Controllers.DTOs;
using App.Api.Modelos;

namespace App.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {

        private readonly UdiDbContext _dbContext;
        public EstudiantesController(UdiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EstudianteDTO>>> GetAll()
        {
            var Estudiantes = await _dbContext.Estudiantes.ToArrayAsync();
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
            var Estudiante = await getEstudianteById(id);

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

            if (validateString(EstudianteDto.Nombre))
                return BadRequest();

            //verificar que el curso que quiere matricularse el estudiante, exista
            // si no existe, retornar NotFound

            var curso = await getCursoById(EstudianteDto.CursoId);
            if (curso == null)
                return NotFound();

            // verificar que el estudiante no exista en la base
            // si existe, retortar conflicto

            var existingEstudiante = await getEstudianteById(EstudianteDto.Id);
            if (existingEstudiante != null)
                return Conflict();

            // convertir los datos de DTO a Model
            // agregar el estudiante a la base de datos
            // guardar los cambios

            _dbContext.Estudiantes.Add(EstudianteDto.ToModel(curso));
            await _dbContext.SaveChangesAsync();

            // retornar el estudiante DTO con los datos actualizados (updatedEstudianteDto)

            return CreatedAtAction(nameof(Get), new { id = EstudianteDto.Id }, new EstudianteDTO());
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

            var Estudiante = await getEstudianteById(id);
            if (Estudiante == null)
                return NotFound();

            // eliminar el estudiante de la base de datos

            _dbContext.Estudiantes.Remove(Estudiante);

            // retornar el estudiante DTO que se eliminó on un Ok()

            await _dbContext.SaveChangesAsync();
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
            // verificar que el campo nombre no venga nulo -> BadRequest

            if (validateIdsAndStrings(validateIds(EstudianteDto.Id,id), validateString(EstudianteDto.Nombre)))
                return BadRequest();

            // verificar que el estudiante que quiere modificarse, exista
            // si no existe, retornar NotFound

            var Estudiante = await getEstudianteById(id);
            if (Estudiante == null)
                return NotFound();

            // verificar que el curso id, que viene en el DTO para modificar matricula (actualizar)
            // exista en la base, de lo contrario manterner el mismo curso en el que esté matriculado
            // Si no se encuentra que el estudiante este en un curso, retornar NotFound

            var cursoEstudiante = EstudianteDto.CursoId != Estudiante.Curso.Id
                ? await getCursoById(id)
                : Estudiante.Curso;

            if (cursoEstudiante == null)
                return NotFound();

            // Actualizar el estudiante, recuerden que existe un método Update en Extensions

            Estudiante.Update(EstudianteDto, cursoEstudiante);

            // Guardar los cambios en la base

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        //Obtiene los estudiantes por Id de manera asíncrona
        private async Task<Estudiante> getEstudianteById(int id)
        {
            return await _dbContext.Estudiantes.FindAsync(id);
        }

        //Obtiene los cursos por Id de manera asíncrona
        private async Task<Curso> getCursoById(int id)
        {
            return await _dbContext.Cursos.FindAsync(id);
        }

        //Valida si el string es nullo o vacío
        private bool validateString(string stringToValidate)
        {
            return string.IsNullOrEmpty(stringToValidate);
        }

        //Realiza validaciones en los ids respectivos pare verificar si son diferentes
        private bool validateIds(int idObject, int idValidate)
        {
            return idObject != idValidate;
        }

        //Realiza validaciones tanto por ids que no concuerdan como por strings vacios o nulos
        private bool validateIdsAndStrings(bool idsValidate, bool stringValidate)
        {
            return idsValidate || stringValidate;
        }
    }
}
