using Microsoft.Extensions.DependencyInjection;
using PasswordValidator.Core.Interfaces;
using PasswordValidator.Core.Services;

namespace PasswordValidator.UnitTest.Fixture
{
    public static class UnitTestFixture
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public static void Setup()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPasswordService, PasswordService>();
            serviceCollection.AddScoped(typeof(IPasswordValidator), typeof(Core.Validators.PasswordValidator));

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
