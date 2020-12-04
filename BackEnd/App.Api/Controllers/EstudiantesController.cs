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

        /// <summary>
        /// GET (Read all) /Estudiantes
        /// </summary>
        /// <returns></returns>
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
            var Estudiante = await _dbContext.Estudiantes.FirstOrDefaultAsync(e=>e.Id==id);

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
            var verificarnulo = await _dbContext.Cursos.FirstOrDefaultAsync(c=>c.Id==EstudianteDto.CursoId);
            if (verificarnulo==null)
            return NotFound();

            //verificar que el curso que quiere matricularse el estudiante, exista
            // si no existe, retornar NotFound
            var verficarcurso = await _dbContext.Cursos.FirstOrDefaultAsync(v=>v.Id==EstudianteDto.CursoId);

            if (verficarcurso == null)
            return NotFound();

            // verificar que el estudiante no exista en la base
            // si existe, retortar conflicto
            var verificarestudiante = await _dbContext.Estudiantes.FirstOrDefaultAsync(ve=>ve.Id==EstudianteDto.Id);

            if (verificarestudiante != null)
                return NotFound();

            // convertir los datos de DTO a Model

            var Convnuevoestudiante = new Estudiante{
                Id = EstudianteDto.Id,
                Nombre = EstudianteDto.Nombre,
                CursoId = EstudianteDto.CursoId,
            };
            // agregar el estudiante a la base de datos

             _dbContext.Estudiantes.Add(Convnuevoestudiante);
            // guardar los cambios
            await _dbContext.SaveChangesAsync();

            // retornar el estudiante DTO con los datos actualizados (updatedEstudianteDto)
                        var estudiantecondto = await _dbContext.Estudiantes.FirstOrDefaultAsync(e=>e.Id==EstudianteDto.Id);

            if (estudiantecondto == null)
                return NotFound();

            return Ok(estudiantecondto.ToDTO());
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

            // si no existe, retornar NotFound
            var DeleteEstudiante = await _dbContext.Estudiantes.FirstOrDefaultAsync(e=>e.Id==id);

            if (DeleteEstudiante == null)
                return NotFound();

            _dbContext.Estudiantes.Remove(DeleteEstudiante);
            await _dbContext.SaveChangesAsync();

            return Ok(DeleteEstudiante.ToDTO());
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
            if( EstudianteDto.Id == default(int) || id == default(int) ) {
                return BadRequest(); 
            }

            var verificarstudianteid = await _dbContext.Estudiantes.FirstOrDefaultAsync(e=>e.Id==id);

            if (verificarstudianteid == null)
                return NotFound();

            if(EstudianteDto.Nombre == string.Empty || EstudianteDto.Nombre  == null) {
                return BadRequest(); 
            }
            // verificar que el estudiante que quiere modificarse, exista
            // si no existe, retornar NotFound

            // verificar que el curso id, que viene en el DTO para modificar matricula (actualizar)
            // exista en la base, de lo contrario manterner el mismo curso en el que esté matriculado
            // Si no se encuentra que el estudiante este en un curso, retornar NotFound

            // Actualizar el estudiante, recuerden que existe un método Update en Extensions

            // Guardar los cambios en la base
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
