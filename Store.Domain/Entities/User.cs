using Flunt.Validations;
using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Shared.Entities;
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
            new Contract()
                .Requires()
                .HasMinLen(Name.Replace(" ", ""), 3, "Name.FirstName", "O nome requer no minimo 3 letras")
                .HasMaxLen(Name, 40, "Name.FirstName", "O nome deve conter no maximo 40 caracteres"),
            Email
        );
    }

    public string Name { get; private set; } = "";
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; } = "";
    public string Link { get; private set; } = "";
    public EType Type { get; private set; }
}