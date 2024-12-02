

using Galaxy.Logic.Interfaces.Repositories;
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Features.Interfaces.Managers;

namespace WebApplication1.Features.Managers
{
    public class CartManager : ICartManager
    {
        private readonly DataContext _context;
        private readonly ICartRepository _cartRepository;

        public CartManager(DataContext context, ICartRepository cartRepository)
        {
            _context = context;
            _cartRepository = cartRepository;
        }

        public async Task AddToCart(Guid userId, int productId)
        {
            var cart = await _cartRepository.GetByUserId(_context, userId);

            if (cart == null)
            {
                throw new Exception("Корзина не найдена.");
            }

            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                throw new Exception("Продукт не найден.");
            }
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.CartItems.Add(new CartItem
                {
                    CartId = cart.IsnNode,
                    ProductId = productId,
                    Product = product,
                    Quantity = 1
                }); ;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Cart> AddCart(Guid userId)
        {
            var cart = await _context.Carts
        .Include(c => c.CartItems)
        .FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                var cartDb = new Cart()
                {
                    IsnNode = Guid.NewGuid(),
                    UserId = userId,
                    CartItems = new List<CartItem>()
                };
                return await _cartRepository.Create(_context, cartDb);
            }
            return cart;
        }

        public async Task<ICollection<CartItem>> GetCartItemsAsync(Guid userId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
            return cart.CartItems.ToList();
        }

        public double SumOFCart(List<CartItem> cartItems)
        {
            double sum = 0;
            foreach(var car in cartItems)
            {
                sum += car.Product.Price;
            }
            return sum;
            
        }

        public async Task<int> GetCartItemCount(Guid userId)
        {
            var cart = await _cartRepository.GetByUserId(_context, userId);

            if (cart == null)
            {
                return 0;
            }

            return cart.CartItems.Sum(ci => ci.Quantity);
        }

        public async Task RemoveFromCart(Guid userId, int productId)
        {
            var cart = await _cartRepository.GetByUserId(_context, userId);

            if (cart == null)
            {
                throw new Exception("Корзина не найдена.");
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    cart.CartItems.Remove(cartItem);
                }
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteFromCart(Guid userId, int productId)
        {
            var cart = await _cartRepository.GetByUserId(_context, userId);

            if (cart == null)
            {
                throw new Exception("Корзина не найдена.");
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem != null)
            {
                cart.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

    }
}
