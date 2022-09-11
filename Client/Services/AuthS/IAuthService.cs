namespace LittleThings.Client.Services.AuthS
{
    public interface IAuthService
    {
        Task<ServiceResponse<Guid>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin request);
        Task<ServiceResponse<string>> ChangePassword(ChangePassword request);
        Task<User> GetCurrentUser();
        Task<bool> IsUserAuthenticated();
    }
}
