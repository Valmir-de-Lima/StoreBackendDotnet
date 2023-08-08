using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Handlers.UserHandlers;
using Store.Shared.Commands;

namespace Store.Api.Controllers.UsersController;

[ApiController]
[Route("")]
public class UserLoginController : ControllerBase
{
    [HttpPost("v1/users/login")]
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

    [HttpPost("v1/users/login/refresh")]
    public async Task<IActionResult> Refresh(
    [FromBody] RefreshLoginUserCommand command,
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

    [HttpPost("v1/users/login/register")]
    public async Task<IActionResult> Register(
    [FromBody] RegisterUserCommand command,
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

    [HttpGet("v1/users/login/active/{id}")]
    public async Task<IActionResult> Active(
        [FromRoute] string id,
        [FromServices] UserHandler handler
    )
    {
        try
        {
            var command = new ActiveUserCommand(new Guid(id));
            command.SetUser(User);
            return Ok((CommandResult)await handler.HandleAsync(command));
        }
        catch
        {
            return StatusCode(500, new CommandResult(false,
                "Erro ao acessar o banco de dados"
            ));
        }
    }

}
