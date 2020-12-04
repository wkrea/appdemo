﻿using System;
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
            if(String.IsNullOrEmpty(EstudianteDto.Nombre)){ return BadRequest();}

            //verificar que el curso que quiere matricularse el estudiante, exista
            
            var Curso = await _dbContext.Cursos.FirstOrDefaultAsync(c=>c.Id==EstudianteDto.CursoId);
            
            // si no existe, retornar NotFound
            if (Curso == null){ return NotFound();}
                
            // verificar que el estudiante no exista en la base
            var Estudiante = await _dbContext.Estudiantes.FirstOrDefaultAsync(e=>e.Id==EstudianteDto.Id);
            
            // si existe, retortar conflicto
            if (Estudiante != null){ return Conflict();}

            // convertir los datos de DTO a Model
            var nEstudiante = new Estudiante{
                Id = EstudianteDto.Id,
                Nombre = EstudianteDto.Nombre,
                CursoId = EstudianteDto.CursoId,
            };

            // agregar el estudiante a la base de datos
            _dbContext.Estudiantes.Add(nEstudiante);
            // guardar los cambios
            await _dbContext.SaveChangesAsync();

            // retornar el estudiante DTO con los datos actualizados (updatedEstudianteDto)
            
            var estudiante = await _dbContext.Estudiantes.FirstOrDefaultAsync(e=>e.Id==EstudianteDto.Id);

            if (estudiante == null)
                return NotFound();

            return Ok(estudiante.ToDTO());
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
            var Estudiante = await _dbContext.Estudiantes.FirstOrDefaultAsync(e=>e.Id==id);

            if (Estudiante == null){return NotFound();}

            // eliminar el estudiante de la base de datos
            _dbContext.Estudiantes.Remove(Estudiante);
            await _dbContext.SaveChangesAsync();

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
            if( EstudianteDto.Id == default(int) || id == default(int) ) {
                return BadRequest(); 
            }
            var Estudiante = await _dbContext.Estudiantes.FirstOrDefaultAsync(e=>e.Id==id);

            if (Estudiante == null){ return NotFound();}
            // verificar que el campo nombre no venga nulo -> BadRequest
            if (String.IsNullOrEmpty(EstudianteDto.Nombre)){ return BadRequest();}

            // verificar que el estudiante que quiere modificarse, exista
            // si no existe, retornar NotFound
            if (Estudiante == null)
            {
                return NotFound();
            }

            // verificar que el curso id, que viene en el DTO para modificar matricula (actualizar)
            // exista en la base, de lo contrario manterner el mismo curso en el que esté matriculado
            // Si no se encuentra que el estudiante este en un curso, retornar NotFound

            // Actualizar el estudiante, recuerden que existe un método Update en Extensions

            Estudiante.Update(EstudianteDto, await _dbContext.Cursos.FirstOrDefaultAsync(cur => cur.Id == EstudianteDto.CursoId));
           
            // Guardar los cambios en la base

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
