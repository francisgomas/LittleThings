using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LittleThings.Client.Services.ProductS
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Category> Categories { get; set; } = new List<Category>();

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public ProductService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }
        public async Task CreateProduct(Product prod)
        {
            var response = await _httpClient.PostAsJsonAsync("api/product", prod);
            if (response.IsSuccessStatusCode)
            {
                await GetProducts();
                _navigationManager.NavigateTo("admin/product");
            }
        }

        public async Task DeleteProduct(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/product/{id}");
            if (response.IsSuccessStatusCode)
            {
                await GetProducts();
            }
        }

        public async Task GetCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Category>>("api/category");
            if (result.Count > 0)
            {
                Categories = result;
            }
            else
            {
                Categories.Clear();
            }
        }

        public async Task GetProducts()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Product>>("api/product");
            if (result.Count > 0)
            {
                Products = result;
            }  
            else
            {
                Products.Clear();
            }
        }

        public async Task<Product> GetSingleProduct(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<Product>($"api/product/{id}");
            if (result != null){
                return result;
            }
            return new Product();
        }

        public async Task UpdateProduct(Product prod)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/product/{prod.Id}", prod);
            if (response.IsSuccessStatusCode)
            {
                await GetProducts();
                _navigationManager.NavigateTo("admin/product");
            }
        }

        
    }
}
