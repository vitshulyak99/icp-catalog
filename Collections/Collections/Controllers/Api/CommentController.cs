using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Interfaces;
using Services.Dto;

namespace Collections.Controllers.Api
{
    [Authorize]
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("byItem/{id:int}")]
        public IActionResult GetByItem(int id)
        {
            var comments = _commentService.GetByItem(id).ToList();
            return Ok(comments);
        }

        public IActionResult Create([FromBody] CommentDto model)
        {
            var comment = _commentService.Create(model);
            return Ok(comment);
        }
    }
}