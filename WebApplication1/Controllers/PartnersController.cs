

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Filters;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Controllers
{
    public class PartnersController : Controller
    {
        private readonly string PartnersContr = "Partners";

        [HttpGet(nameof(Partners), Name = nameof(Partners))]
        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        public async Task<ActionResult> Partners()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            ViewData["EditUser"] = editUser;
            return View();
        }
    }
}
