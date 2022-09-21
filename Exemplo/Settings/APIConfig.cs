using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Exemplo.WebApp.Settings
{
    public static class APIConfig
    {

        public static void AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "BDD Specflow", Version = "v1" }));

        }

        public static void AddConfig(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "BDD Specflow"); });

        }
    }
}
