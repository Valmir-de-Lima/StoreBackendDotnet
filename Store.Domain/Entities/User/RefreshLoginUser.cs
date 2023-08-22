using Store.Shared.Entities;
using Store.Domain.Entities.User.Contracts;

namespace Store.Domain.Entities.User;

public class RefreshLoginUser : Entity
{
    public RefreshLoginUser()
    {

    }
    public RefreshLoginUser(string userName, string refreshToken)
    {
        UserName = userName;
        RefreshToken = refreshToken;

        // Design by contracts
        AddNotifications(
            new RefreshLoginUserContract(this)
        );
    }

    public string UserName { get; private set; } = "";
    public string RefreshToken { get; private set; } = "";
}