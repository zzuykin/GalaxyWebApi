
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Filters;
using WebApplication1.Features.Interfaces.Managers;
using WebApplication1.Features.Managers;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("Contacts")]
    public class ContactsController : Controller
    {
        public const string Contact = "Contacts";

        private readonly IMessageManager _messageManager;

        public ContactsController(IMessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        [HttpGet(nameof(Contacts), Name = nameof(Contacts))]
        public async Task<ActionResult> Contacts()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            ViewData["EditUser"] = editUser;
            return View(editUser);
        }

        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        [HttpPost(nameof(SubmitMess), Name = nameof(SubmitMess))]
        public async Task<IActionResult> SubmitMess(string clientName, string clientEmail, string messageSubj, string messageText)
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            if (editUser != null) {
                EditMessage editMessage = new EditMessage
                {
                    ClientName = editUser.ClientName,
                    ClientEmail = editUser.ClientEmail,
                    MessageSubj = messageSubj,
                    MessageText = messageText,
                
                };
                var feed_id = _messageManager.Create(editMessage);
            }
            else
            {
            EditMessage editMessage = new EditMessage
                {
                    ClientName = clientName,
                    ClientEmail = clientEmail,
                    MessageSubj = messageSubj,
                    MessageText = messageText,

                };
                var feed_id = _messageManager.Create(editMessage);
            }

            TempData["MessageMess"] = "Вы отправили сообщение";

            return RedirectToAction("Contacts");
        }
    }
}
