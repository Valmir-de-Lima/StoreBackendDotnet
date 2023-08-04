using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Domain.Entities;
using Store.Domain.Entities.Contracts;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Commands;

namespace Store.Domain.Commands.UserCommands;

public class UpdatePasswordUserCommand : Command, ICommand
{
    public string OldPassword { get; set; } = "";
    public string NewPassword { get; set; } = "";

    public void Validate()
    {
        AddNotifications(new UpdatePasswordUserContract(
            OldPassword,
            NewPassword
        ));
    }
}