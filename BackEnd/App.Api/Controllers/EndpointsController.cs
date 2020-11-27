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
        private readonly ILogger<EndpointsController> _logger;
        public EndpointsController(ILogger<EndpointsController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        // GET: api/Endpoints
        [HttpGet]
        public object Get()
        {
            var objetoRespuesta = new
            {
                Status = "Api A_jcaballero en linea"
            };
            _logger.LogInformation(objetoRespuesta.Status);  
            return objetoRespuesta;
        }
    }
}
