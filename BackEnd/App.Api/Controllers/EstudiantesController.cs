using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
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
    }
}
