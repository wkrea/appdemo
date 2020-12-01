using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.api.Controllers
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
