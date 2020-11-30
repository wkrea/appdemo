using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Api.Controllers
{  
    [ApiController]
    [Route("")]
    public class EndpointsController : ControllerBase
    {
        private readonly ILogger<EndpointsController> archivoLog;

        public EndpointsController(ILogger<EndpointsController> LogInicializar)
        {
            archivoLog = LogInicializar;
        }
        [HttpGet]

		[HttpGet]
        public object Get()
        {
            var objetoRespuesta = new {
                Status = "Hola gente"
        };
            archivoLog.LogInformation(objetoRespuesta.Status);
            return objetoRespuesta;
        }
    }
    
    
}
