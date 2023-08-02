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

        // Build Value Objects
        var managerEmail = new Email(command.ManagerEmail);

        // Get user repository
        var manager = await _repository.GetByEmailAsync(managerEmail);

        // Query manager exist
        if (manager == null)
        {
            AddNotification(command.ManagerEmail, "Gerente não cadastrado");
            return new CommandResult(false, Notifications);
        }

        var employeeEmail = new Email(command.EmployeeEmail);

        // Get user repository
        var user = await _repository.GetByEmailAsync(employeeEmail);

        // Query user exist
        if (user == null)
        {
            AddNotification(command.ManagerEmail, "Usuário não cadastrado");
            return new CommandResult(false, Notifications);
        }

        if (!PasswordHasher.Verify(manager.PasswordHash, command.ManagerPassword))
        {
            AddNotification(command.ManagerPassword, "Usuario ou senha inválidos");
            return new CommandResult(false, Notifications);
        }

        user.Update((EType)command.EmployeeType);

        // Save database
        _repository.Update(user);

        return new CommandResult(true, new UserCommandResult(user));
    }
}