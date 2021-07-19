using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using PasswordManager.Domain.Commands;
using PasswordManager.Domain.Handlers;
using PasswordManager.Domain.Services;
using PasswordManager.Domain.Test.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Test.Commands
{
    class LoginHandlerTests
    {
        private LoginHandler _handler;

        [SetUp]
        public void Setup()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                {"Secret", "ae331d613ed06187a2863c7377eddf766a0d6505e7f4667351b882444a6c9269"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            _handler = new LoginHandler(new FakeUserRepository(), new TokenService(configuration));
        }

        [Test]
        [TestCase("", "")]
        [TestCase(null, null)]
        [Category("/Handlers/LoginHandler")]
        public async Task ValidatingWrongCommands(string userName, string password)
        {
            var wrong = new LoginCommand(userName, password);
            var commandResult = await _handler.Handle(wrong, default);
            Assert.False(commandResult.Sucess);
            Assert.True(
                commandResult.Message == "Usuário: Usuário deve ser fornecido; Senha: Senha deve ser fornecida;");
        }

        [Test]
        [TestCase("wrong", "wrong")]
        [TestCase("User", "wrong")]
        [TestCase("wrong", "123!@#")]
        [Category("/Handlers/LoginHandler")]
        public async Task ValidatingWrongUsernameOrPassword(string userName, string password)
        {
            var wrong = new LoginCommand(userName, password);
            var commandResult = await _handler.Handle(wrong, default);
            Assert.False(commandResult.Sucess);
            Assert.True(commandResult.Message == "Usuário ou Senha inválido(s)");
        }

        [Test]
        [TestCase("User", "123!@#")]
        [Category("/Handlers/LoginHandler")]
        public async Task ValidatingRightUsernameAndPassword(string userName, string password)
        {
            var right = new LoginCommand(userName, password);
            var commandResult = await _handler.Handle(right, default);
            Assert.True(commandResult.Sucess);
            Assert.True(commandResult.Message == "Autenticado");
        }
    }
}