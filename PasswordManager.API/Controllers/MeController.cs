using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PasswordManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeController : ControllerBase
    {
        [HttpGet("/Me/ShowMeTheCode")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public ActionResult<string> Get() =>
            Ok("https://github.com/grecojoao/PasswordManager");
    }
}