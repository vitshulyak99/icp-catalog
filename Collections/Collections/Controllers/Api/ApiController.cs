using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController: ControllerBase
    {
    }
}