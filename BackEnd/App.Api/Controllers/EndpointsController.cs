using Microsoft.Extensions.Logging;

namespace  App.Api.Controllers{
    public class  EndpointsController{
        readonly ILogger<EndpointsController> _Logger;
        
        EndpointsController(ILogger<EndpointsController> logger){
            _Logger = logger;
        }

        object Get(){
            return _Logger;
        }

    }
}