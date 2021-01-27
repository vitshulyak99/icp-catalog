using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers
{
    [Route("/[controller]")]
    public abstract class BaseController : Controller
    {
    }
}
