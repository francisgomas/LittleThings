using LittleThings.Server.Data;
using LittleThings.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LittleThings.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public CategoryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var result = await _dataContext.Category
                .Include(h => h.SubCategory)
                .ToListAsync();
            return Ok(result);
        }

        private async Task<List<Category>> GetDBCategories()
        {
            return await _dataContext.Category
                .Include(h => h.SubCategory)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> CreateCategory(Category cat)
        {
            cat.SubCategory = null;

            _dataContext.Category.Add(cat);
            await _dataContext.SaveChangesAsync();

            return Ok(await GetDBCategories());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(Category cat, Guid id)
        {
            var category = await _dataContext.Category
                .Include(h => h.SubCategory)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            category.Id = cat.Id;
            category.Name = cat.Name;
            category.SubCategoryId = cat.SubCategoryId;
            category.LinkUrl = cat.LinkUrl;
            category.ImageURL = cat.ImageURL;

            await _dataContext.SaveChangesAsync();
            return Ok(await GetCategories());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(Guid id)
        {
            var category = await _dataContext.Category
                .Include(h => h.SubCategory)
                .FirstOrDefaultAsync(h => h.Id == id);

            _dataContext.Category.Remove(category);
            await _dataContext.SaveChangesAsync();
            return Ok(await GetCategories());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Category>> GetSingleCategory(Guid id)
        {
            var cat = await _dataContext.Category
            .Include(i => i.SubCategory)
            .FirstOrDefaultAsync(h => h.Id == id);

            if (cat != null)
            {
                return Ok(cat);
            }
            return NotFound("Record not found!");
        }
    }
}
