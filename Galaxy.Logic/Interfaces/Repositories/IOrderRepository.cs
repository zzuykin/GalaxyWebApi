using Galaxy.Storage.Models;
using Galaxy.Storage.DataBase;

namespace Galaxy.Logic.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public Order Create(DataContext context, Order order);
        public Order Update(DataContext context, Order order);

        public Order Delete(DataContext context, Guid isNode);

        public Order GetById(DataContext context, Guid id);
    }
}
