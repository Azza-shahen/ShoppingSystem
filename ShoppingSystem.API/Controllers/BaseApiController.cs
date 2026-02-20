using Microsoft.AspNetCore.Mvc;

namespace ShoppingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*
    * It holds shared configuration, logic, services (like logging, user access),
    * or attributes (like [ApiController], [Route], etc.).
    */
    public class BaseApiController : ControllerBase
    {
    }
}
