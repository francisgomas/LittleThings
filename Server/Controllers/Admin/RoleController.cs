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
    public class RoleController : BaseController
    {
        public RoleController(IConfiguration config, DataContext context) : base(config, context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {
            var query = "SELECT * FROM Role";
            var links = await GetConnectionString().QueryAsync<Role>(query);
            return Ok(links);
        }

        [HttpPost]
        public async Task<ActionResult<List<Role>>> CreateRoles(Role role)
        {
            var query = "INSERT INTO Role (rolename, roledescription) values (@rolename, @roledescription)";
            await GetConnectionString().ExecuteAsync(query, new
            {
                rolename = role.RoleName,
                roledescription = role.RoleDescription
            });

            return Ok(await GetRoles());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Role>>> UpdateRoles(Role role, int id)
        {
            var query = "UPDATE Role set rolename = @rolename, roledescription = @roledescription WHERE id = @id";
            await GetConnectionString().ExecuteAsync(query, new
            {
                id = id,
                rolename = role.RoleName,
                roledescription = role.RoleDescription
            });

            return Ok(await GetRoles());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRoles(int id)
        {
            var query = "DELETE FROM Role WHERE id = @id";
            await GetConnectionString().ExecuteAsync(query, new
            {
                id = id
            });
            return Ok(await GetRoles());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Role>> GetSingleRole(int id)
        {
            var query = "SELECT * FROM Role WHERE Id = @Id";
            var roles = await GetConnectionString().QueryFirstOrDefaultAsync<Role>(query, new {
                Id = id
            });

            if (roles != null)
            {
                return Ok(roles);
            }
            return NotFound("Record not found!");
        }
    }
}
