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

        EstudiantesController(UdiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
