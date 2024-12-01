
using Galaxy.Storage.Models;

namespace WebApplication1.Features.Interfaces.Managers
{
    public interface IProductManager
    {
        public List<Product> GetListProduct();
        public Product GetProductById(int id);
    }
}
