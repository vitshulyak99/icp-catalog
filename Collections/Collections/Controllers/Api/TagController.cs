using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Collections.DAL;
using Collections.DAL.Expressions;
using Collections.Models.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public TagController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Like([FromQuery] string like)
        {
            var tags = _db.Tags
                         //.FullText(like)
                         .Where(x=>x.Name.ToLower().StartsWith(like.ToLower())).ProjectTo<TagModel>(_mapper.ConfigurationProvider).ToArray();
           return Ok(tags);
        }
    }
}