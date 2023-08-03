using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Handlers.UserHandlers;
using Store.Shared.Commands;

namespace Store.Api.Controllers.UsersController;

public class UserManagerController : ControllerBase
{
    [Authorize(Roles = Configuration.MANAGER)]
    [HttpPut("v1/users/manager/update-type-user")]
    public async Task<IActionResult> UpdateTypeUser(
        [FromBody] UpdateTypeUserCommand command,
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
                "Erro ao acessar o banco de dados"
            ));
        }
    }

    [HttpPost("v1/users/manager")]
    public async Task<IActionResult> CreateManager(
    [FromServices] IConfiguration config,
    [FromServices] UserHandler handler
    )
    {
        try
        {
            return Ok((CommandResult)await handler.HandleAsync(Configuration.CreateManager(config)));
        }
        catch
        {
            return StatusCode(500, new CommandResult(false,
                "Erro ao acessar o banco de dados"
            ));
        }
    }
}