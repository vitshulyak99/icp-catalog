using System.Collections.Generic;
using Collections.DAL.Entities;

namespace Services.Abstractions.Interfaces
{
    public interface ICollectionService : ICrudService<Collection>, IPermission
    {
        IEnumerable<Field> GetFields(int collectionId);
        IEnumerable<Collection> ByUser(int UserId);
    }
}
