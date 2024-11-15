
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;

namespace Galaxy.Logic.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public Product GetById(DataContext context, int id);

        public IQueryable<Product> GetAllProduct(DataContext context);

    }
}
