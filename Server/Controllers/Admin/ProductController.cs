using LittleThings.Server.Data;
using LittleThings.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LittleThings.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly DataContext _dataContext;

        public ProductController(IConfiguration config, DataContext dataContext) : base(config, dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var result = await _dataContext.Product
                .Include(h => h.Category)
                .ToListAsync();

            return Ok(result);
        }

        private async Task<List<Product>> GetDBProducts()
        {
            return await _dataContext.Product
                .Include(h => h.Category)
                .ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(Guid id)
        {
            var product = await _dataContext.Product
                .Include(h => h.Category)
                .FirstOrDefaultAsync(h => h.Id == id);

            _dataContext.Product.Remove(product);
            await _dataContext.SaveChangesAsync();
            return Ok(await GetProducts());
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct(Product prod)
        {
            prod.Category = null;

            _dataContext.Product.Add(prod);
            await _dataContext.SaveChangesAsync();
            return Ok(await GetDBProducts());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(Product prod, Guid id)
        {
            var product = await _dataContext.Product
                .Include(h => h.Category)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Id = prod.Id;
            product.Title = prod.Title;
            product.Description = prod.Description;
            product.CategoryId = prod.CategoryId;
            product.Featured = prod.Featured;
            product.Image = prod.Image;
            product.Price = prod.Price;
            product.OriginalPrice = prod.OriginalPrice;
            product.CreatedAt = prod.CreatedAt;

            await _dataContext.SaveChangesAsync();
            return Ok(await GetProducts());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetSingleProduct(Guid id)
        {
            var prod = await _dataContext.Product
            .Include(i => i.Category)
            .FirstOrDefaultAsync(h => h.Id == id);

            if (prod != null)
            {
                return Ok(prod); 
            }
            return NotFound("Record not found!");
        }
    }
}
