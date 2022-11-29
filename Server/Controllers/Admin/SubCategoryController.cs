using LittleThings.Server.Data;
using LittleThings.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LittleThings.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SubCategoryController : BaseController
    {
        private readonly DataContext _dataContext;
        public SubCategoryController(IConfiguration config, DataContext dataContext) : base(config, dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<SubCategory>>> GetSubCategories()
        {
            var subcategories = await _dataContext.SubCategory.ToListAsync();
            return Ok(subcategories);
        }

        [HttpPost]
        public async Task<ActionResult<List<SubCategory>>> CreateSubCategories(SubCategory subc)
        {
            _dataContext.SubCategory.Add(subc);
            await _dataContext.SaveChangesAsync();

            return Ok(await GetSubCategories());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategory>> UpdateSubCategory(SubCategory subc, Guid id)
        {
            var subCategory = await _dataContext.SubCategory.FirstOrDefaultAsync(h => h.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }
            subCategory.Id = subc.Id;
            subCategory.Name = subc.Name;

            await _dataContext.SaveChangesAsync();
            return Ok(await GetSubCategories());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCategory>> DeleteSubCategory(Guid id)
        {
            var subCategory = await _dataContext.SubCategory.FirstOrDefaultAsync(h => h.Id == id);
            _dataContext.SubCategory.Remove(subCategory);
            await _dataContext.SaveChangesAsync();
            return Ok(await GetSubCategories());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SubCategory>> GetSingleSubCategory(Guid id)
        {
            var subc = await _dataContext.SubCategory
            .FirstOrDefaultAsync(h => h.Id == id);

            if (subc != null)
            {
                return Ok(subc);
            }
            return NotFound("Record not found!");
        }
    }
}
