using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Shared.Commands;

namespace Store.Domain.Commands.UserCommands;

public class UserCommandResult
{
    public UserCommandResult(User user)
    {
        Id = user.Id.ToString();
        Name = user.Name;
        Email = user.Email.Address;
        Link = user.Link;
        Type = user.Type.ToString();
    }

    public string Id { get; private set; } = "";
    public string Name { get; private set; } = "";
    public string Email { get; private set; } = new("");
    public string Link { get; private set; } = "";
    public string Type { get; private set; } = "";
}