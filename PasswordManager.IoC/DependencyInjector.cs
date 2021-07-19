using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Domain.IoC;
using PasswordManager.Infra.IoC;
using System.Threading.Tasks;

namespace PasswordManager.IoC
{
    public static class DependencyInjector
    {
        public static Task InjectDependencies(IServiceCollection services)
        {
            InfraInjector.Inject(services).Wait();
            DomainInjector.Inject(services).Wait();
            return Task.CompletedTask;
        }
    }
}