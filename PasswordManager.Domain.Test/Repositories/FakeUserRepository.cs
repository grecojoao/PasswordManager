using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Test.Repositories
{
    internal class FakeUserRepository : IUserRepository
    {
        public Task<User> GetAsync(string userName, string password, CancellationToken cancellationToken = default)
        {
            if (userName == "User" && password == "123!@#")
                return Task.FromResult(new User("User", "123!@#"));
            return Task.FromResult((User)null);
        }
    }
}