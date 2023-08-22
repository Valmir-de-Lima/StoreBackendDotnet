using Store.Domain.Commands.UserCommands.Contracts;
using Store.Shared.Commands.Interfaces;


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