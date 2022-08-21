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
            var cats = await _dataContext.Category.ToListAsync();
            return Ok(cats);
        }
    }
}
