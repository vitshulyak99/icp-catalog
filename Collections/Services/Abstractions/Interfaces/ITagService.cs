using System.Collections.Generic;
using Services.Dto;

namespace Services.Abstractions.Interfaces
{
    public interface ITagService : ICrudService<TagDto>
    {
        IEnumerable<TagDto> GetLike(string text);
    }
}