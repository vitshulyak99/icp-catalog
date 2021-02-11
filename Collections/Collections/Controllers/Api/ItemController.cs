using System.Linq;
using Collections.Controllers.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Interfaces;
using Services.Dto;

namespace Collections.Controllers
{
    [Authorize]
    public class ItemController : AbstractCrudController<ItemDto>
    {
        private readonly IItemService _service;
        public ItemController(IItemService service)
        {
            _service = service;
        }

        public override IActionResult Get(int page, int count)
        {
            if (page <1 || count <1)
            {
                return BadRequest();
            }

            var items = _service.GetPage(page, count).ToList();
            return Ok(items);
        }

        public override IActionResult Create(ItemDto model)
        {
            if (model is null) return BadRequest();
            var item = _service.Create(model);
            return Ok(item);
        }

        public override IActionResult Update(ItemDto model)
        {
            if (model is null) return BadRequest();
            return Ok();
        }

        public override IActionResult Delete(string id)
        {
            if (!int.TryParse(id, out var result)) return BadRequest();
            _service.Delete(result);
            return Ok();
        }
    }
}