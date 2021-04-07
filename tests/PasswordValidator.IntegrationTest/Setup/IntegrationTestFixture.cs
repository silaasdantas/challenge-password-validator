using PasswordValidator.Api;
using System;
using System.Net.Http;
using Xunit;

namespace PasswordValidator.IntegrationTest
{

    public class IntegrationTestFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly PasswordValidatorFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestFixture()
        {
            var clientOpt = new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions()
            {
                HandleCookies = false,
                BaseAddress = new Uri("http://localhost:53331"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 10
            };

            Factory = new PasswordValidatorFactory<TStartup>();
            Client = Factory.CreateClient(clientOpt);
        }

        ~IntegrationTestFixture() => Dispose();

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }

    [CollectionDefinition(nameof(IntegrationTestFixtureCollection))]
    public class IntegrationTestFixtureCollection : ICollectionFixture<IntegrationTestFixture<StartupIntegrationTest>> { }
}
