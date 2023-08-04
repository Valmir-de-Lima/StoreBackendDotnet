using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Handlers.UserHandlers;
using Store.Shared.Commands;
using Store.Api.Services;
using Store.Domain.Services;

namespace Store.Api.Controllers.UsersController;

public class UserController : ControllerBase
{
    [HttpPost("v1/users")]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserCommand command,
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

    // [Authorize]
    // [HttpPut("v1/users")]
    // public async Task<IActionResult> Update(
    //     [FromBody] UpdateUserCommand command,
    //     [FromServices] UserHandler handler
    // )
    // {
    //     try
    //     {
    //         return Ok((CommandResult)await handler.HandleAsync(command));
    //     }
    //     catch
    //     {
    //         return StatusCode(500, new CommandResult(false,
    //             "Erro ao acessar o banco de dados"
    //         ));
    //     }
    // }

    [Authorize]
    [HttpPut("v1/users")]
    public async Task<IActionResult> UpdateNameUser(
    [FromBody] UpdateNameUserCommand command,
    [FromServices] UserHandler handler,
    [FromServices] ITokenService tokenService
    )
    {
        try
        {
            tokenService.LoadClaimsPrincipal(User.Claims);
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