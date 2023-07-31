using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Domain.Entities;
using Store.Domain.Entities.Contracts;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Commands;

namespace Store.Domain.Commands.UserCommands;

public class UpdateUserCommand : Command, ICommand
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";

    public void Validate()
    {
        var email = new Email(Email);
        AddNotifications(new CreateUserContract(
            new User(Name, email, PasswordHash, EType.Customer)
        ), email);
    }
}