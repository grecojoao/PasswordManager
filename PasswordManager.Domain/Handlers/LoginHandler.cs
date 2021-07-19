using FlyGon.CQRS.Commands;
using FlyGon.CQRS.Handlers.Contracts;
using PasswordManager.Domain.Commands;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Repositories;
using PasswordManager.Domain.Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Handlers
{
    public class LoginHandler : ICommandHandler<LoginCommand, CommandResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<CommandResult> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            command.Validate();
            if (command.IsInvalid)
                return
                    new CommandResult(false, command.NotificationsMessage(),
                        new UserToken(command.NotificationsMessage(), authenticated: false));

            var user = await _userRepository.GetAsync(command.UserName, command.Password, cancellationToken);
            if (user == null)
                return new CommandResult(
                        false, "Usuário ou Senha inválido(s)", new UserToken(command.UserName, authenticated: false));

            var token = await _tokenService.GenerateAsync(user, default);
            return new CommandResult(true, "Autenticado", token);
        }
    }
}