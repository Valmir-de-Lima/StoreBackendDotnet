using Store.Domain.ValueObjects.Contracts;
using Store.Shared.Commands.Interfaces;
using Store.Domain.ValueObjects;

namespace Store.Domain.Commands.UserCommands;

public class DeleteUserCommand : Command, ICommand
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    public void Validate()
    {
        var password = new Password(Password);
        AddNotifications(new CreateEmailContract(
            new Email(Email)
        ),
        password);
    }
}