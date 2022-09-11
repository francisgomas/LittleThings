namespace LittleThings.Client.Services.HomeS
{
    public interface IHomeService
    {
        List<Product> Products { get; set; }
        List<Category> Categories { get; set; }
        List<SocialMedia> SocialMedias { get; set; }

        Task GetHomeProductOnCat(Guid id);
        Task<Category> GetSingleCategory(Guid id);
        Task<Product> GetSingleProduct(Guid id);
        Task GetHomeProducts();
        Task GetAllProducts();
        Task GetHomeCategories();
        Task GetSocialMedias();
        Task<List<string>> GetProductSearchSuggestions(string searchText);
        Task SearchProducts(string searchText, int page);
    }
}
