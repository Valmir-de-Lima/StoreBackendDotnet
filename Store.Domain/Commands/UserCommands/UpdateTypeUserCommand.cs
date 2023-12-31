using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Domain.Commands.UserCommands.Contracts;
using Store.Shared.Commands.Interfaces;

namespace Store.Domain.Commands.UserCommands;

public class UpdateTypeUserCommand : Command, ICommand
{
    public string Email { get; set; } = "";
    public int Type { get; set; }

    public void Validate()
    {
        var employeeEmail = new Email(Email);
        AddNotifications(
            new UpdateTypeUserContract((EType)Type),
            employeeEmail
        );
    }
}