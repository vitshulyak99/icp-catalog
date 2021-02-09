namespace Services.Abstractions.Interfaces
{
    public interface IPermission
    {
        bool HasPermissions(int id, int userId);
    }
}