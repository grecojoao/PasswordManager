using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Repositories;
using PasswordManager.Infra.Context;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) =>
            _context = context;

        public async Task<User> GetAsync(string userName, string password, CancellationToken cancellationToken) =>
            await _context.Users.FirstOrDefaultAsync(
                x => x.UserName.ToLower() == userName.ToLower() && x.Password == password, cancellationToken);
    }
}