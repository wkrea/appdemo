using App.Api.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<List<Estudiante>>> obtenerEstudiante()
        {
            var result = await _dbContext.Estudiantes.ToListAsync();
            return Ok(result);
        }
        [HttpPost]
        public Task<ActionResult<Estudiante>> Create(Estudiante estudiante)
        {
            return null;
        }

        [HttpPut("{id}")]
        public Task<IActionResult> Update(int id, Estudiante estudiante)
        {
            return null;
        }
        [HttpDelete("{id}")]
        public Task<ActionResult<Estudiante>> Delete(int id)
        {
            return null;
        }


    }
}
