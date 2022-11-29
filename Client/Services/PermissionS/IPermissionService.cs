global using LittleThings.Shared;

namespace LittleThings.Client.Services.RoleS
{
    public interface IPermissionService
    {
        List<Permission> Permissions { get; set; }
        Task GetAdminPermissions();
        Task DeletePermission (int id);
        Task<Permission> GetSinglePermission(int id);
        Task UpdatePermission(Permission permission);
        Task CreatePermission(Permission permission);

    }
}
