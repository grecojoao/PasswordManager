using NUnit.Framework;
using PasswordManager.Domain.Commands;
using PasswordManager.Domain.Handlers;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Test.Commands
{
    class PasswordManagerHandlerTests
    {
        private PasswordManagerHandler _handler;

        [SetUp]
        public void Setup() =>
            _handler = new PasswordManagerHandler();

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [Category("/Handlers/PasswordManagerHandler")]
        public async Task ValidatingWrongCommands(string password)
        {
            var wrong = new ValidatePasswordCommand(password);
            var commandResult = await _handler.Handle(wrong, default);
            Assert.False(commandResult.Sucess);
            Assert.True(commandResult.Message == "Senha: Senha deve ser fornecida;");
        }

        [Test]
        [TestCase("12345678912345")]
        [TestCase("ABCDEFghij@#12")]
        [TestCase("123456789123456")]
        [TestCase("abcdefghij1234@")]
        [TestCase("ABCDEFGHIJ1234-")]
        [TestCase("AACDEFghij!#123")]
        [TestCase("aaBCDEFghi@#234")]
        [TestCase("11BCDEFghi@#234")]
        [TestCase("11BCDEFgh _#234")]
        [Category("/Handlers/PasswordManagerHandler")]
        public async Task ValidatingWrongPasswords(string password)
        {
            var rightButInvalid = new ValidatePasswordCommand(password);
            var commandResult = await _handler.Handle(rightButInvalid, default);
            Assert.False(commandResult.Sucess);
            Assert.True(commandResult.Message == "Senha inválida");
        }

        [Test]
        [TestCase("#FhYXqo#YU@MEL-n_")]
        [TestCase("AaBCdefgh123@12")]
        [TestCase("AaBCdefgh123!12")]
        [TestCase("AaBCdefgh123_31")]
        [TestCase("AaBCdefgh123-31")]
        [TestCase("AaBCdefgh123!31")]
        [TestCase("AaBCdefgh12 @#1")]
        [Category("/Handlers/PasswordManagerHandler")]
        public async Task ValidatingRightPasswords(string password)
        {
            var right = new ValidatePasswordCommand(password);
            var commandResult = await _handler.Handle(right, default);
            Assert.True(commandResult.Sucess);
            Assert.True(commandResult.Message == "Senha válida");
        }

        [Test]
        [Category("/Handlers/PasswordManagerHandler")]
        public async Task ValidatingGeneratedPasswords()
        {
            for (int i = 0; i < 100; i++)
            {
                var password = (string)(await _handler.Handle(new GeneratePasswordCommand(), default)).Data;
                var right = new ValidatePasswordCommand(password);
                var commandResult = await _handler.Handle(right, default);
                Assert.True(commandResult.Sucess);
                Assert.True(commandResult.Message == "Senha válida");
            }
        }
    }
}