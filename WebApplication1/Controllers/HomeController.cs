using Galaxy.Storage.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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


        [HttpGet,Route("")]
        public ActionResult Index()
        {
            var editUser = GetUserData();
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

            TempData["Message"] = "��� ����� ��� ��������";

            
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

            //Response.Cookies.Append("auth_cookie", "user_authenticated", new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddDays(1) });

            // ����������� ������ � JSON
            string jsonData = JsonSerializer.Serialize(editUser);

            // ��������� JSON ������
            string protectedData = _protector.Protect(jsonData);

            // �������� ������������� ������ � cookie
            Response.Cookies.Append("auth_cookie", protectedData, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.Now.AddDays(1)
            });

            return RedirectToAction("Index");
        }

        [HttpPost(nameof(Login), Name = nameof(Login))]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _userManager.GetUserByEmail(email);
            if(user == null)
            {
                TempData["ErrorMessage"] = "�������� ����� ��� ������";
                return RedirectToAction("Index");
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
                });
                //Response.Cookies.Append("auth_cookie", "user_authenticated", new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddDays(1) });
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ErrorMessage"] = "�������� email ��� ������.";
                return View("Index");
            }
        }

        [HttpPost(nameof(Logout), Name = nameof(Logout))]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("auth_cookie");
            return RedirectToAction("Index");
        }

        public EditUser GetUserData()
        {
            if (Request.Cookies.TryGetValue("auth_cookie", out string protectedData))
            {
                try
                {
                    string jsonData = _protector.Unprotect(protectedData);
                    EditUser userModel = JsonSerializer.Deserialize<EditUser>(jsonData);
                    
                }
                catch (Exception ex)
                {
                    return new EditUser();
                }
            }
            return new EditUser();
        }
    }
}

