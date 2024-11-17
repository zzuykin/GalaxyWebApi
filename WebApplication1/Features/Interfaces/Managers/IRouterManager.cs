using Galaxy.Storage.Models;
namespace WebApplication1.Features.Interfaces.Managers
{
    public interface IRouterManager
    {
        public List<Router> GetRoutes(string query);

        public List<Router> FilterRouter(List<Router> routers, string query);
    }
}
