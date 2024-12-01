
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Filters;
using WebApplication1.Features.Interfaces.Managers;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("Product")]
    public class ProductsController : Controller
    {
        public const string Product = "Product";
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

        [HttpGet(nameof(ERP), Name = nameof(ERP))]
        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        public async Task<ActionResult> ERP()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            var product = _productManager.GetProductById(1);
            ViewData["EditUser"] = editUser;
            ViewData["EditProduct"] = product;
            return View();
        }

        [HttpGet(nameof(EAM), Name = nameof(EAM))]
        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        public async Task<ActionResult> EAM()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            var product = _productManager.GetProductById(2);
            ViewData["EditUser"] = editUser;
            ViewData["EditProduct"] = product;
            return View();
        }

        [HttpGet(nameof(AMM), Name = nameof(AMM))]
        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        public async Task<ActionResult> AMM()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            var product = _productManager.GetProductById(3);
            ViewData["EditUser"] = editUser;
            ViewData["EditProduct"] = product;
            return View();
        }

        [HttpGet(nameof(MES), Name = nameof(MES))]
        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        public async Task<ActionResult> MES()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            var product = _productManager.GetProductById(4);
            ViewData["EditUser"] = editUser;
            ViewData["EditProduct"] = product;
            return View();
        }

        [HttpGet(nameof(BI), Name = nameof(BI))]
        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        public async Task<ActionResult> BI()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            var product = _productManager.GetProductById(5);
            ViewData["EditUser"] = editUser;
            ViewData["EditProduct"] = product;
            return View();
        }

        [HttpGet(nameof(ESB), Name = nameof(ESB))]
        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        public async Task<ActionResult> ESB()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            var product = _productManager.GetProductById(6);
            ViewData["EditUser"] = editUser;
            ViewData["EditProduct"] = product;
            return View();
        }
    }
}
