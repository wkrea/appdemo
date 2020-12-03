using System;
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
            if(String.IsNullOrEmpty(EstudianteDto.Nombre)){
                return BadRequest();
            } 
            Curso curso = await context.obtenerCurso(EstudianteDto.CursoId);
            if(curso == null){
                return NotFound();
            }
            if(await context.obtenerEstudiante(EstudianteDto.Id) != null){
               return Conflict();
            }
            Estudiante estu = EstudianteDto.ToModel(curso);
            await context.crearEstudiante(estu);
            var updatedEstudianteDto = await context.obtenerEstudiante(estu.Id);
            if(updatedEstudianteDto == null){
                return NotFound();
            }
            return CreatedAtAction(nameof(Get), new {id = EstudianteDto.Id}, updatedEstudianteDto.ToDTO());
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
            var Estudiante = await context.obtenerEstudiante(id);
            if (Estudiante == null)
            {
                return NotFound();
            }
            await context.eliminarEstudiante(Estudiante);
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
            var Estudiante = await context.obtenerEstudiante(EstudianteDto.Id);
            if(EstudianteDto.Id != id){
                return BadRequest();
            }
            if(String.IsNullOrEmpty(EstudianteDto.Nombre)){
                return BadRequest();
            } 
            if (Estudiante == null)
            {
                return NotFound();
            }

            if(await context.obtenerCurso(EstudianteDto.CursoId) == null){
                Curso curso = await context.obtenerCurso(Estudiante.CursoId);
                if(curso == null){
                    return NotFound();
                }else{
                    var DtoANT = Estudiante.ToDTO();
                    Estudiante.Update(DtoANT, curso);
                    return NotFound();
                }
            }
            Estudiante.Update(EstudianteDto, await context.obtenerCurso(EstudianteDto.CursoId));
            await context.editarEstudiante();
            return NoContent();
        } 
    }
}
