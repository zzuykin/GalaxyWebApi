
using Galaxy.Logic.Interfaces.Repositories;
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace Galaxy.Logic.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product GetById(DataContext context, int id)
        {
            var productDb = context.Products.FirstOrDefault(x => x.IsnNode == id)
                ?? throw new Exception($"Не найдено такое сообщение с индификатором {id}");

            return productDb;
        }

        public IQueryable<Product> GetAllProduct(DataContext context)
        {
            var products = context.Products.AsNoTracking();
            return products;
        }
    }
}
