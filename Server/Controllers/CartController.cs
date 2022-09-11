using LittleThings.Server.Data;
using LittleThings.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LittleThings.Server.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartController(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
            
        }
        [NonAction]
        public Guid GetUserId() => Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId = GetUserId();
            var sameItem = await _dataContext.CartItem
                .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
                    ci.UserId == cartItem.UserId);

            if (sameItem == null)
            {
                _dataContext.CartItem.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _dataContext.SaveChangesAsync();
            return Ok(new ServiceResponse<bool> { Data = true });
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount()
        {
            var count = (await _dataContext.CartItem.Where(ci => ci.UserId == GetUserId()).ToListAsync()).Count;
            return Ok(new ServiceResponse<int> { Data = count });
        }
    }
}
