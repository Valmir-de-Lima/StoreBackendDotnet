using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Handlers.UserHandlers;
using Store.Shared.Commands;
using Store.Api.Controllers;
using Store.Domain.Services;

namespace Store.Api.Controllers.UsersController;

[ApiController]
[Route("")]
public partial class UserController : ControllerBase
{
    [Authorize(Roles = Configuration.MANAGER)]
    [HttpPost("v1/users")]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserCommand command,
        [FromServices] UserHandler handler
    )
    {
        try
        {
            command.SetUrlOfSite($"{Request.Scheme}://{Request.Host}");
            return Ok((CommandResult)await handler.HandleAsync(command));
        }
        catch
        {
            return StatusCode(500, new CommandResult(false,
                "Erro ao acessar o banco de dados"
            ));
        }
    }

    [Authorize]
    [HttpPut("v1/users")]
    public async Task<IActionResult> UpdateUser(
    [FromBody] UpdateUserCommand command,
    [FromServices] UserHandler handler
    )
    {
        try
        {
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


    [Authorize(Roles = Configuration.MANAGER)]
    [HttpDelete("v1/users")]
    public async Task<IActionResult> Delete(
    [FromBody] DeleteUserCommand command,
    [FromServices] UserHandler handler
    )
    {
        try
        {
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

    [Authorize]
    [HttpPut("v1/users/password")]
    public async Task<IActionResult> UpdatePasswordUser(
    [FromBody] UpdatePasswordUserCommand command,
    [FromServices] UserHandler handler
    )
    {
        try
        {
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