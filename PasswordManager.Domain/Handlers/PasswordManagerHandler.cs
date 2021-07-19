using FlyGon.CQRS.Commands;
using FlyGon.CQRS.Handlers.Contracts;
using PasswordManager.Domain.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Handlers
{
    public class PasswordManagerHandler :
        ICommandHandler<ValidatePasswordCommand, CommandResult>,
        IGenericHandler<GeneratePasswordCommand, CommandResult>
    {
        public Task<CommandResult> Handle(ValidatePasswordCommand command, CancellationToken cancellationToken)
        {
            command.Validate();
            if (command.IsInvalid)
                return Task.FromResult(new CommandResult(false, command.NotificationsMessage()));

            return Task.FromResult(
                PasswordManager.ValidatePassword(command.Password) ?
                new CommandResult(true, "Senha válida") :
                new CommandResult(false, "Senha inválida"));
        }

        public Task<CommandResult> Handle(GeneratePasswordCommand command, CancellationToken cancellationToken) =>
            Task.FromResult(new CommandResult(true, "Senha gerada", PasswordManager.GeneratePassword()));
    }
}