using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Handlers.UserHandlers;
using Store.Domain.Repositories.Interfaces;
using Store.Shared.Commands;

namespace Store.Api.Controllers.UsersController;

public class UserGetController : ControllerBase
{
    [Authorize(Roles = Configuration.MANAGER)]
    [HttpGet("v1/users")]
    public async Task<IActionResult> GetAll(
            [FromServices] IUserRepository repository,
            [FromQuery] int skip = 0,
            [FromQuery] int take = 25
        )
    {
        try
        {
            return Ok(new CommandResult(true, await repository.GetAllAsync(skip, take)));
        }
        catch
        {
            return StatusCode(500, new CommandResult(false,
                "Erro ao acessar o banco de dados"
            ));
        }
    }

    [Authorize]
    [HttpGet("v1/users/{link}")]
    public async Task<IActionResult> GetByLink(
            [FromServices] UserHandler handler,
            [FromRoute] string link
        )
    {
        try
        {
            return Ok((CommandResult)await handler.HandleAsync(link));
        }
        catch
        {
            return StatusCode(500, new CommandResult(false,
                "Erro ao acessar o banco de dados"
            ));
        }
    }
}

