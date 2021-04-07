using Microsoft.Extensions.DependencyInjection;
using PasswordValidator.Core.Interfaces;
using PasswordValidator.Core.Services;

namespace PasswordValidator.Infra.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPasswordService, PasswordService>();

            services.AddScoped(typeof(IPasswordValidator), typeof(Core.Validators.PasswordValidator));

            return services;
        }
    }
}
