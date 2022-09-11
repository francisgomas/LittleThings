namespace LittleThings.Client.Services.CategoryS
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        List<SubCategory> SubCategories { get; set; }
        Task GetCategories();
        Task GetSubCategories();
        Task DeleteCategory(Guid id);
        Task<Category> GetSingleCategory(Guid id);
        Task UpdateCategory(Category cat);
        Task CreateCategory(Category cat);
    }
}
