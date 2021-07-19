using NUnit.Framework;
using PasswordManager.Domain.Commands;

namespace PasswordManager.Domain.Test.Commands
{
    class ValidatePasswordCommandTests
    {
        [Test]
        [TestCase("")]
        [TestCase(null)]
        [Category("/Commands/ValidatePasswordCommand")]
        public void ValidatingWrongCommand(string password)
        {
            var wrong = new ValidatePasswordCommand(password);
            wrong.Validate();
            Assert.True(wrong.IsInvalid);
            Assert.True(wrong.Notifications.Count == 1);
        }

        [Test]
        [TestCase("1")]
        [TestCase("admin")]
        [TestCase("#FhYXqo#YU@MEL-n_")]
        [Category("/Commands/ValidatePasswordCommand")]
        public void ValidatingRightCommand(string password)
        {
            var right = new ValidatePasswordCommand(password);
            right.Validate();
            Assert.True(right.IsValid);
            Assert.True(right.Notifications.Count == 0);
        }
    }
}