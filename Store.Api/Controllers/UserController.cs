using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Handlers.UserHandlers;
using Store.Domain.Repositories.Interfaces;
using Store.Shared.Commands;

namespace Store.Api.Controllers;

public class UserController : ControllerBase
{
    [Route("v1/users")]
    [HttpPost]
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

    [Route("v1/users")]
    [HttpGet]
    public async Task<IActionResult> GetAll(
            [FromServices] IUserRepository repository
        )
    {
        try
        {
            return Ok(new CommandResult(true, await repository.GetAllAsync()));
        }
        catch
        {
            return StatusCode(500, new CommandResult(false,
                "Erro ao acessar o banco de dados"
            ));
        }
    }

    [Route("v1/users/{link}")]
    [HttpGet]
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

    [Route("v1/users")]
    [HttpPut]
    public async Task<IActionResult> Update(
        [FromBody] UpdateUserCommand command,
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

    [Route("v1/users")]
    [HttpDelete]
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