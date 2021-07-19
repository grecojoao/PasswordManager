using FlyGon.CQRS.Commands;
using FlyGon.Notifications.Validations;

namespace PasswordManager.Domain.Commands
{
    public class ValidatePasswordCommand : Command
    {
        public string Password { get; set; }

        public ValidatePasswordCommand(string password) =>
            Password = password;

        public override void Validate() =>
            AddNotifications(new ValidationContract()
                .IsNotNullOrEmpty(Password, "Senha", "Senha deve ser fornecida"));
    }
}