using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingSystem.API.Controllers
{
    [Route("errors")]
    [ApiController]
    // Prevents this controller from appearing in Swagger documentation.
    // This endpoint is internal and used only for handling status code errors.
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [HttpGet("{code}")]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code))
            {
                StatusCode = code
            };
        }
    }

}
