using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Collections.DAL;
using Collections.DAL.Entities;
using Services.Abstractions;
using Services.Abstractions.Interfaces;
using Services.Dto;

namespace Services.Impl
{
    public class TagService : BaseCrudService<Tag,TagDto>,ITagService
    {
        public TagService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Tag> Include(IQueryable<Tag> query) => query;

        public IEnumerable<TagDto> GetLike(string text) => 
            ProjectTo(Set.Where(x => x.Name.ToLower().StartsWith(text.ToLower()))).ToList();
    }
}