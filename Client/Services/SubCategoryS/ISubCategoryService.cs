namespace LittleThings.Client.Services.SubCategoryS
{
    public interface ISubCategoryService
    {
        List<SubCategory> SubCategories { get; set; }
        Task GetSubCategories();
        Task DeleteSubCategory(Guid id);
        Task<SubCategory> GetSingleSubCategory(Guid id);
        Task UpdateSubCategory(SubCategory subc);
        Task CreateSubCategory(SubCategory subc);
    }
}
