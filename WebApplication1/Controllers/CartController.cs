
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

        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        [HttpGet(nameof(GetCartItems), Name =nameof(GetCartItems))]
        public async Task<IActionResult> GetCartItems()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            var cartItems = await _cartManager.GetCartItemsAsync(editUser.IsnNode);
            if (cartItems == null || !cartItems.Any())
            {
                return Ok(new { Items = new List<object>(), IsEmpty = true });
            }


            var response = new
            {
                Items = cartItems.Select(item => new
                {
                    ProductName = item.Product.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product.Price,
                    TotalPrice = item.Quantity * item.Product.Price,
                    productId = item.ProductId
                }).ToList(),
                IsEmpty = !cartItems.Any()
            };
            return Ok(response);
        }

        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        [HttpPost(nameof(RemoveCartItem), Name =nameof(RemoveCartItem))]
        public async Task<IActionResult> RemoveCartItem([FromBody] int productId)
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            try
            {
                await _cartManager.RemoveFromCart(editUser.IsnNode, productId);
                return Ok(); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
