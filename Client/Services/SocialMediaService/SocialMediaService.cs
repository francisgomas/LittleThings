using System.Net.Http.Json;

namespace LittleThings.Client.Services.SocialMediaService
{
    public class SocialMediaService : ISocialMediaService
    {
        public List<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();

        private readonly HttpClient _httpClient;
        public SocialMediaService(HttpClient http)
        {
            _httpClient = http;
        }
        public async Task GetSocialMedias()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SocialMedia>>("api/home/socialmedia");
            SocialMedias = result;
        }
    }
}
