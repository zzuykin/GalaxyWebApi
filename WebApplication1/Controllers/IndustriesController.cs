
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Filters;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Controllers
{
    public class IndustriesController : Controller
    {
        private readonly string IndustriesContr = "Industries";

        [HttpGet(nameof(Industries), Name = nameof(Industries))]
        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        public async Task<ActionResult> Industries()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            ViewData["EditUser"] = editUser;
            return View();
        }
    }
}
