using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Shared.Entities;
using Store.Domain.Entities.Contracts;

namespace Store.Domain.Entities;

public class User : Entity
{
    public User(string name, Email email, string passwordHash, EType type)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Link = email.Address.Replace("@", "-").Replace(".", "-");
        Type = type;

        AddNotifications(
            new CreateUserContract(this),
            Email
        );
    }

    public string Name { get; private set; } = "";
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; } = "";
    public string Link { get; private set; } = "";
    public EType Type { get; private set; }
}