using System.Collections.Generic;
using System.Collections;
using System.Reflection.PortableExecutable;
using System;
using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using System.Threading.Tasks;

namespace App.api.Controllers
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


   //[HttpGet]
    //public async Task<ActionResult<IEnumerator<EstudianteDTO>>> GetAll(){
    //    return await _dbContext;
    //}

    //[HttpGet("{id}")]
    //public async Task<ActionResult<EstudianteDTO>> Get(int id){
    //    return await _dbContext.Estudiantes.FindAsync(id);;
    //}

  }

}
