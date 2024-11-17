

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Interfaces.Managers;


namespace WebApplication1.Controllers
{
    [Route("Search")]
    public class SerchController : Controller
    {
        public const string SearchContr = "Search";

        private readonly IRouterManager _routerManager;

        public SerchController(IRouterManager routerManager)
        {
            _routerManager = routerManager;
        }

        [HttpGet(nameof(GetResults), Name = nameof(GetResults))]
        public IActionResult GetResults(string query)
        {
            var result = _routerManager.GetRoutes(query);
            return Json(result);
        }
    }
}
