using Store.Domain.Commands.UserCommands;
using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Services;
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

    public async Task<ICommandResult> HandleAsync(GetUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, Notifications);
        }

        var linkToken = command.GetUserName();
        var manager = command.GetUserType();

        if ((linkToken != command.Link) && (manager != EType.Manager))
        {
            AddNotification(command.Link, "Informação indisponível");
            return new CommandResult(false, Notifications);
        }

        // Get user repository
        var user = await _repository.GetByLinkAsync(command.Link);

        // Query user exist
        if (user == null)
        {
            AddNotification(command.Link, "Usuario não cadastrado");
            return new CommandResult(false, Notifications);
        }

        return new CommandResult(true, new UserCommandResult(user));
    }
}