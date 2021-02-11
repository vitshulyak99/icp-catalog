using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Services.Abstractions.Interfaces;
using Services.Dto;

namespace Collections.Controllers.Api
{

    [Authorize]
    public class CollectionController : AbstractCrudController<CollectionDto>
    {
        private readonly ICollectionService _service;

        public CollectionController(ICollectionService service)
        {
            _service = service;
        }
        
        public override IActionResult Get(int page, int count)
        {
            var collections = _service.GetPage(page < 1 ? 1 : page, count < 5 ? DefaultPageSetSize : count).ToList();
            return Ok(collections);
        }

        public override IActionResult Create(CollectionDto model)
        {
            if (model is null) return BadRequest();

            model = _service.Create(model);
            return Ok(model);
        }

        public override IActionResult Update(CollectionDto model)
        {
            if (model is null) return BadRequest();

             model = _service.Update(model);
             return Ok(model);
        }

        public override IActionResult Delete(string id)
        {
            if (!int.TryParse(id, out var res)) return BadRequest();
            _service.Delete(res);
            return Ok();
        }
    }
}
