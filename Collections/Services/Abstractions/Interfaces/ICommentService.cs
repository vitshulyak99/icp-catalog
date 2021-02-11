using System.Collections.Generic;
using Services.Dto;

namespace Services.Abstractions.Interfaces
{
    public interface ICommentService : ICrudService<CommentDto>
    {
        IEnumerable<CommentDto> GetByItem(int id);
    }
}