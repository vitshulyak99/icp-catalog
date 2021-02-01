using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Collections.Models;
using Collections.Models.Collection;
using Collections.Models.Item;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions.Interfaces;

namespace Collections.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        private readonly ITagService _tagService;
        private readonly ICollectionService _collectionService;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public HomeController(ITagService tagService, ICollectionService collectionService, IItemService itemService, IMapper mapper)
        {
            _tagService = tagService;
            _collectionService = collectionService;
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                Tags = _tagService.Get()
                                  .Include(x=>x.ItemTags)
                                  .ProjectTo<TagModel>(_mapper.ConfigurationProvider)
                                  .ToArray(),
                TopCollections = _collectionService.Get()
                                                   .OrderByDescending(x=>x.Items.Count)
                                                   .Take(10)
                                                   .Include(x=>x.Theme)
                                                   .Include(x=>x.Owner)
                                                   .ProjectTo<CollectionSimpleModel>(_mapper.ConfigurationProvider)
                                                   .ToArray(),
                LastItems = _itemService.Get()
                                        .OrderBy(x=>x.Id)
                                        .Take(5)
                                        .Include(x=>x.Fields)
                                        .Include(x=>x.Tags)
                                        .Include(x=>x.UserLike)
                                        .ProjectTo<ItemViewModel>(_mapper.ConfigurationProvider).ToArray()
            };
            return View(viewModel);
        }
    }
}