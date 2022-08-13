global using LittleThings.Shared;

namespace LittleThings.Client.Services.SocialMediaS
{
    public interface ISocialMediaService
    {
        List<SocialMedia> SocialMedias { get; set; }
        Task GetSocialMedias();
        Task GetAdminSocialMedias();
        Task DeleteSocialMedia (int id);
        Task<SocialMedia> GetSingleSocialMedia(int id);
        Task UpdateSocialMedia(SocialMedia media);
        Task CreateSocialMedia(SocialMedia media);

    }
}
