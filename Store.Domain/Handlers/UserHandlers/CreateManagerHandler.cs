using SecureIdentity.Password;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class CreateManagerHandler : Handler, IHandler<CreateManagerCommand>
{

    private readonly IUserRepository _repository;

    public CreateManagerHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICommandResult> HandleAsync(CreateManagerCommand command)
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

        // Query e-mail exist
        if (await _repository.ExistsEmailAsync(email))
        {
            AddNotification(command.Email, "Email já cadastrado");
            return new CommandResult(false, Notifications);
        }

        var passwordHash = PasswordHasher.Hash(command.Password);

        // Build entity
        var user = new User(command.Name, email, passwordHash, command.Type);

        user.Update(command.Type);
        // Save database
        await _repository.CreateAsync(user);


        return new CommandResult(true, new UserCommandResult(user));
    }
}