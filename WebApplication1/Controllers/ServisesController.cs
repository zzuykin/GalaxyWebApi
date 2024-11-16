
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Filters;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Controllers
{
    public class ServisesController : Controller
    {
        private readonly string ServisesContr = "Servises";

        [HttpGet(nameof(Servises), Name = nameof(Servises))]
        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        public async Task<ActionResult> Servises()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            ViewData["EditUser"] = editUser;
            return View();
        }
    }
}
