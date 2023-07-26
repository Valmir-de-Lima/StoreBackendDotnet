using Store.Domain.Commands;
using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers;

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
            return new CommandResult(false, "Não foi possível cadastrar o usuário", Notifications);
        }

        // Controi entidade
        var user = new User(command.Name, command.Email, command.PasswordHash, command.Type);

        _repository.Create(user);

        return new CommandResult(true, "Usuário cadastrado com sucesso", user);
    }
}