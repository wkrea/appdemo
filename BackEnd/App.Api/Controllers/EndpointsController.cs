using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("")] //http://localhost:5000
    public class EndpointsController : ControllerBase
    {
        private readonly ILogger<EndpointsController> archivoLog;
        public EndpointsController(ILogger<EndpointsController> logInicializar) 
        {
            archivoLog = logInicializar;
        }

        [HttpGet]
        public object Get(){
            var objetoRespuesta = new {
                Status = "Api está en linea"
            };
            archivoLog.LogInformation(objetoRespuesta.Status);
            return objetoRespuesta;        
        }
    }
}
