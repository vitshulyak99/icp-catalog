using System.Collections.Generic;
using Collections.DAL.Entities;

namespace Services.Abstractions.Interfaces
{
    public interface ITagService : ICrudService<Tag>
    {
        IEnumerable<Tag> GetLike(string text);
    }
}