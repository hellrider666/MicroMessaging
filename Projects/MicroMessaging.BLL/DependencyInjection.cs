using AutoMapper;
using FluentValidation;
using MediatR;
using MicroMessaging.BLL.Behaviors;
using MicroMessaging.BLL.Interfaces.Managers;
using MicroMessaging.BLL.Managers;
using MicroMessaging.BLL.Mapping;
using MicroMessaging.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MicroMessaging.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBihavior<,>));

            services.InjectRepositories();
            services.AddDataAccessLayer(configuration);

            var mappingConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            });

            services.AddSingleton(mappingConfiguration.CreateMapper());

            return services;
        }

        private static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRequestManager, RequestManager>();

            return services;
        }
    }
}
