using Microsoft.AspNetCore.Mvc;

namespace CSharpIs.Api.Controllers
{
    [Route("health")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(true);
        }
    }
}