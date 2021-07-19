using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Domain.Handlers;
using PasswordManager.Domain.Services;
using PasswordManager.Domain.Services.Contracts;
using System.Threading.Tasks;

namespace PasswordManager.Domain.IoC
{
    internal static class DomainInjector
    {
        public static Task Inject(IServiceCollection services)
        {
            services.AddScoped<LoginHandler>();
            services.AddScoped<PasswordManagerHandler>();
            services.AddScoped<ITokenService, TokenService>();
            return Task.CompletedTask;
        }
    }
}