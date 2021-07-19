using NUnit.Framework;
using PasswordManager.Domain.Commands;

namespace PasswordManager.Domain.Test.Commands
{
    class LoginCommandTests
    {
        [Test]
        [TestCase("", "")]
        [TestCase(null, null)]
        [Category("/Commands/LoginCommand")]
        public void ValidatingWrongCommand(string userName, string password)
        {
            var wrong = new LoginCommand(userName, password);
            wrong.Validate();
            Assert.True(wrong.IsInvalid);
            Assert.True(wrong.Notifications.Count == 2);
        }

        [Test]
        [TestCase("1", "1")]
        [TestCase("admin", "admin")]
        [TestCase("user", "#FhYXqo#YU@MEL-n_")]
        [Category("/Commands/LoginCommand")]
        public void ValidatingRightCommand(string userName, string password)
        {
            var right = new LoginCommand(userName, password);
            right.Validate();
            Assert.True(right.IsValid);
            Assert.True(right.Notifications.Count == 0);
        }
    }
}