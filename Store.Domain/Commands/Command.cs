using System.Security.Claims;
using Flunt.Notifications;

namespace Store.Domain.Commands;
public class Command : Notifiable<Notification>
{
    private ClaimsPrincipal _user = new();
    public ClaimsPrincipal GetUserClaims()
    {
        return _user;
    }
    public void SetUser(ClaimsPrincipal user)
    {
        //user.Claims.GetType
        _user = user;
    }
}