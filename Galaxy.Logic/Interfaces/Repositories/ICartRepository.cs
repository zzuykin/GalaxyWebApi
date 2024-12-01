
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;

namespace Galaxy.Logic.Interfaces.Repositories
{
    public interface ICartRepository
    {
        public Task<Cart> Create(DataContext context, Cart cart);

        public Task Delete(DataContext context, Guid UserId);

        public  Task<Cart> GetByUserId(DataContext context, Guid UserId);
    }
}
