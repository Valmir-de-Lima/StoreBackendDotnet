using SecureIdentity.Password;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Enums;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Services;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class UpdateUserHandler : Handler, IHandler<UpdateUserCommand>
{

    private readonly IUserRepository _repository;

    public UpdateUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICommandResult> HandleAsync(UpdateUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, Notifications);
        }

        var link = command.GetUserName();

        if (link == null)
        {
            AddNotification(link, "Identificacao do usuário não disponível");
            return new CommandResult(false, Notifications);
        }
        // Get user repository
        var user = await _repository.GetByLinkAsync(link);

        // Query user exist
        if (user == null)
        {
            AddNotification(link, "Usuário não cadastrado");
            return new CommandResult(false, Notifications);
        }

        user.Update(command.Name);

        // Save database
        _repository.Update(user);

        return new CommandResult(true, new UserCommandResult(user));
    }
}