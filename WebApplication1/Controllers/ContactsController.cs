﻿
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Filters;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("Contacts")]
    public class ContactsController : Controller
    {
        public const string Contact = "Contacts";

        public ContactsController()
        {
        }

        [ServiceFilter(typeof(LoadUserFromCookieAttribute))]
        [HttpGet(nameof(Contacts), Name = nameof(Contacts))]
        public async Task<ActionResult> Contacts()
        {
            var editUser = HttpContext.Items["EditUser"] as EditUser;
            ViewData["EditUser"] = editUser;
            return View(editUser);
        }
    }
}