using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LittleThings.Client.Services.HomeS
{
    public class HomeService : IHomeService
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public HomeService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task GetHomeProductOnCat(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Product>>($"api/home/prodcat?id={id}");
            if (result.Count > 0)
            {
                Products = result;
            }
            else
            {
                Products.Clear();
            }
        }

        public async Task GetHomeProducts()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Product>>("api/home/products");
            if (result.Count > 0)
            {
                Products = result;
            }
            else
            {
                Products.Clear();
            }
        }

        public async Task GetAllProducts()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Product>>("api/home/all-products");
            if (result.Count > 0)
            {
                Products = result;
            }
            else
            {
                Products.Clear();
            }
        }

        public async Task GetHomeCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Category>>("api/home/categories");
            if (result.Count > 0)
            {
                Categories = result;
            }
            else
            {
                Categories.Clear();
            }
        }

        public async Task GetSocialMedias()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SocialMedia>>("api/home/socialmedia");
            if (result.Count > 0)
            {
                SocialMedias = result;
            }
            else
            {
                SocialMedias.Clear();
            }
        }

        public async Task<Category> GetSingleCategory(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<Category>($"api/home/category?id={id}");
            if (result != null)
            {
                return result;
            }
            return new Category();
        }

        public async Task<Product> GetSingleProduct(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<Product>($"api/home/product?id={id}");
            if (result != null)
            {
                return result;
            }
            return new Product();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpClient
                .GetFromJsonAsync<ServiceResponse<List<string>>>($"api/home/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchProducts(string searchText, int page)
        {
            var result = await _httpClient
                 .GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/home/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }
        }
    }
}
