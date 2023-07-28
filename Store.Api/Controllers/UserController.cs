using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands;
using Store.Domain.Entities;
using Store.Domain.Handlers;
using Store.Domain.Repositories.Interfaces;
using Store.Shared.Commands;

namespace Store.Api.Controllers;

public class UserController : ControllerBase
{
    [Route("v1/users")]
    [HttpPost]
    public CommandResult Create(
        [FromBody] CreateUserCommand command,
        [FromServices] CreateUserHandler handler
    )
    {
        return (CommandResult)handler.Handle(command);
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
        catch (Exception ex)
        {
            return new CommandResult(false,
                "Erro ao acessar o banco de dados: " + ex.ToString()
            );
        }
    }
}