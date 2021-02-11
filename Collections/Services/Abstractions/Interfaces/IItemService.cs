using System.Collections.Generic;
using Collections.DAL.Entities;
using Services.Dto;

namespace Services.Abstractions.Interfaces
{
    public interface IItemService : ICrudService<ItemDto> , IPermission
    {
        bool SetLike(int id, int userId);
        IEnumerable<ItemDto> Search(string text);
        IEnumerable<ItemDto> GetByCollection(int id);
        IEnumerable<ItemDto> GetByTag(int id);
    }
}