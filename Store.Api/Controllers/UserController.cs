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
    public CommandResult Create(
        [FromBody] CreateUserCommand command,
        [FromServices] UserHandler handler
    )
    {
        try
        {
            return (CommandResult)handler.Handle(command);
        }
        catch
        {
            return new CommandResult(false,
                "Erro ao acessar o banco de dados"
            );
        }
    }

    [Route("v1/users")]
    [HttpGet]
    public CommandResult GetAll(
            [FromServices] IUserRepository repository
        )
    {
        try
        {
            return new CommandResult(true, repository.GetAll());
        }
        catch
        {
            return new CommandResult(false,
                "Erro ao acessar o banco de dados"
            );
        }
    }

    [Route("v1/users/{link}")]
    [HttpGet]
    public CommandResult GetByLink(
        [FromServices] IUserRepository repository,
        [FromRoute] string link
    )
    {
        try
        {
            return new CommandResult(true, repository.GetByLink(link));
        }
        catch
        {
            return new CommandResult(false,
                "Erro ao acessar o banco de dados"
            );
        }
    }

    [Route("v1/users")]
    [HttpPut]
    public CommandResult Update(
        [FromBody] UpdateUserCommand command,
        [FromServices] UserHandler handler
    )
    {
        try
        {
            return (CommandResult)handler.Handle(command);
        }
        catch
        {
            return new CommandResult(false,
                "Erro ao acessar o banco de dados"
            );
        }
    }

    [Route("v1/users")]
    [HttpDelete]
    public CommandResult Delete(
    [FromBody] DeleteUserCommand command,
    [FromServices] UserHandler handler
)
    {
        try
        {
            return (CommandResult)handler.Handle(command);
        }
        catch
        {
            return new CommandResult(false,
                "Erro ao acessar o banco de dados"
            );
        }
    }

}