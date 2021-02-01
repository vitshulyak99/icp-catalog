using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Collections.DAL.Entities;
using Collections.Extensions;
using Collections.Models.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Interfaces;

namespace Collections.Controllers
{
    [Authorize]
    public class ItemController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IItemService _itemService;
        private readonly ICollectionService _collectionService;
        public ItemController(IMapper mapper, IItemService itemService, ICollectionService collectionService)
        {
            _mapper = mapper;
            _itemService = itemService;
            _collectionService = collectionService;
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult Index([FromQuery]string text)
        {
            List<ItemSearchResultViewModel> items = new();
            items.AddRange(_itemService.Search(text).ProjectTo<ItemSearchResultViewModel>(_mapper.ConfigurationProvider));
            return View(items);
        }

        [HttpPost("[action]/{collectionId:int}")]
        [AllowAnonymous]
        public IActionResult ByCollection(int collectionId)
        {
            var items = _itemService.GetByCollection(collectionId).Select(_mapper.Map<ItemViewModel>).ToList();
            return PartialView("Item/_CollectionItemsTBody", items);
        }

        [HttpGet("/collection/{collectionId:int}/[action]")]
        public IActionResult Create(int collectionId)
        {
            var customFields = _collectionService.GetFields(collectionId).Select(_mapper.Map<FieldModel>).ToList();
            var viewModel = new ItemCreateViewModel
            {
                Fields = customFields,
                CollectionId = collectionId
            };
            return View(viewModel);
        }

        [HttpPost("[action]/{collectionId:int}", Name = "CreateItem")]
        public IActionResult CreatePost(int collectionId, [FromBody] ItemCreateModel model)
        {
            model.CollectionId = collectionId;
            var entity = _mapper.Map<Item>(model);
            _itemService.Create(entity);
            var redirectionUrl = Url.Action("Details", "Collection", new { id = collectionId });
            return Json(new { redirectionUrl });
        }


        [HttpGet("[action]/{id:int}")]
        public IActionResult Edit(int id)
        {
            var item = _itemService.GetById(id);
            return View(_mapper.Map<ItemEditModel>(item));
        }

        [HttpPost("[action]")]
        public IActionResult EditPost([FromBody] ItemEditModel model)
        {
            var entity = _mapper.Map<Item>(model);
            _itemService.Update(entity);
            return Json(new
            {
                redirectionUrl = Url.Action("Details", new { model.Id })
            });
        }

        [HttpGet("[action]/{id:int}")]
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var item = _mapper.Map<ItemViewModel>(_itemService.GetById(id));
            return View(item);
        }

        [HttpGet("[action]/{id:int}")]
        public IActionResult Delete(int id)
        {
            var collectionid = _itemService.Get().Select(x => x.Id).FirstOrDefault();
            if (_collectionService.HasPermissions(id, User.GetNameIdentifier()))
            {
                _itemService.Delete(id);
            }

            return RedirectToAction("Details", "Collection", new { id = collectionid });
        }
    }
}