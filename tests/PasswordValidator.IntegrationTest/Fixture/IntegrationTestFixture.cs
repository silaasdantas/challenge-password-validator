using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;

namespace PasswordValidator.IntegrationTest.Fixture
{
    public class IntegrationTestFixture<TStartup> where TStartup : class
    {
        public PasswordValidatorFactory<TStartup> Factory;
        public HttpClient Client;

        public void Setup()
        {
            var clientOpt = new WebApplicationFactoryClientOptions()
            {
                HandleCookies = false,
                BaseAddress = new Uri("http://localhost:53331"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 10
            };

            Factory = new PasswordValidatorFactory<TStartup>();
            Client = Factory.CreateClient(clientOpt);
        }
    }
}
