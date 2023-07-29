using Store.Domain.Commands.UserCommands;
using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class GetUserHandler : Handler
{

    private readonly IUserRepository _repository;

    public GetUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICommandResult> HandleAsync(string command)
    {
        // Get user repository
        var user = await _repository.GetByLinkAsync(command);

        // Query user exist
        if (user == null)
        {
            AddNotification(command, "Usuario não cadastrado");
            return new CommandResult(false, Notifications);
        }
        return new CommandResult(true, new UserCommandResult(user));
    }
}