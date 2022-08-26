namespace LittleThings.Client.Services.ProductS
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; }

        public Task CreateProduct(Product prod)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task GetHomeProducts()
        {
            throw new NotImplementedException();
        }

        public Task GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetSingleProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product prod)
        {
            throw new NotImplementedException();
        }
    }
}
