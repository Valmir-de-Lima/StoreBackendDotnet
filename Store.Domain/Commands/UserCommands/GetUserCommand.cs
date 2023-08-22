using Store.Domain.Commands.UserCommands.Contracts;
using Store.Shared.Commands.Interfaces;

namespace Store.Domain.Commands.UserCommands;

public class GetUserCommand : Command, ICommand
{
    public GetUserCommand(string link)
    {
        Link = link;
    }
    public string Link { get; set; } = "";

    public void Validate()
    {
        AddNotifications(new GetUserContract(Link));
    }
}