using Collections.DAL.Entities;

namespace Services.Abstractions.Interfaces
{
    public interface ICollectionService : ICrudService<Collection>
    {
        bool CheckPermissions(int id, string username);
    }
}
