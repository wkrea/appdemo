using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace  App.Api.Controllers{
    public class  EndpointsController : ControllerBase{
        private readonly ILogger<EndpointsController> _Logger;
        
        public EndpointsController(ILogger<EndpointsController> logger){
            _Logger = logger;
        }

        public object Get(){
            return _Logger;
        }

    }
}
