using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LittleThings.Client.Services.SocialMediaS
{
    public class SocialMediaService : ISocialMediaService
    {
        public List<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public SocialMediaService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }
        public async Task GetSocialMedias()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SocialMedia>>("api/home/socialmedia");
            SocialMedias = result;
        }

        public async Task DeleteSocialMedia(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/socialmedia/{id}");
            if (response.IsSuccessStatusCode)
            {
                await GetSocialMedias();
            }
        }

        public async Task GetAdminSocialMedias()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SocialMedia>>("api/socialmedia");
            SocialMedias = result;
        }

        public async Task<SocialMedia> GetSingleSocialMedia(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<SocialMedia>($"api/socialmedia/{id}");
            return result;
        }

        public async Task UpdateSocialMedia(SocialMedia media)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/socialmedia/{media.Id}", media);
            if (response.IsSuccessStatusCode)
            {
                await GetSocialMedias();
                _navigationManager.NavigateTo("admin/social-media");
            }
        }

        public async Task CreateSocialMedia(SocialMedia media)
        {
            var response = await _httpClient.PostAsJsonAsync("api/socialmedia", media);
            if (response.IsSuccessStatusCode)
            {
                await GetSocialMedias();
                _navigationManager.NavigateTo("admin/social-media");
            }
        }
    }
}
