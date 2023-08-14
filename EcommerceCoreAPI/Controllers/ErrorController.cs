using EcommerceCoreAPI.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCoreAPI.Controllers
{
    [Route("errors/{code}")]    
    
    public class ErrorController : BaseApiController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error(int code) { 
            return new ObjectResult(new ApiResponse(code));
        
        }
    }
}
