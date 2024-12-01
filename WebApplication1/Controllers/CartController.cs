
using Galaxy.Storage.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Filters;
using WebApplication1.Features.Interfaces.Managers;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly ICartManager _cartManager;
        private readonly IProductManager _productManager;
        public const string CartContr = "Cart";

        public CartController(ICartManager cartManager, IProductManager productManager)
        {
            _cartManager = cartManager;
            _productManager = productManager;
        }

        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        [HttpPost(nameof(AddToCart))]
        public async Task<IActionResult> AddToCart([FromBody] int productId)
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            await _cartManager.AddToCart(editUser.IsnNode, productId);
            var count = await _cartManager.GetCartItemCount(editUser.IsnNode);
            return Json(new { cartItemCount = count });
        }

        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        [HttpGet(nameof(GetCartItemCount))]
        public async Task<IActionResult> GetCartItemCount()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            var count = await _cartManager.GetCartItemCount(editUser.IsnNode);
            return Json(new { cartItemCount = count });
        }
    }
}
