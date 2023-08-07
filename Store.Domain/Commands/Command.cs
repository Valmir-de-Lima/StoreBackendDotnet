using System.Security.Claims;
using Flunt.Notifications;
using Store.Domain.Enums;

namespace Store.Domain.Commands;
public class Command : Notifiable<Notification>
{
    private ClaimsPrincipal _user = new();
    private string _userName = "";
    private EType _userType;
    public ClaimsPrincipal GetUserClaims()
    {
        return _user;
    }
    public void SetUser(ClaimsPrincipal user)
    {
        _user = user;
        if (user.Identity!.Name != null)
            _userName = user.Identity.Name;

        if (user.IsInRole("Manager"))
            _userType = EType.Manager;
        if (user.IsInRole("Employee"))
            _userType = EType.Employee;
        if (user.IsInRole("Customer"))
            _userType = EType.Customer;
    }

    public void SetUserName(string userName)
    {
        _userName = userName;
    }

    public void SetUserType(EType userType)
    {
        _userType = userType;
    }

    public string GetUserName()
    {
        return _userName;
    }
    public EType GetUserType()
    {
        return _userType;
    }
}