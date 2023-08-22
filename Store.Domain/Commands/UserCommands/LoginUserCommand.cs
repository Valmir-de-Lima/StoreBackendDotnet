using Store.Domain.ValueObjects;
using Store.Shared.Commands.Interfaces;

namespace Store.Domain.Commands.UserCommands;

public class LoginUserCommand : Command, ICommand
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    public void Validate()
    {
        var email = new Email(Email);
        var password = new Password(Password);
        AddNotifications(email, password);
    }
}