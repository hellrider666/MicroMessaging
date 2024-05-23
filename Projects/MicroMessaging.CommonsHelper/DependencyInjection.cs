using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace MicroMessaging.CommonsHelper
{
    public static class DependencyInjection
    {
        public static WebApplicationBuilder AddCommons(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            return builder;
        }
    }
}

