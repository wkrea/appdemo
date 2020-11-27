using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Api.Controllers
{
    [Route("")] // http://localhost:5000
    [ApiController]
    public class EndpointsController : ControllerBase
    {
        private readonly ILogger<EndpointsController> archivolog;
        public EndpointsController(ILogger<EndpointsController> loginicualizar)
        {
            archivolog = loginicualizar;
        }
        // GET: api/Endpoints
        [HttpGet]
        public object Get()
        {
            var objetoRespuesta = new
            {
                Status = "Api 8A_jcaballero en linea"
            };
            archivolog.LogInformation(objetoRespuesta.Status);  
            return objetoRespuesta;
        }
    }
}
