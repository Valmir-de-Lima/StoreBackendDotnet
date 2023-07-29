using Store.Domain.Commands.UserCommands;
using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class CreateUserHandler : Handler, IHandler<CreateUserCommand>
{

    private readonly IUserRepository _repository;

    public CreateUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateUserCommand command)
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
        var type = (EType)command.Type;

        // Query e-mail exist
        if (_repository.ExistsEmail(email))
        {
            AddNotification(command.Email, "Email já cadastrado");
            return new CommandResult(false, Notifications);
        }

        // Build entity
        var user = new User(command.Name, email, command.PasswordHash, type);

        // Save database
        _repository.Create(user);

        return new CommandResult(true, user);
    }
}