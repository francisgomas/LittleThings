using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LittleThings.Client.Services.RoleS
{
    public class RoleService : IRoleService
    {
        public List<Role> Roles { get; set; } = new List<Role>();

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public RoleService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }

        public async Task DeleteRole(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/role/{id}");
            if (response.IsSuccessStatusCode)
            {
                await GetAdminRoles();
            }
        }

        public async Task GetAdminRoles()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Role>>("api/role");
            if (result.Count > 0)
            {
                Roles = result;
            }
            else
            {
                Roles.Clear();
            }
        }

        public async Task<Role> GetSingleRole(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Role>($"api/role/{id}");
            if (result != null)
            {
                return result;
            }
            return new Role();
        }

        public async Task UpdateRole(Role role)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/role/{role.Id}", role);
            if (response.IsSuccessStatusCode)
            {
                await GetAdminRoles();
                _navigationManager.NavigateTo("admin/role");
            }
        }

        public async Task CreateRole(Role role)
        {
            var response = await _httpClient.PostAsJsonAsync("api/role", role);
            if (response.IsSuccessStatusCode)
            {
                await GetAdminRoles();
                _navigationManager.NavigateTo("admin/role");
            }
        }
    }
}
