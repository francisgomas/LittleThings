namespace LittleThings.Client.Services.CategoryS
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        Task GetCategories();
    }
}
