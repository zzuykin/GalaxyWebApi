

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Filters;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("AboutUs")]
    public class AboutUsController : Controller
    {
        public const string AboutUsContr = "AboutUs";

        public AboutUsController() { }

        [HttpGet(nameof(AboutUs), Name = nameof(AboutUs))]

        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        public async Task<ActionResult> AboutUs()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            ViewData["EditUser"] = editUser;
            return View();
        }

    }
}
