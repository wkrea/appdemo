using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.Modelos;
using App.Api.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")] //http://localhost:5000/Personas
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteRepo context;
        public EstudiantesController(IEstudianteRepo estudianteRepo)
        {
            context = estudianteRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Estudiante>>> Get()
        {
            return await context.obtenerEstudiantes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetById(int id)
        {
            return await context.obtenerEstudiante(id);
        }
        [HttpPost]
        public async Task<ActionResult> Crear([FromBody] Estudiante estudiante)
        {
            try
            {
                await context.crearEstudiante(estudiante);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Editar(int id, [FromBody] Estudiante estEditado)
        {
            try
            {
                var existe = context.obtenerEstudiante(id);
                if(existe == null){
                    return NotFound();
                }
                if(existe.Id != id){
                    return BadRequest();
                }
                await context.editarEstudiante(estEditado);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                var existe = context.obtenerEstudiante(id);
                if(existe == null){
                    return NotFound();
                }
                if(existe.Id != id){
                    return BadRequest();
                }
                await context.eliminarEstudiante(id);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
