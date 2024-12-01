using Microsoft.Extensions.DependencyInjection;
using Galaxy.Logic.Interfaces.Repositories;
using Galaxy.Logic.Repositories;


namespace Galaxy.Logic.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddLogicServises(this IServiceCollection services)
        {
            services.AddSingleton<IFeedbackRepository, FeedbackRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ICartRepository, CartRepository>();
        }
    }
}
