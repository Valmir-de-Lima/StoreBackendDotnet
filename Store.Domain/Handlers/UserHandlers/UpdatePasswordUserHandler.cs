using SecureIdentity.Password;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;
using Store.Domain.Services;

namespace Store.Domain.Handlers.UserHandlers;

public class UpdatePasswordUserHandler : Handler, IHandler<UpdatePasswordUserCommand>
{

    private readonly IUserRepository _repository;

    public UpdatePasswordUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICommandResult> HandleAsync(UpdatePasswordUserCommand command)
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

        if (!PasswordHasher.Verify(user.PasswordHash, command.OldPassword))
        {
            AddNotification(command.OldPassword, "Usuario ou senha inválidos");
            return new CommandResult(false, Notifications);
        }

        var passwordHash = PasswordHasher.Hash(command.NewPassword);

        user.UpdatePassword(passwordHash);

        // Save database
        _repository.Update(user);

        return new CommandResult(true, new UserCommandResult(user));
    }
}