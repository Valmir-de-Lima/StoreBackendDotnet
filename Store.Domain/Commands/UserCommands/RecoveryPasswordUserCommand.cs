using Store.Domain.Entities.Contracts;
using Store.Shared.Commands.Interfaces;
using Store.Domain.ValueObjects;

namespace Store.Domain.Commands.UserCommands;

public class RecoveryPasswordUserCommand : Command, ICommand
{
    public string Email { get; set; } = "";

    public void Validate()
    {
        var email = new Email(Email);
        AddNotifications(email);
    }
}