using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Handlers.UserHandlers;
using Store.Shared.Commands;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class LoginController : ControllerBase
    {
        [Route("v1/users/login")]
        [HttpPost]
        public async Task<IActionResult> Login(
        [FromBody] LoginUserCommand command,
        [FromServices] UserHandler handler
    )
        {
            try
            {
                return Ok((CommandResult)await handler.HandleAsync(command));
            }
            catch
            {
                return StatusCode(500, new CommandResult(false,
                    "Erro ao efetuar o login."
                ));
            }
        }
    }
}