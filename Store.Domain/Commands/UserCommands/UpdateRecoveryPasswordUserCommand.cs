using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Domain.Entities.Contracts;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Commands;

namespace Store.Domain.Commands.UserCommands;

public class UpdateRecoveryPasswordUserCommand : Command, ICommand
{
    public string Id { get; set; } = "";
    public string Password { get; set; } = "";

    public string RecoveryPassword { get; set; } = "";

    public void Validate()
    {
        var password = new Password(Password);
        AddNotifications(
            new UpdateRecoveryPasswordUserContract(Id, Password, RecoveryPassword),
            password
        );
    }
}