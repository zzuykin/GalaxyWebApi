using Galaxy.Storage.Models;
using Microsoft.AspNetCore.Mvc;
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

        public HomeController(IFeedbackManager feedbackManager, IUserManager userManager)
        {
            _feedbackManager = feedbackManager;
            _userManager = userManager;
        }


        [HttpGet,Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost(nameof(SubmitReview), Name = nameof(SubmitReview))]
        public async Task<IActionResult> SubmitReview(string name, string email, string review, bool publish)
        {
            EditFeedback feedback = new EditFeedback
            {
                ClientName = name,
                ClientEmail = email,
                feedBackText = review,
                forPublic = publish
            };
            var feed_id = _feedbackManager.Create(feedback);

            TempData["Message"] = "Ваш отзыв был оставлен";

            
            return RedirectToAction("Index");
        }

        [HttpPost(nameof(Register), Name = nameof(Register))]
        public async Task<IActionResult> Register(string firstname, string lastname, string emailReg, string password)
        {
            var hashPasword = _userManager.HashPassword(password);
            var editUser = new EditUser
            {
                ClientName = firstname,
                ClientSurname = lastname,
                ClientEmail = emailReg,
                ClientPassword = hashPasword,
            };
            _userManager.Create(editUser);
            Response.Cookies.Append("auth_cookie", "user_authenticated", new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddDays(1) });

            return RedirectToAction("Index");
        }

        [HttpPost(nameof(Login), Name = nameof(Login))]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _userManager.GetUserByEmail(email);
            if(user == null)
            {
                TempData["ErrorMessage"] = "Неверный логин или пароль";
                return RedirectToAction("Index");
            }

            if (_userManager.VerifyPassword(password, user.ClientPassword))
            {
                Response.Cookies.Append("auth_cookie", "user_authenticated", new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddDays(1) });
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ErrorMessage"] = "Неверный email или пароль.";
                return View("Index");
            }
        }

        [HttpPost(nameof(Logout), Name = nameof(Logout))]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("auth_cookie");
            return RedirectToAction("Index");
        }
    }
}

