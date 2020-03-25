using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace App.Application.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "App", Version = "v1" });
            });
        }
    }
}