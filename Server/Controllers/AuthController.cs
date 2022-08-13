using LittleThings.Client.Services.AuthS;
using LittleThings.Server.Data;
using LittleThings.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace LittleThings.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _iconfig;

        public AuthController(DataContext dataContext, IConfiguration config)
        {
            _dataContext = dataContext;
            _iconfig = config;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            var response = new ServiceResponse<string>();
            var user = await _dataContext.User
                .Include(i => i.Role)
                .FirstOrDefaultAsync(y => y.Username.ToLower()
                .Equals(request.Username.ToLower()));

            if (user == null)
            {
                response.Success = false;
                response.Message = "Invalid credentials";
            }
            else if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Invalid credentials";
            }
            else
            {
                response.Success = true;
                response.Data = CreateToken(user);
            }
            
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("profile")]
        public async Task<ActionResult<ServiceResponse<string>>> Profile([FromBody] string newPassword)
        {
            var response = new ServiceResponse<string>();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _dataContext.User.FindAsync(Guid.Parse(userId));

            if (user == null)
            {
                response.Data = "alert-danger";
                response.Message = "User not found";
                return BadRequest(response);
            }
            
            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dataContext.SaveChangesAsync();

            response.Data = "alert-success";
            response.Message = "Password changed successfully";
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<Guid>>> Register(UserRegister request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User();

            user.Name = request.Name;
            user.Email = request.Email;
            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.RoleId = 1;

            _dataContext.User.Add(user);
            await _dataContext.SaveChangesAsync();

            var response = new ServiceResponse<Guid> { Data = user.Id, Message = "Registration successful!" };
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.RoleName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_iconfig.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
