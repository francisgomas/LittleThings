using LittleThings.Server.Data;
using LittleThings.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LittleThings.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public SocialMediaController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SocialMedia>>> GetSMLinks()
        {
            var links = await _dataContext.SocialMedia.ToListAsync();
            if (links == null)
            {
                return NotFound();
            }
            return Ok(links);
        }


        [HttpPost]
        public async Task<ActionResult<List<SocialMedia>>> CreateSocialMedias(SocialMedia sm)
        {
            _dataContext.SocialMedia.Add(sm);
            await _dataContext.SaveChangesAsync();

            return Ok(await GetSMLinks());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SocialMedia>> UpdateSocialMedia(SocialMedia sm, int id)
        {
            var socialMedia = await _dataContext.SocialMedia.FirstOrDefaultAsync(h => h.Id == id);
            if (sm == null)
            {
                return NotFound();
            }
            socialMedia.Id = sm.Id;
            socialMedia.Icon = sm.Icon;
            socialMedia.Link = sm.Link;
            socialMedia.InNewTab = sm.InNewTab;

            await _dataContext.SaveChangesAsync();
            return Ok(await GetSMLinks());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SocialMedia>> DeleteSocialMedia(SocialMedia sm, int id)
        {
            var socialMedia = await _dataContext.SocialMedia.FirstOrDefaultAsync(h => h.Id == id);
            if (sm == null)
            {
                return NotFound();
            }
            _dataContext.SocialMedia.Remove(sm);

            await _dataContext.SaveChangesAsync();
            return Ok(await GetSMLinks());
        }

    }
}
