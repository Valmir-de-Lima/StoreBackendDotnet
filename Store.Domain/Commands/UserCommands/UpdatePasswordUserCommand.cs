using Store.Domain.ValueObjects;
using Store.Domain.Commands.UserCommands.Contracts;
using Store.Shared.Commands.Interfaces;

namespace Store.Domain.Commands.UserCommands;

public class UpdatePasswordUserCommand : Command, ICommand
{
    public string OldPassword { get; set; } = "";
    public string NewPassword { get; set; } = "";

    public void Validate()
    {
        var newPassword = new Password(NewPassword);
        AddNotifications(new UpdatePasswordUserContract(
            OldPassword,
            NewPassword
        ),
        newPassword);
    }
}