using Store.Domain.Commands.UserCommands;
using Store.Domain.Entities.User;
using Store.Domain.Repositories.Interfaces;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;

namespace Store.Domain.Handlers.UserHandlers;

public class ActiveUserHandler : Handler
{

    private readonly IUserRepository _repository;

    public ActiveUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICommandResult> HandleAsync(ActiveUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, Notifications);
        }

        // Get user repository
        var user = await _repository.GetByIdAsync(new Guid(command.Id));

        // Query user exist
        if (user is null)
        {
            AddNotification(command.Id.ToString(), "Usuario não cadastrado");
            return new CommandResult(false, Notifications);
        }

        if (user.Active)
        {
            AddNotification(user.Active.ToString(), "Conta de usuario já ativa");
            return new CommandResult(false, Notifications);
        }

        user.UpdateActive(true);

        // Save database
        _repository.Update(user);

        return new CommandResult(true, new UserCommandResult(user));
    }
}