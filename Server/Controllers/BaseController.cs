using LittleThings.Client.Services.AuthS;
using LittleThings.Server.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Security.Claims;

namespace LittleThings.Server.Controllers
{
    public class BaseController : Controller
    {
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        public readonly AuthenticationStateProvider _authStateProvider;

        public BaseController(IConfiguration config, DataContext context)
        {
            _config = config;
            _context = context;
        }

        public SqlConnection GetConnectionString()
        {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!User.Identity.IsAuthenticated)
            {
                Unauthorized();
                return;
            }
            else
            {
                var controllerName = filterContext.RouteData.Values["controller"];
                var actionName = filterContext.RouteData.Values["action"];

                var checkPermission = (from a in _context.UserRole
                                join c in _context.RolePermission on a.RoleId equals c.RoleId
                                where a.User.Username == User.Identity.Name
                                select(a.Id))
                               .SingleOrDefault();

                if (checkPermission == 0)
                {
                    NotFound();
                    return;
                }
            }
        }
    }
}
