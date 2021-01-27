using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}