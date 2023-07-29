using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Shared.Entities;
using Store.Domain.Entities.Contracts;

namespace Store.Domain.Entities;

public class User : Entity
{
    public User()
    {

    }
    public User(string name, Email email, string passwordHash, EType type)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Link = email.Address.Replace("@", "-").Replace(".", "-");
        Type = type;

        // Design by contracts
        AddNotifications(
            new CreateUserContract(this),
            Email
        );
    }

    public string Name { get; private set; } = "";
    public Email Email { get; private set; } = new("");
    public string PasswordHash { get; private set; } = "";
    public string Link { get; private set; } = "";
    public EType Type { get; private set; }

    public void Update(string name, string passwordHash, EType type)
    {
        Name = name;
        PasswordHash = passwordHash;
        Type = type;
        // Design by contracts
        AddNotifications(
            new CreateUserContract(this)
        );
    }
}