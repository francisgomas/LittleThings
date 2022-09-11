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

        public async Task DeleteSocialMedia(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/socialmedia/{id}");
            if (response.IsSuccessStatusCode)
            {
                await GetAdminSocialMedias();
            }
        }

        public async Task GetAdminSocialMedias()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SocialMedia>>("api/socialmedia");
            if (result.Count > 0)
            {
                SocialMedias = result;
            }
            else
            {
                SocialMedias.Clear();
            }
        }

        public async Task<SocialMedia> GetSingleSocialMedia(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<SocialMedia>($"api/socialmedia/{id}");
            if (result != null)
            {
                return result;
            }
            return new SocialMedia();
        }

        public async Task UpdateSocialMedia(SocialMedia media)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/socialmedia/{media.Id}", media);
            if (response.IsSuccessStatusCode)
            {
                await GetAdminSocialMedias();
                _navigationManager.NavigateTo("admin/social-media");
            }
        }

        public async Task CreateSocialMedia(SocialMedia media)
        {
            var response = await _httpClient.PostAsJsonAsync("api/socialmedia", media);
            if (response.IsSuccessStatusCode)
            {
                await GetAdminSocialMedias();
                _navigationManager.NavigateTo("admin/social-media");
            }
        }
    }
}
