using Galaxy.Logic.Extentions;
using WebApplication1.Features.Interfaces.Managers;
using WebApplication1.Features.Managers;


namespace WebApplication1.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddLogicServises();
            services.AddTransient<IFeedbackManager, FeedbackManager>();
            services.AddTransient<IUserManager, UserManager>();
        }
    }
}
