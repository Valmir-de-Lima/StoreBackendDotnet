using Store.Domain.Entities.Contracts;
using Store.Shared.Commands.Interfaces;

namespace Store.Domain.Commands.UserCommands;

public class ActiveUserCommand : Command, ICommand
{
    public ActiveUserCommand(string id)
    {
        Id = id;
    }
    public string Id { get; set; } = "";

    public void Validate()
    {
        AddNotifications(
            new ActiveUserContract(Id)
        );
    }
}