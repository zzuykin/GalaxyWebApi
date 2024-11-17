
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Features.Interfaces.Managers;

namespace WebApplication1.Features.Managers
{
    public class RouterManager : IRouterManager
    {
        private readonly DataContext _dataContext;

        public RouterManager(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Router> GetRoutes(string query)
        {
            var result = _dataContext.Routers.AsNoTracking().ToList();
            return FilterRouter(result, query);
        }

        public List<Router> FilterRouter(List<Router> routers, string query)
        {
            var filerRouters = routers.Where(x => x.PageName != null &&
            (x.PageName.StartsWith(query, StringComparison.OrdinalIgnoreCase) || x.PageName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();

            return filerRouters;
        }
    }
}
