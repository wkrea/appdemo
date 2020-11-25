using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using Microsoft.AspNetCore.Mvc;
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

        public Task<ActionResult<IEnumerator<EstudianteDTO>>> GetAll()
        {
            return null;
        }


        /*[HttpGet]
        [HttpGet("id")]
        [HttpPost]
        [HttpPut("id")]
        [HttpDelete("id")]*/
    }
}
