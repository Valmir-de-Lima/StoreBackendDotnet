using Store.Domain.Enums;
using Store.Shared.Commands.Interfaces;


namespace Store.Domain.Commands.UserCommands;

public class CreateManagerCommand : CreateUserCommand, ICommand
{
    public EType Type { get; private set; } = EType.Manager;
    public bool Active { get; private set; } = true;
}