using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Api.Controllers
{
    public class EndpointsController : ControllerBase
    {
        public readonly ILogger<EndpointsController> _logger;

        EndpointsController(ILogger<EndpointsController> logger)
        {
            this._logger = logger;
        }


    }
}
