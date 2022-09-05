namespace LittleThings.Client.Services.CartS
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
    }
}
