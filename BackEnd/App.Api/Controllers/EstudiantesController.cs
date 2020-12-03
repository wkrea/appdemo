<<<<<<< HEAD
﻿using System;
=======
>>>>>>> main
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
<<<<<<< HEAD
        private readonly UdiDbContext _dbContext;

=======

        private readonly UdiDbContext _dbContext;
>>>>>>> main
        public EstudiantesController(UdiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

<<<<<<< HEAD
        // lEER ESTUDIANTE
=======
>>>>>>> main
        /// <summary>
        /// GET (Read all) /Estudiantes
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD

=======
>>>>>>> main
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EstudianteDTO>>> GetAll()
        {
            var Estudiantes = await _dbContext.Estudiantes.ToArrayAsync();
<<<<<<< HEAD
            return Ok(Estudiantes.Select(s => s.ToDTO()));
        }

        // ENLACE ESTUDIANTE ID
=======
            // return Ok(Estudiantes);
            return Ok(Estudiantes.Select(s => s.ToDTO()));
        }

>>>>>>> main
        /// <summary>
        /// GET (Read) /Estudiante/{id}
        /// https://localhost:5001/estudiantes/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
<<<<<<< HEAD

=======
>>>>>>> main
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstudianteDTO>> Get(int id)
        {
<<<<<<< HEAD
            var Estudiante = await _dbContext.Estudiantes.FirstOrDefaultAsync(e => e.Id == id);
=======
            var Estudiante = await _dbContext.Estudiantes.FirstOrDefaultAsync(e=>e.Id==id);
>>>>>>> main

            if (Estudiante == null)
                return NotFound();

            return Ok(Estudiante.ToDTO());
        }

<<<<<<< HEAD
        // ENLACE ESTUDIANTE DTO
=======
>>>>>>> main
        /// <summary>
        /// POST (Create) /Estudiante
        /// </summary>
        /// <param name="EstudianteDto"></param>
        /// <returns></returns>
<<<<<<< HEAD

=======
>>>>>>> main
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<EstudianteDTO>> Create([FromBody] EstudianteDTO EstudianteDto)
        {
            // verificar que el campo nombre no venga nulo -> BadRequest

<<<<<<< HEAD
            if (String.IsNullOrEmpty(EstudianteDto.Nombre))
            { return BadRequest(); }

            //verificar que el curso que quiere matricularse el estudiante, exista
            // si no existe, retornar NotFound

            var Cur = await _dbContext.Cursos.FirstOrDefaultAsync(c => c.Id == EstudianteDto.CursoId);
            if (Cur == null) { return NotFound(); }

            // verificar que el estudiante no exista en la base
            // si existe, retortar conflicto

            var est = await _dbContext.Estudiantes.FirstOrDefaultAsync(e => e.Id == EstudianteDto.Id);
            if (est != null) { return Conflict(); }

            // convertir los datos de DTO a Model
            // agregar el estudiante a la base de datos
            // guardar los cambios

            Estudiante estu = EstudianteDTO.ToModel(Cur);
            _dbContext.Estudiantes.Add(estu);          
            await _dbContext.SaveChangesAsync();

            // retornar el estudiante DTO con los datos actualizados (updatedEstudianteDto)

            var updatedEstudianteDto = est.ToDTO();
            return CreatedAtAction(nameof(Get), new { id = EstudianteDto.Id }, updatedEstudianteDto);
        }

        // Estudiante ID 
=======
            //verificar que el curso que quiere matricularse el estudiante, exista
            // si no existe, retornar NotFound

            // verificar que el estudiante no exista en la base
            // si existe, retortar conflicto

            // convertir los datos de DTO a Model
            // agregar el estudiante a la base de datos
            // guardar los cambios
            await _dbContext.SaveChangesAsync();

            // retornar el estudiante DTO con los datos actualizados (updatedEstudianteDto)
            var updatedEstudianteDto = new EstudianteDTO();
            return CreatedAtAction(nameof(Get), new {id = EstudianteDto.Id}, updatedEstudianteDto);
        }

>>>>>>> main
        /// <summary>
        /// DELETE /Estudiante/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
<<<<<<< HEAD

=======
>>>>>>> main
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstudianteDTO>> Delete(int id)
        {
            // verificar que el curso que quiere matricularse el estudiante, exista
            // si no existe, retornar NotFound

<<<<<<< HEAD
            var Estudiante = await _dbContext.Estudiantes.FirstOrDefaultAsync(e => e.Id == id);
            if (Estudiante == null)
            {
                return NotFound();
            }
            // eliminar el estudiante de la base de datos
            // retornar el estudiante DTO que se eliminó on un Ok()
            else
            {
                _dbContext.Estudiantes.Remove(Estudiante);
                return Ok(Estudiante.ToDTO());
            }
            await _dbContext.SaveChangesAsync();

            /// <summary>
            /// PUT (Update) a Estudiante by id
            /// </summary>
            /// <param name="id"></param>
            /// <param name="EstudianteDto"></param>
            /// <returns></returns>
        }

            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Update(int id, [FromBody] EstudianteDTO EstudianteDto)
            {

            // verificar que el id del estudiante corresponda al de un estudiante de la base -> BadRequest

            var est = await _dbContext.Estudiantes.FirstOrDefaultAsync(e => e.Id == EstudianteDto.Id);

            // verificar que el campo nombre no venga nulo -> BadRequest

            if (string.IsNullOrEmpty(EstudianteDto.Nombre))
            {
                return BadRequest();
            }

            // verificar que el estudiante que quiere modificarse, exista

            if (EstudianteDto.Id!=id)
                {
                    return BadRequest();
                }

            // si no existe, retornar NotFound

            if (est == null)
                {
                    return NotFound();
                }

            // verificar que el curso id, que viene en el DTO para modificar matricula (actualizar)
            // exista en la base, de lo contrario manterner el mismo curso en el que esté matriculado

            Curso actual = await _dbContext.Cursos.FirstOrDefaultAsync(cur => cur.Id == EstudianteDto.CursoId);
            if (actual == null)
            {
                Curso cur = actual;

                // Si no se encuentra que el estudiante este en un curso, retornar NotFound

                if (cur == null)
                {
                    return NotFound();
                }
                else
                {
                    var estDto = est.ToDTO();
                    est.Update(estDto, cur);
                    return NotFound();
                }
            }

            // Actualizar el estudiante, recuerden que existe un método Update en Extensions

            est.Update(EstudianteDto, actual);


            // Guardar los cambios en la base

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        }
    }

=======
            // eliminar el estudiante de la base de datos
            await _dbContext.SaveChangesAsync();

            // retornar el estudiante DTO que se eliminó on un Ok()
            return Ok();
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
>>>>>>> main
