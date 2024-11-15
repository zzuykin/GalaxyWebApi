using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Features.Filters
{
    public class LoadUserFromCookieAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var protectorProvider = context.HttpContext.RequestServices.GetService<IDataProtectionProvider>();
            var protector = protectorProvider.CreateProtector("UserCookieProtection");

            var request = context.HttpContext.Request;
            if (request.Cookies.TryGetValue("auth_cookie", out string protectedData))
            {
                try
                {
                    string jsonData = protector.Unprotect(protectedData);
                    EditUser userModel = JsonSerializer.Deserialize<EditUser>(jsonData);
                    context.HttpContext.Items["EditUser"] = userModel;
                }
                catch (Exception)
                {
                    context.HttpContext.Items["EditUser"] = new EditUser();
                }
            }
            else
            {
                context.HttpContext.Items["EditUser"] = new EditUser();
            }

            base.OnActionExecuting(context);
        }
    }
}
