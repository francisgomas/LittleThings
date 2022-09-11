namespace LittleThings.Client.Services.ProductS
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        List<Category> Categories { get; set; }
        Task GetProducts();
        Task DeleteProduct(Guid id);
        Task GetCategories();
        Task<Product> GetSingleProduct(Guid id);
        Task UpdateProduct(Product prod);
        Task CreateProduct(Product prod);
    }
}
