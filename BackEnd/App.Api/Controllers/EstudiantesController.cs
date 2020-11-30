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
        public async Task<ActionResult<IEnumerator<EstudianteDTO>>> GetAll()
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
            //return Ok(Estudiante);
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
            if (string.IsNullOrEmpty(EstudianteDto.Nombre))
                return BadRequest();

            var @class = await _dbContext.Cursos.FindAsync(EstudianteDto.CursoId);
            if (@class == null)
                return NotFound();

            var existingEstudiante = await _dbContext.Estudiantes.FindAsync(EstudianteDto.Id);
            if (existingEstudiante != null)
                return Conflict();

            var EstudianteToAdd = EstudianteDto.ToModel(@class);
            _dbContext.Estudiantes.Add(EstudianteToAdd);
            await _dbContext.SaveChangesAsync();
            var updatedEstudianteDto = EstudianteToAdd.ToDTO();

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
            var Estudiante = await _dbContext.Estudiantes.FindAsync(id);
            if (Estudiante == null)
                return NotFound();

            _dbContext.Estudiantes.Remove(Estudiante);
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
            if (EstudianteDto.Id != id || string.IsNullOrEmpty(EstudianteDto.Nombre))
                return BadRequest();

            var Estudiante = await _dbContext.Estudiantes.FindAsync(id);
            if (Estudiante == null)
                return NotFound();
            var @class = EstudianteDto.CursoId != Estudiante.Curso.Id
                ? await _dbContext.Cursos.FindAsync(id)
                : Estudiante.Curso;
            if (@class == null)
                return NotFound();

            Estudiante.Update(EstudianteDto, @class);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
