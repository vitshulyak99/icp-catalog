using System.Collections.Generic;
using Collections.DAL.Entities;
using Services.DTO;

namespace Services.Abstractions.Interfaces
{
    public interface ITagService : ICrudService<TagDto>
    {
        IEnumerable<TagDto> GetLike(string text);
    }
}