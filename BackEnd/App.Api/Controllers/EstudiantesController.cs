using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace App.api.Controllers
{

    [ApiController]
    [Route("[controller]")] //http://localhost:5000/Estudiantes
    public class EstudiantesController : ControllerBase
    {

        private readonly UdiDbContext _dbContext;

        public EstudiantesController(UdiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EstudianteDTO>>> GetAll(){
            var Estudiantes = await _dbContext.Estudiantes.ToArrayAsync();
            return Ok(Estudiantes.Select(s => s.ToDTO()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstudianteDTO>> Get(int id){
            
            var Estudiante = await _dbContext.Estudiantes.FindAsync(id);

            if (Estudiante == null){
                return NotFound();
            }

            return Ok(Estudiante.ToDTO());
        }

        // [HttpPost]
        
        // public async Task<ActionResult<EstudianteDTO>> Crear([FromBody] EstudianteDTO EstudianteDto)
        // {
        //     var updatedEstudianteDto =  new EstudianteDTO();
        //     return  CreatedAtAction(nameof(Get), new {id = EstudianteDto.Id},  updatedEstudianteDto);
        // }

        /*[HttpDelete("{id}")]
        public async Task<ActionResult<EstudianteDTO>> Eliminar(int id)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] EstudianteDTO EstudianteDto)
        {
            return NoContent();
        }*/
        
    }
}
