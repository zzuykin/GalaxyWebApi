
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Filters;
using WebApplication1.Features.Interfaces.Managers;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("Product")]
    public class ProductsController : Controller
    {
        public const string Product = "AboutUs";
        public readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet(nameof(Products), Name = nameof(Products))]
        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        public async Task<ActionResult> Products()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            var products = _productManager.GetListProduct();
            ViewData["EditUser"] = editUser;
            return View(products);
        }


    }
}
