using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly UdiDbContext _dbContext;

        public EstudiantesController(UdiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerator<EstudianteDTO>>> GetAll()
        {
            
            return null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> Get(int id)
        {
            return await _dbContext.estudiantes.FirstOrDefaultAsync(estudiante => estudiante.id == id);
        }

        [HttpPost]
        public Task<ActionResult<EstudianteDTO>> Create(EstudianteDTO estudianteDTO)
        {
            return null;
        }

        [HttpPut("{id}")]
        public Task<IActionResult> Update(int id, EstudianteDTO estudianteDTO)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public Task<ActionResult<EstudianteDTO>> Delete(int id)
        {
            return null;
        }

    }
}
