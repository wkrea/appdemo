using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class EndpointsController : ControllerBase
    {
        private const string Message = "El log está funcionando";
        private readonly ILogger<EndpointsController> _logger;

        public EndpointsController(ILogger<EndpointsController> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation(message: Message);
            return "Funcionando";
        }
    }
}
