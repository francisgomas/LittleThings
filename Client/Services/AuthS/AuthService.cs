using System.Net.Http.Json;

namespace LittleThings.Client.Services.AuthS
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;
        public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public async Task<ServiceResponse<Guid>> Register(UserRegister request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
        }

        public async Task<ServiceResponse<string>> Login(UserLogin request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<ServiceResponse<string>> ChangePassword(ChangePassword request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/change-password", request.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
