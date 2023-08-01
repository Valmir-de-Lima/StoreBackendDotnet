using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Domain.Entities;
using Store.Domain.Entities.Contracts;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Commands;

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