using LittleThings.Server.Data;
using LittleThings.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LittleThings.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SocialMediaController : BaseController
    {
        public SocialMediaController(IConfiguration config, DataContext context) : base(config, context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<SocialMedia>>> GetSMLinks()
        {
            var query = "SELECT * FROM SocialMedia";
            var links = await GetConnectionString().QueryAsync<SocialMedia>(query);
            return Ok(links);
        }

        [HttpPost]
        public async Task<ActionResult<List<SocialMedia>>> CreateSocialMedias(SocialMedia sm)
        {
            var query = "INSERT INTO SocialMedia (icon, link) values (@icon, @link)";
            await GetConnectionString().ExecuteAsync(query, new
            {
                icon = sm.Icon,
                link = sm.Link
            });

            return Ok(await GetSMLinks());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SocialMedia>>> UpdateSocialMedia(SocialMedia sm, int id)
        {
            var query = "UPDATE SocialMedia set icon = @icon, link = @link WHERE id = @id";
            await GetConnectionString().ExecuteAsync(query, new
            {
                id = id,
                icon = sm.Icon,
                link = sm.Link
            });

            return Ok(await GetSMLinks());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SocialMedia>> DeleteSocialMedia(int id)
        {
            var query = "DELETE FROM SocialMedia WHERE id = @id";
            await GetConnectionString().ExecuteAsync(query, new
            {
                id = id
            });
            return Ok(await GetSMLinks());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SocialMedia>> GetSingleSocialMedia(int id)
        {
            var query = "SELECT * FROM SocialMedia WHERE Id = @Id";
            var links = await GetConnectionString().QueryFirstOrDefaultAsync<SocialMedia>(query, new {
                Id = id
            });

            if (links != null)
            {
                return Ok(links);
            }
            return NotFound("Record not found!");
        }
    }
}
