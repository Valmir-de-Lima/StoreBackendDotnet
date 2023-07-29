using Store.Domain.Commands.UserCommands;
using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class DeleteUserHandler : Handler, IHandler<DeleteUserCommand>
{

    private readonly IUserRepository _repository;

    public DeleteUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(DeleteUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, Notifications);
        }

        // Build Value Objects
        var email = new Email(command.Email);

        // Get user repository
        var user = _repository.GetByEmail(email);

        // Query user exist
        if (user == null)
        {
            AddNotification(command.Email, "Usuario não cadastrado");
            return new CommandResult(false, Notifications);
        }

        // Save database
        _repository.Delete(user);

        return new CommandResult(true, user);
    }
}