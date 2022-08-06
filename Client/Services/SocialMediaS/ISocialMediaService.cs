global using LittleThings.Shared;

namespace LittleThings.Client.Services.SocialMediaS
{
    public interface ISocialMediaService
    {
        List<SocialMedia> SocialMedias { get; set; }
        Task GetSocialMedias();

    }
}
