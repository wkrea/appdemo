using System;
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
            var Estudiante = await _dbContext.Estudiantes.FindAsync(id);

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
        public async Task<ActionResult<EstudianteDTO>> Crear([FromBody] EstudianteDTO EstudianteDto)
        {
            
            if(String.IsNullOrEmpty(EstudianteDto.Nombre))
            {
                return BadRequest();
            }
                        
            if(await _dbContext.Estudiantes.FindAsync(EstudianteDto.Id) != null)
            {                
                return Conflict();
            }

            if(await _dbContext.Cursos.FindAsync(EstudianteDto.CursoId) == null)
            {
                return NotFound();
            }

            Curso actual = await _dbContext.Cursos.FindAsync(EstudianteDto.CursoId);
            Estudiante nuevo = EstudianteDto.ToModel(actual);
            await _dbContext.Estudiantes.AddAsync(nuevo);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new {id = EstudianteDto.Id}, nuevo.ToDTO());

        }

        /// <summary>
        /// DELETE /Estudiante/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstudianteDTO>> Eliminar(int id)
        {
            var Estudiante = await _dbContext.Estudiantes.FindAsync(id);
            if(Estudiante == null){
                return NotFound();
            }else{
                _dbContext.Estudiantes.Remove(Estudiante);
                return Ok(Estudiante.ToDTO());
            }
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
        public async Task<IActionResult> Editar(int id, [FromBody] EstudianteDTO EstudianteDto)
        {
            var Estudiante = await _dbContext.Estudiantes.FindAsync(id);

            if(String.IsNullOrEmpty(EstudianteDto.Nombre)){
                return BadRequest();
            }

            if(Estudiante == null)
            {
                return NotFound();
            }

            Curso actual = await _dbContext.Cursos.FindAsync(EstudianteDto.CursoId);

            if(actual == null)
            {
                return NotFound();
            }

            Estudiante.Update(EstudianteDto, actual);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
