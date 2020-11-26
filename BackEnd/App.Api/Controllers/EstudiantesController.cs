using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Api.Repositorio;
using Microsoft.AspNetCore.Mvc;
using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<EstudianteDto>> GetAll(){
            return await _dbContext.Estudiantes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<EstudianteDto> Get(int id){
            
            return await _dbContext.Estudiantes.FindAsync(id);
        }
        
    }
}
