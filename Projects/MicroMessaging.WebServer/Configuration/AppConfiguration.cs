using MicroMessaging.BLL;
using MicroMessaging.CommonsHelper;
using MicroMessaging.WebServer.ApiComponents.Extensions;
using MicroMessaging.WebServer.ApiComponents.Filters;
using MicroMessaging.WebServer.Hubs;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace MicroMessaging.WebServer.Configuration
{
    public static class AppConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddControllers(options => options.Filters.Add<LogActionFilterAttribute>())
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                        options.JsonSerializerOptions.WriteIndented = true;
                        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.ConfigureModelBindingExceptionHandling();
            services.AddSignalR()
                .AddJsonProtocol(options => {
                    options.PayloadSerializerOptions.PropertyNamingPolicy = null;
                }); ;

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                               .AllowAnyMethod()
                               .SetIsOriginAllowed((host) => true)
                               .AllowCredentials();
                    }));

            services.AddBusinessLogicLayer(builder.Configuration);

            return services;
        }

        public static WebApplication AddWebApplicationComponents(this WebApplication app)
        {
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.AddEndpointsConfigurations();

            app.AddApplicationHubs();

            app.UseErrorHandler();

            return app;
        }
        public static WebApplicationBuilder AddApplicationBuilders(this WebApplicationBuilder builder)
        {
            builder.AddCommons();
            return builder;
        }

        private static WebApplication AddEndpointsConfigurations(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            return app;
        }

        private static WebApplication AddApplicationHubs(this WebApplication app)
        {
            app.MapHub<MessageHub>("/chat");

            return app;
        }
    }
}
