using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Interfaces;

namespace Collections.Controllers.Api
{
    public class TagController : ApiController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        // GET
        [HttpGet("{like}")]
        [AllowAnonymous]
        public IActionResult Like(string like)
        {
            var tags = _tagService.GetLike(like);
            return Ok(tags);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll() => Ok(_tagService.GetAll().ToList());

    }

}
