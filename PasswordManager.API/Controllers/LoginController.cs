using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.API.Requests;
using PasswordManager.API.Responses;
using PasswordManager.Domain.Commands;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("/Login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<UserToken>> Post(
            [FromBody] LoginRequest request,
            [FromServices] LoginHandler handler,
            CancellationToken cancellationToken = default)
        {
            var commandResult =
                await handler.Handle(new LoginCommand(request.User, request.Password), cancellationToken);
            var token = (UserToken)commandResult.Data;
            return Ok(
                new LoginResponse(token.UserName, token.Authenticated, token.TokenValue, token.TokenExpirationDate));
        }
    }
}