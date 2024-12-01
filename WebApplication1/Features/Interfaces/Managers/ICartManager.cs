
using Galaxy.Storage.Models;

namespace WebApplication1.Features.Interfaces.Managers
{
    public interface ICartManager
    {
        public  Task AddToCart(Guid userId, int productId);
        public Task<Cart> AddCart(Guid userId);
        public double SumOFCart(List<CartItem> cartItems);
        public  Task<int> GetCartItemCount(Guid userId);
        public  Task RemoveFromCart(Guid userId, int productId);
        public  Task DeleteFromCart(Guid userId, int productId);
    }
}
