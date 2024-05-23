using MicroMessaging.DAL.Repositories.Contracts;
using MicroMessaging.DAL.Repositories.Implemintations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MicroMessaging.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
