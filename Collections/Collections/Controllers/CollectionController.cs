using Collections.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Collections.DAL.Entities;
using Collections.DAL.Entities.Identity;
using Collections.Extensions;
using Collections.Models.Collection;
using Services.Abstractions.Interfaces;

namespace Collections.Controllers
{

    [Authorize]
    public class CollectionController : BaseController
    {
        private readonly IThemeService _themeService;
        private readonly ICollectionService _service;
        private readonly IMapper _mapper;

        public CollectionController(ICollectionService service, IMapper mapper, IThemeService themeService)
        {
            _service = service;
            _mapper = mapper;
            _themeService = themeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult List()
        {
            var model = _service.Get().Include(x=>x.Owner)
                                .Include(x=>x.Theme)
                                .ProjectTo<CollectionSimpleModel>(_mapper.ConfigurationProvider).ToList();
            return View(model);
        }

        [HttpGet("[action]")]
        public IActionResult Create()
        {
            var model = new CollectionCreateViewModel
            {
                Themes = _themeService.Get().ProjectTo<ThemeModel>(_mapper.ConfigurationProvider).ToList()
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

            var entity = _mapper.Map<Collection>(model);
            entity.Owner = new AppUser { Id = User.GetNameIdentifier() };
            var collection = _service.Create(entity);
            return Json(new { redirectionUrl = Url.Action("Details", "Collection", new { collection.Id }) });
        }

        [HttpGet("[action]/{id:int}")]
        public IActionResult Edit(int id)
        {
            var model = _mapper.Map<CollectionEditViewModel>(_service.GetById(id));
            model.Themes = _themeService.Get().ProjectTo<ThemeModel>(_mapper.ConfigurationProvider).ToList();
            return View(model);
        }

        [HttpPost("Edit")]
        public IActionResult EditPost([FromForm] CollectionEditModel model)
        {
            _service.Update(_mapper.Map<Collection>(model));
            return RedirectToAction("Details", new { model.Id });
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("[action]/{id:int}", Name = "CollectionDetails")]
        public IActionResult Details(int id)
        {
            var collection = _mapper.Map<CollectionDetailsModel>(_service.GetById(id));
            if (collection is null)
            {
                return NotFound();
            }
            ViewData["HasPermissions"] = _service.HasPermissions(id, User.GetNameIdentifier());
            return View("Details", collection);
        }

        [HttpGet("[action]/{id:int}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet("[action]")]
        public IActionResult My()
        {
            var viewModel =  _service.ByUser(User.GetNameIdentifier()).Select(_mapper.Map<CollectionSimpleModel>).ToList();
            return View("List", viewModel);
        }
    }
}
