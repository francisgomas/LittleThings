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
            if (links != null)
            {
                return Ok(links);
            }
            return NotFound();
        }
    }
}
