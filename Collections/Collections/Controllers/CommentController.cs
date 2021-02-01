using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Collections.DAL.Entities;
using Collections.DAL.Entities.Identity;
using Collections.Extensions;
using Collections.Models.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions.Interfaces;

namespace Collections.Controllers
{
    [Authorize]
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpPost("[action]/{itemId:int}")]
        public IActionResult All(int itemId)
        {
            var viewModel = _commentService.Get()
                                           .Where(x => x.Item.Id.Equals(itemId))
                                           .Include(x => x.Sender)
                                           .Include(x => x.Item)
                                           .ProjectTo<CommentViewModel>(_mapper.ConfigurationProvider)
                                           .ToArray();

            return PartialView("Item/_Comments", viewModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CommentModel model)
        {
            var entity = _mapper.Map<Comment>(model);
            entity.Sender = new AppUser
            {
                Id = User.GetNameIdentifier()
            };
            entity = _commentService.Create(entity);
            var viewModel = _mapper.Map<CommentViewModel>(entity);
            return PartialView("Item/_Comment", viewModel);
        } 
        
        [HttpPost("[action]/{id:int}")]
        public IActionResult Get(int id)
        {
            var entity = _commentService.GetById(id);
            var viewModel = _mapper.Map<CommentViewModel>(entity);
            return PartialView("Item/_Comment",viewModel);
        }
    }
}