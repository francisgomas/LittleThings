using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LittleThings.Client.Services.SubCategoryS
{
    public class SubCategoryService : ISubCategoryService
    {
        public List<SubCategory> SubCategories { get; set; }

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public SubCategoryService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task CreateSubCategory(SubCategory subc)
        {
            var response = await _httpClient.PostAsJsonAsync("api/subcategory", subc);
            if (response.IsSuccessStatusCode)
            {
                await GetSubCategories();
                _navigationManager.NavigateTo("admin/subcategory");
            }
        }

        public async Task DeleteSubCategory(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/subcategory/{id}");
            if (response.IsSuccessStatusCode)
            {
                await GetSubCategories();
            }
        }

        public async Task<SubCategory> GetSingleSubCategory(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<SubCategory>($"api/subcategory/{id}");
            return result;
        }

        public async Task GetSubCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SubCategory>>("api/subcategory");
            if (result != null)
            {
                SubCategories = result;
            }
        }

        public async Task UpdateSubCategory(SubCategory subc)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/subcategory/{subc.Id}", subc);
            if (response.IsSuccessStatusCode)
            {
                await GetSubCategories();
                _navigationManager.NavigateTo("admin/subcategory");
            }
        }
    }
}
