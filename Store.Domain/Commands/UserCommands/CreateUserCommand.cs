using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Domain.Entities.User;
using Store.Domain.Entities.User.Contracts;
using Store.Shared.Commands.Interfaces;

namespace Store.Domain.Commands.UserCommands;

public class CreateUserCommand : Command, ICommand
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    public void Validate()
    {
        var email = new Email(Email);
        var password = new Password(Password);
        AddNotifications(new CreateUserContract(
            new User(Name, email, password, EType.Customer)
        ),
        email,
        password);
    }
}