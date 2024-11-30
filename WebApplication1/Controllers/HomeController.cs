
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication1.Features.Filters;
using WebApplication1.Features.Interfaces.Managers;
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


        public HomeController(IFeedbackManager feedbackManager, IUserManager userManager, IDataProtectionProvider dataProtectionProvider)
        {
            _feedbackManager = feedbackManager;
            _userManager = userManager;
            _protector = dataProtectionProvider.CreateProtector("UserCookieProtection");
        }

        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        [HttpGet,Route("")]
        public ActionResult Index()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            ViewData["EditUser"] = editUser;
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

            TempData["Message"] = "Ваш отзыв был оставлен";

            
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
                TempData["ErrorRegEmail"] = "Пользователь с таким email уже зарегистрирован";
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
            _userManager.Create(editUser);

            //Response.Cookies.Append("auth_cookie", "user_authenticated", new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddDays(1) });

            // Преобразуем модель в JSON
            string jsonData = JsonSerializer.Serialize(editUser);

            string protectedData = _protector.Protect(jsonData);

            // Сохраним зашифрованную строку в cookie
            Response.Cookies.Append("auth_cookie", protectedData, new CookieOptions
            {
                HttpOnly = true,
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
                TempData["ErrorMessage"] = "Неверный логин или пароль";
                return Redirect(returnUrl);
            }

            if (_userManager.VerifyPassword(password, user.ClientPassword))
            {
                var editUSer = _userManager.MakeEditUser(user);
                string jsonData = JsonSerializer.Serialize(editUSer);
                string protectedData = _protector.Protect(jsonData);
                Response.Cookies.Append("auth_cookie", protectedData, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.Now.AddDays(1)
                    //Expires = DateTime.Now.AddMinutes(1)
                });
                //Response.Cookies.Append("auth_cookie", "user_authenticated", new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddDays(1) });
                return Redirect(returnUrl);
            }
            else
            {
                TempData["ErrorMessage"] = "Неверный логин или пароль";
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

