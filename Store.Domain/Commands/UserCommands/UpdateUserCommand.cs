using Store.Domain.Commands.UserCommands.Contracts;
using Store.Shared.Commands.Interfaces;

namespace Store.Domain.Commands.UserCommands;

public class UpdateUserCommand : Command, ICommand
{
    public string Name { get; set; } = "";

    public void Validate()
    {
        AddNotifications(
            new UpdateNameUserContract(Name)
        );
    }
}