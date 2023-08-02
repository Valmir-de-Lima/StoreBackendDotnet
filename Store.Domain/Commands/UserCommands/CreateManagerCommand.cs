using Store.Domain.Enums;
using Store.Shared.Commands.Interfaces;


namespace Store.Domain.Commands.UserCommands;

public class CreateManagerCommand : CreateUserCommand, ICommand
{
    new public EType Type { get; private set; } = EType.Manager;
}