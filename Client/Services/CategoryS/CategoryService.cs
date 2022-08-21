using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LittleThings.Client.Services.CategoryS
{
    public class CategoryService : ICategoryService
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<SubCategory> SubCategories { get; set; } = new List<SubCategory>();

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public CategoryService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task CreateCategory(Category cat)
        { 
            var response = await _httpClient.PostAsJsonAsync("api/category", cat);
            if (response.IsSuccessStatusCode)
            {
                await GetCategories();
                _navigationManager.NavigateTo("admin/category");
            }
        }

        public async Task DeleteCategory(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/category/{id}");
            if (response.IsSuccessStatusCode)
            {
                await GetCategories();
            }
        }

        public async Task GetCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Category>>("api/category");
            if (result != null)
            {
                Categories = result;
            }
        }

        public async Task GetHomeCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Category>>("api/home/categories");
            if (result != null)
            {
                Categories = result.Take(6).ToList();
            }
        }

        public async Task GetSubCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SubCategory>>("api/subcategory");
            SubCategories = result;
        }

        public async Task<Category> GetSingleCategory(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<Category>($"api/category/{id}");
            return result;
        }

        public async Task UpdateCategory(Category cat)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/category/{cat.Id}", cat);
            if (response.IsSuccessStatusCode)
            {
                await GetCategories();
                _navigationManager.NavigateTo("admin/category");
            }
        }
    }
}
