using LittleThings.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace LittleThings.Server.Controllers
{
    public class BaseController : Controller
    {
        private readonly IConfiguration _config;
        public BaseController(IConfiguration config)
        {
            _config = config;   
        }

        public SqlConnection GetConnectionString()
        {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }
    }
}
