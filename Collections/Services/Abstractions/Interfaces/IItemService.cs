using System.Collections.Generic;
using System.Linq;
using Collections.DAL.Entities;

namespace Services.Abstractions.Interfaces
{
    public interface IItemService : ICrudService<Item> , IPermission
    {
        bool SetLike(int id, int userId);
        IQueryable<Item> Search(string text);
        IEnumerable<Item> GetByCollection(int id);
    }
}