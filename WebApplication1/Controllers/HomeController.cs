
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication1.Features.Filters;
using WebApplication1.Features.Interfaces.Managers;
using WebApplication1.Features.Managers;
using WebApplication1.Features.ViewModels;


namespace WebApplication1.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public const string Home = "Home";
        private readonly IFeedbackManager _feedbackManager;
        private readonly IUserManager _userManager;
        private readonly IDataProtector _protector;
        private readonly ICartManager _cartManager;
        private readonly IProductManager _productManager;

        public HomeController(IFeedbackManager feedbackManager, IUserManager userManager, IDataProtectionProvider dataProtectionProvider, ICartManager cartManager, IProductManager productManager)
        {
            _feedbackManager = feedbackManager;
            _userManager = userManager;
            _protector = dataProtectionProvider.CreateProtector("UserCookieProtection");
            _cartManager = cartManager;
            _productManager = productManager;
        }

        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        [HttpGet,Route("")]
        public ActionResult Index()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            var products = _productManager.GetListProduct();
            ViewData["EditUser"] = editUser;
            ViewData["ProductList"] = products;
            return View();
        }

        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        [HttpPost(nameof(SubmitReview), Name = nameof(SubmitReview))]
        public async Task<IActionResult> SubmitReview(string review, bool publish)
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            EditFeedback feedback = new EditFeedback
            {
                ClientName = editUser.ClientName,
                ClientEmail = editUser.ClientEmail,
                feedBackText = review,
                forPublic = publish
            };
            var feed_id = _feedbackManager.Create(feedback);

            TempData["Message"] = "��� ����� ��� ��������";

            
            return RedirectToAction("Index");
        }

        [HttpPost(nameof(Register), Name = nameof(Register))]
        public async Task<IActionResult> Register(string firstname, string lastname, string emailReg, string password, string returnUrl)
        {
            returnUrl = System.Net.WebUtility.UrlDecode(returnUrl);
            if (string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                returnUrl = "Home/Index";
            }
            if (_userManager.isEmailReg(emailReg))
            {
                TempData["ErrorRegEmail"] = "������������ � ����� email ��� ���������������";
                return Redirect(returnUrl);
            }
            var hashPasword = _userManager.HashPassword(password);
            var editUser = new EditUser
            {
                ClientName = firstname,
                ClientSurname = lastname,
                ClientEmail = emailReg,
                ClientPassword = hashPasword,
            };
            var user= _userManager.Create(editUser);
            await _cartManager.AddCart(user.IsnNode);
             

            //Response.Cookies.Append("auth_cookie", "user_authenticated", new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddDays(1) });

            // ����������� ������ � JSON
            string jsonData = JsonSerializer.Serialize(user);

            string protectedData = _protector.Protect(jsonData);

            // �������� ������������� ������ � cookie
            Response.Cookies.Append("auth_cookie", protectedData, new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                Expires = DateTime.Now.AddDays(1)
            });

            return Redirect(returnUrl);
        }

        [HttpPost(nameof(Login), Name = nameof(Login))]
        public async Task<IActionResult> Login(string email, string password, string returnUrl)
        {
            var user = _userManager.GetUserByEmail(email);
            returnUrl = System.Net.WebUtility.UrlDecode(returnUrl);
            if (string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                returnUrl = "Home/Index";
            }
            if (user == null)
            {
                TempData["ErrorMessage"] = "�������� ����� ��� ������";
                return Redirect(returnUrl);
            }

            if (_userManager.VerifyPassword(password, user.ClientPassword))
            {
                var editUSer = _userManager.MakeEditUser(user);
                string jsonData = JsonSerializer.Serialize(editUSer);
                string protectedData = _protector.Protect(jsonData);
                Response.Cookies.Append("auth_cookie", protectedData, new CookieOptions
                {
                    HttpOnly = false,
                    Secure = true,
                    Expires = DateTime.Now.AddDays(1)
                    //Expires = DateTime.Now.AddMinutes(1)
                });
                //Response.Cookies.Append("auth_cookie", "user_authenticated", new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddDays(1) });
                return Redirect(returnUrl);
            }
            else
            {
                TempData["ErrorMessage"] = "�������� ����� ��� ������";
                return Redirect(returnUrl);
            }
        }

        [HttpPost(nameof(Logout), Name = nameof(Logout))]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            Response.Cookies.Delete("auth_cookie");
            returnUrl = System.Net.WebUtility.UrlDecode(returnUrl);
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

