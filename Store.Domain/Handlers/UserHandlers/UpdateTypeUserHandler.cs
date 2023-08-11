using SecureIdentity.Password;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Enums;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class UpdateTypeUserHandler : Handler, IHandler<UpdateTypeUserCommand>
{

    private readonly IUserRepository _repository;

    public UpdateTypeUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICommandResult> HandleAsync(UpdateTypeUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, Notifications);
        }

        var email = new Email(command.Email);

        // Get user repository
        var user = await _repository.GetByEmailAsync(email);

        // Query user exist
        if (user == null)
        {
            AddNotification(command.Email, "Usuário não cadastrado");
            return new CommandResult(false, Notifications);
        }

        user.UpdateType((EType)command.Type);

        // Save database
        _repository.Update(user);

        return new CommandResult(true, new UserCommandResult(user));
    }
}