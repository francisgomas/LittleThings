using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LittleThings.Client.Services.RoleS
{
    public class PermissionService : IPermissionService
    {
        public List<Permission> Permissions { get; set; } = new List<Permission>();

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public PermissionService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }

        public async Task DeletePermission(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/permission/{id}");
            if (response.IsSuccessStatusCode)
            {
                await GetAdminPermissions();
            }
        }

        public async Task GetAdminPermissions()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Permission>>("api/permission");
            if (result.Count > 0)
            {
                Permissions = result;
            }
            else
            {
                Permissions.Clear();
            }
        }

        public async Task<Permission> GetSinglePermission(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Permission>($"api/permission/{id}");
            if (result != null)
            {
                return result;
            }
            return new Permission();
        }

        public async Task UpdatePermission(Permission permission)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/permission/{permission.Id}", permission);
            if (response.IsSuccessStatusCode)
            {
                await GetAdminPermissions();
                _navigationManager.NavigateTo("admin/permission");
            }
        }

        public async Task CreatePermission(Permission permission)
        {
            var response = await _httpClient.PostAsJsonAsync("api/permission", permission);
            if (response.IsSuccessStatusCode)
            {
                await GetAdminPermissions();
                _navigationManager.NavigateTo("admin/permission");
            }
        }
    }
}
