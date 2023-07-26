using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Domain.Entities;
using Store.Domain.Entities.Contracts;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Commands;

namespace Store.Domain.Commands;

public class CreateUserCommand : Command, ICommand
{
    public string Name { get; set; } = "";
    public Email Email { get; set; } = new("");
    public string PasswordHash { get; set; } = "";
    public string Link { get; set; } = "";
    public EType Type { get; set; }

    public void Validate()
    {
        AddNotifications(new CreateUserContract(
            new User(Name, Email, PasswordHash, Type)
        ));
    }
}