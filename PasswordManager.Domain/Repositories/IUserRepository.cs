using PasswordManager.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string userName, string password, CancellationToken cancellationToken);
    }
}