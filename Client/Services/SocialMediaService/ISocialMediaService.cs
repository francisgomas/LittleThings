global using LittleThings.Shared;

namespace LittleThings.Client.Services.SocialMediaService
{
    public interface ISocialMediaService
    {
        List<SocialMedia> SocialMedias { get; set; }
        Task GetSocialMedias();

    }
}
