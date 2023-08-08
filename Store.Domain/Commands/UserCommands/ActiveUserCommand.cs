using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Domain.Entities.Contracts;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Commands;

namespace Store.Domain.Commands.UserCommands;

public class ActiveUserCommand : Command, ICommand
{
    public ActiveUserCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }

    public void Validate()
    {
        AddNotifications(
            new ActiveUserContract(Id)
        );
    }
}