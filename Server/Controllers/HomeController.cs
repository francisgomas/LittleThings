using LittleThings.Server.Data;
using LittleThings.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LittleThings.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public HomeController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet("socialmedia")]
        public async Task<ActionResult<List<SocialMedia>>> GetSocialMedias()
        {
            var links = await _dataContext.SocialMedia.ToListAsync();
            return Ok(links);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var cats = await _dataContext.Category.Take(8).ToListAsync();
            return Ok(cats);
        }

        [HttpGet("products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var prods = await _dataContext.Product
                   .Where(u => u.Featured == true).Take(12).ToListAsync();
            return Ok(prods);
        }

        [HttpGet("all-products")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var prods = await _dataContext.Product.ToListAsync();
            return Ok(prods);
        }

        [HttpGet("prodcat")]
        public async Task<ActionResult<List<Product>>> GetProductsBasedOnCat(Guid id)
        {
            var prods = await _dataContext.Product
                    .Where(h => h.CategoryId == id).Take(20).ToListAsync();
            return Ok(prods);
        }

        [HttpGet("category")]
        public async Task<ActionResult<List<Category>>> GetSingleCategory(Guid id)
        {
            var cat = await _dataContext.Category
                    .FirstOrDefaultAsync(h => h.Id == id);
            return Ok(cat);
        }

        [HttpGet("product")]
        public async Task<ActionResult<List<Product>>> GetSingleProduct(Guid id)
        {
            var prod = await _dataContext.Product
                    .FirstOrDefaultAsync(h => h.Id == id);
            return Ok(prod);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await _dataContext.Product
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower()))
                                .ToListAsync(); ;

            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }
            }

            return Ok(new ServiceResponse<List<string>> { Data = result });
        }

        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProducts(string searchText, int page = 1)
        {
            var pageResults = 2f;
            var products = await _dataContext.Product
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower()))
                                .Include(p => p.Category)
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<List<Product>>
            {
                Data = products
            };
            return Ok(response);
        }
    }
}
