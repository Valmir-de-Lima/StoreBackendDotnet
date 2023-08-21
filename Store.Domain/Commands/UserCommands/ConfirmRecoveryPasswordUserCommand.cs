using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Domain.Entities.Contracts;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Commands;

namespace Store.Domain.Commands.UserCommands;

public class ConfirmRecoveryPasswordUserCommand : Command, ICommand
{
    public ConfirmRecoveryPasswordUserCommand(string id)
    {
        Id = id;
    }
    public string Id { get; set; } = "";

    public void Validate()
    {
        AddNotifications(
            new ConfirmRecoveryPasswordUserContract(Id)
        );
    }
}