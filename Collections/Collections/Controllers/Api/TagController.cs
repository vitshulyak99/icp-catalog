using System.Linq;
using AutoMapper;
using Collections.Models.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Interfaces;

namespace Collections.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        public TagController(IMapper mapper, ITagService tagService)
        {
            _mapper = mapper;
            _tagService = tagService;
        }

        // GET
        [HttpGet("[action]/{like?}")]
        [AllowAnonymous]
        public IActionResult Like(string like)
        {
            var tags = _tagService.GetLike(like).Select(_mapper.Map<TagModel>);
            return Ok(tags);
        }
    }

}
