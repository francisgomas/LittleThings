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
    public class PermissionController : BaseController
    {
        public PermissionController(IConfiguration config, DataContext context) : base(config, context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<Permission>>> GetPermissions()
        {
            var query = "SELECT * FROM Permission";
            var links = await GetConnectionString().QueryAsync<Permission>(query);
            return Ok(links);
        }

        [HttpPost]
        public async Task<ActionResult<List<Permission>>> CreatePermissions(Permission permission)
        {
            var query = "INSERT INTO Permission (controllername, actionname) values (@controllername, @actionname)";
            await GetConnectionString().ExecuteAsync(query, new
            {
                controllername = permission.ControllerName,
                actionname = permission.ActionName
            });

            return Ok(await GetPermissions());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Permission>>> UpdatePermissions(Permission permission, int id)
        {
            var query = "UPDATE Permission set controllername = @controllername, actionname = @actionname WHERE id = @id";
            await GetConnectionString().ExecuteAsync(query, new
            {
                id = id,
                controllername = permission.ControllerName,
                actionname = permission.ActionName
            });

            return Ok(await GetPermissions());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Permission>> DeletePermissions(int id)
        {
            var query = "DELETE FROM Permission WHERE id = @id";
            await GetConnectionString().ExecuteAsync(query, new
            {
                id = id
            });
            return Ok(await GetPermissions());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Permission>> GetSinglePermission(int id)
        {
            var query = "SELECT * FROM Permission WHERE Id = @Id";
            var permissions = await GetConnectionString().QueryFirstOrDefaultAsync<Permission>(query, new {
                Id = id
            });

            if (permissions != null)
            {
                return Ok(permissions);
            }
            return NotFound("Record not found!");
        }
    }
}
