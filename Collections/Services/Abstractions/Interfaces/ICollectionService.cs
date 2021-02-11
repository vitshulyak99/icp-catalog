using System.Collections.Generic;
using Services.Dto;

namespace Services.Abstractions.Interfaces
{
    public interface ICollectionService : ICrudService<CollectionDto>, IPermission
    {
        IEnumerable<FieldDto> GetFields(int id);
        IEnumerable<CollectionDto> ByUser(int userId);
    }
}
