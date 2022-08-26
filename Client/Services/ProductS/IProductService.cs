namespace LittleThings.Client.Services.ProductS
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task GetProducts();
        Task GetHomeProducts();
        Task DeleteProduct(Guid id);
        Task<Product> GetSingleProduct(Guid id);
        Task UpdateProduct(Product prod);
        Task CreateProduct(Product prod);
    }
}
