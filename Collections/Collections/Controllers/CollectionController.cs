using System;
using Collections.DAL;
using Collections.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Collections.Models.Collection;
using Services.Abstractions.Interfaces;

namespace Collections.Controllers
{

    [Authorize]
    public class CollectionController : BaseController
    {
        private readonly AppDbContext _db;
        private readonly ICollectionService _service;
        private readonly IMapper _mapper;

        public CollectionController(AppDbContext db, ICollectionService service, IMapper mapper)
        {
            _db = db;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult List()
        {
            var mockCollection = new CollectionSimpleModel()
            {
                Description = "**Mock description**",
                Id = 0,
                Image = string.Empty,
                ItemsCount = 0,
                Theme = new ThemeModel {Id = 0, Name = "Mock title"},
                Title = "Mock Title"
            };
            var model = _service.Get<CollectionSimpleModel>().ToList();
            model.Add(mockCollection);
            return View(model);
        }

        [HttpGet("[action]")]
        public IActionResult Create()
        {
            var model = new CollectionCreateViewModel()
            {
                Themes = _db.Themes.AsNoTracking()
                                   .AsEnumerable()
                                   .Select(x => new ThemeModel { Id = x.Id, Name = x.Name }).ToList()
            };

            return View("Create", model);
        }

        [HttpPost("Create")]
        public IActionResult CreatePost([FromBody] CollectionCreateModel model)
        {
            if (model is null)
            {
                return NoContent();
            }
            var collection = _service.Create<CollectionCreateModel,CollectionDetailsModel>(model);
            return RedirectToAction("Details",new { collection.Id });
        }

        [HttpGet("[action]/{id:int}")]
        public IActionResult Edit(int id)
        {
            var model = _service.GetById<CollectionEditModel>(id);
            return View(model);
        }

        [HttpPost("Edit")]
        public IActionResult EditPost(CollectionEditModel model)
        {
            return RedirectToAction("Details", new { id = model.Id });
        }


        [HttpGet("[action]/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var collection = _service.GetById<CollectionDetailsModel>(id);
            if (collection is null)
            {
                return NotFound();
            }
            await Task.CompletedTask;

            return View("Details", collection);
        }

        [HttpGet("[action]/{id:int}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("List");
        }
    }
}
