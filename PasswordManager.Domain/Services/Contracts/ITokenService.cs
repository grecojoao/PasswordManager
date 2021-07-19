using PasswordManager.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services.Contracts
{
    public interface ITokenService
    {
        Task<UserToken> GenerateAsync(User user, CancellationToken cancellationToken);
    }
}