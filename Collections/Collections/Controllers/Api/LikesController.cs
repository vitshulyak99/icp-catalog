using Collections.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Interfaces;

namespace Collections.Controllers.Api
{
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly IItemService _itemService;
        public LikesController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{id:int}")]
        public IActionResult Like(int id)
        {
           var res = _itemService.SetLike(id, User.GetNameIdentifier());

            return Ok(res);
        }
    }
}