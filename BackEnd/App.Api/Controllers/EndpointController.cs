using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

name space App.Api.Controllers
{
    [ApiController]
    [Router("")] //http://localhost:5000

    public class EndpointController : ControllerBase
    {
        private readonly ILogger<EndpointsController> archivoLog;
        PUblic EndpointsController(ILogger<EndpointsController> logInicializar) 
        {
            archivoLog = logInicializar;
        }

        [HttpGet]

        public object Get(){
            var objetoRespuesta = new {
                Status = "Api está en linea"
            }
            archivoLog.LogInformation(objetoRespuesta.Status);
            return new {};        
        }
    }
}
