
using Galaxy.Logic.Interfaces.Repositories;
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;
using WebApplication1.Features.Interfaces.Managers;

namespace WebApplication1.Features.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly DataContext _dataContext;
        private readonly IProductRepository _productRepository;

        public ProductManager(DataContext dataContext, IProductRepository productRepository)
        {
            _dataContext = dataContext;
            _productRepository = productRepository;
        }

        public List<Product> GetListProduct()
        {
            var products = _productRepository.GetAllProduct(_dataContext).ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = _productRepository.GetById(_dataContext, id);
            return product;
        }
    }
}
