using Galaxy.Logic.Extentions;
using WebApplication1.Features.Filters;
using WebApplication1.Features.Interfaces.Managers;
using WebApplication1.Features.Managers;


namespace WebApplication1.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddLogicServises();
            services.AddScoped<LoadUserFromCookieAttribute>();
            services.AddTransient<IFeedbackManager, FeedbackManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IMessageManager, MessageManager>();
            services.AddTransient<IProductManager, ProductManager>();
        }
    }
}
