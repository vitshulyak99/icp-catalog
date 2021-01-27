using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        // GET
        public IActionResult Index()
        {
            return Ok();
        }
    }
}