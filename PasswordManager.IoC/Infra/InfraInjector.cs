using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Domain.Repositories;
using PasswordManager.Infra.Context;
using PasswordManager.Infra.Repositories;
using System.Threading.Tasks;

namespace PasswordManager.Infra.IoC
{
    internal static class InfraInjector
    {
        public static Task Inject(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("database"));
            services.AddScoped<IUserRepository, UserRepository>();
            return Task.CompletedTask;
        }
    }
}