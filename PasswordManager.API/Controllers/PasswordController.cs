using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.API.Requests;
using PasswordManager.API.Responses;
using PasswordManager.Domain.Commands;
using PasswordManager.Domain.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        [HttpPost]
        [Route("/Password/Validate")]
        [Authorize]
        [ProducesResponseType(typeof(PasswordValidateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<bool>> Validate(
            [FromBody] PasswordValidateRequest request,
            [FromServices] PasswordManagerHandler handler,
            CancellationToken cancellationToken = default)
        {
            var commandResult = await handler.Handle(new ValidatePasswordCommand(request.Password), cancellationToken);
            return Ok(new PasswordValidateResponse(commandResult.Sucess));
        }

        [HttpGet]
        [Route("/Password/Generate")]
        [Authorize]
        [ProducesResponseType(typeof(PasswordGenerateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> Generate(
            [FromServices] PasswordManagerHandler handler,
            CancellationToken cancellationToken = default)
        {
            var commandResult = await handler.Handle(new GeneratePasswordCommand(), cancellationToken);
            return Ok(new PasswordGenerateResponse((string)commandResult.Data));
        }
    }
}