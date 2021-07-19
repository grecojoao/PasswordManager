using FlyGon.CQRS.Commands;
using FlyGon.Notifications.Validations;

namespace PasswordManager.Domain.Commands
{
    public class LoginCommand : Command
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public override void Validate() =>
            AddNotifications(new ValidationContract()
                .IsNotNullOrEmpty(UserName, "Usuário", "Usuário deve ser fornecido")
                .IsNotNullOrEmpty(Password, "Senha", "Senha deve ser fornecida"));
    }
}