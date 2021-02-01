using System.Collections.Generic;
using System.Linq;
using Collections.DAL;
using Collections.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.Abstractions.Interfaces;

namespace Services.Impl
{
    public class TagService :  BaseCrudService<Tag>,ITagService
    {
        public TagService(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Tag> GetLike(string text)
            => Set.LikeTag(text).ToArray();
    }

    public static class LikeExtension
    {
        public static IQueryable<Tag> LikeTag(this IQueryable<Tag> query, string text)
            => string.IsNullOrEmpty(text) ? query : query.Where(x => x.Name.ToLower().StartsWith(text.ToLower()));
    }
}