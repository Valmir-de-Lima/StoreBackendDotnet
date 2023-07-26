using Store.Domain.Commands;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers;

public class UserHandler : Handler, IHandler<CreateUserCommand>
{


    public ICommandResult Handle(CreateUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }

        return new CommandResult(true, "Usuário cadastrado com sucesso", command);
    }
}