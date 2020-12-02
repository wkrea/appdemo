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
		private readonly ILogger<EndpointsController> _logger;

		public EndpointsController(ILogger<EndpointsController> logger)
        {
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpGet]

		[HttpGet]
        public object Get()
        {
			var responseObject = new
			{
				Status = "Api está en linea"
        };
			_logger.LogInformation($"Status: {responseObject.Status}");
			return responseObject;
        }
    }
    
    
}
