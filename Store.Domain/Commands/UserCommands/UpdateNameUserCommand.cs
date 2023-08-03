using Store.Domain.Entities.Contracts;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Commands;

namespace Store.Domain.Commands.UserCommands;

public class UpdateNameUserCommand : Command, ICommand
{
    public string Token { get; set; } = "";
    public string Name { get; set; } = "";

    public void Validate()
    {
        AddNotifications(
            new UpdateNameUserContract(Token, Name)
        );
    }
}