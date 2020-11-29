using System.Reflection.PortableExecutable;
using System;
using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.api.Controllers
{
  [ApiController]
  [Route("[controller]")] 
  public class EstudiantesController : ControllerBase
  {
    //private readonly UdiDbContext db; 

    //public EstudiantesController(UdiDbContext context)
    //{
    //    db = context;
    //}   


    //[HttpGet]
    //public async Task<ActionResult<IEnumerator<EstudianteDTO>>> GetAll(){
    //    return await ;
    //}

    //[HttpGet("{id}")]
    //public async Task<ActionResult<EstudianteDTO>> Get(int id){
    //    return await _dbContext();
    //}

  }

}
