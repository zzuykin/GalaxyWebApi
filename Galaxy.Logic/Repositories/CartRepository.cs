

using Galaxy.Logic.Interfaces.Repositories;
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace Galaxy.Logic.Repositories
{
    public class CartRepository : ICartRepository
    {
        public async Task<Cart> Create(DataContext context, Cart cart)
        {
            await context.Carts.AddAsync(cart);
            await context.SaveChangesAsync();
            return cart;
        }


        public async Task Delete(DataContext context, Guid UserId) 
        {
            var cartDb = await context.Carts.FirstOrDefaultAsync(x => x.UserId == UserId)
               ?? throw new Exception($"$Корзины пользователя {UserId} не найдено");
            context.Carts.Remove( cartDb );
            await context.SaveChangesAsync();
        }

        public async Task<Cart> GetByUserId(DataContext context, Guid UserId)
        {
            var cart = await context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == UserId)
        ?? throw new Exception($"Корзина пользователя {UserId} не найдена");
            return cart;
        }
    }
}
