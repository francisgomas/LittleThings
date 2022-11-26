global using LittleThings.Shared;

namespace LittleThings.Client.Services.RoleS
{
    public interface IRoleService
    {
        List<Role> Roles { get; set; }
        Task GetAdminRoles();
        Task DeleteRole (int id);
        Task<Role> GetSingleRole(int id);
        Task UpdateRole(Role role);
        Task CreateRole(Role role);

    }
}
