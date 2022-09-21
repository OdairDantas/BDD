using Exemplo.WebApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exemplo.WebApp.IOC
{
    public static class IOCConfig
    {

        public static void ResolveDependencia(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddScoped<IClienteService, ClienteService>();
        }
    }
}
