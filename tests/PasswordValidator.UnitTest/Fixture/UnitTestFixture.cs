using Microsoft.Extensions.DependencyInjection;
using PasswordValidator.Core.Interfaces;
using PasswordValidator.Core.Services;

namespace PasswordValidator.UnitTest
{
    public class UnitTestFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public UnitTestFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IPasswordService, PasswordService>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
