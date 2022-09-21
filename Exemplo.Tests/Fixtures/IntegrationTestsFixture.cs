using Exemplo.Tests.Factories;
using Exemplo.WebApp;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Exemplo.Tests.Fixtures
{

    [CollectionDefinition(nameof(IntegrationWebTestsFixtureCollection))]
    public class IntegrationWebTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<TestStartup>> { }

    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<TestStartup>> { }

    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {

        public readonly ClienteAppFactory<TStartup> Factory;
        public HttpClient Client;
        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true,
                BaseAddress = new Uri("http://localhost"),
                HandleCookies = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new ClienteAppFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
