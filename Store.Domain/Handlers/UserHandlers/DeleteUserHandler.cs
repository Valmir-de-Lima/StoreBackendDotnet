using SecureIdentity.Password;
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

    public async Task<ICommandResult> HandleAsync(DeleteUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, Notifications);
        }

        var linkManager = command.GetUserName();
        var managerType = command.GetUserType();

        if (managerType != EType.Manager)
        {
            AddNotification("command.GetUserName", "Informação indisponível");
            return new CommandResult(false, Notifications);
        }

        var manager = await _repository.GetByLinkAsync(linkManager);

        if (manager == null)
        {
            AddNotification(command.Email, "Usuario ou senha inválidos");
            return new CommandResult(false, Notifications);
        }

        if (!PasswordHasher.Verify(manager.PasswordHash, command.Password))
        {
            AddNotification(command.Password, "Usuario ou senha inválidos");
            return new CommandResult(false, Notifications);
        }

        // Build Value Objects
        var email = new Email(command.Email);

        // Get user repository
        var user = await _repository.GetByEmailAsync(email);

        // Query user exist
        if (user == null)
        {
            AddNotification(command.Email, "Usuario não cadastrado");
            return new CommandResult(false, Notifications);
        }

        // Save database
        _repository.Delete(user);

        return new CommandResult(true, new UserCommandResult(user));
    }
}