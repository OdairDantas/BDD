using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Exemplo.Tests.Factories
{
    public class ClienteAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<TStartup>();
            builder.UseEnvironment("Testing");
        }
    }
}
