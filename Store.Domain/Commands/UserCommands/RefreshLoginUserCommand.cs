using Store.Domain.Entities.User;
using Store.Domain.Entities.User.Contracts;
using Store.Shared.Commands.Interfaces;

namespace Store.Domain.Commands.UserCommands;

public class RefreshLoginUserCommand : Command, ICommand
{
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";

    public void Validate()
    {
        AddNotifications(new RefreshLoginUserContract(
            new RefreshLoginUser(Token, RefreshToken)));
    }
}