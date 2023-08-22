using Flunt.Validations;

namespace Store.Domain.Entities.User.Contracts;

public class RefreshLoginUserContract : Contract<RefreshLoginUser>
{
    public RefreshLoginUserContract(RefreshLoginUser refreshLoginUser)
    {
        Requires()
                .IsNotEmpty(refreshLoginUser.UserName, "RefreshLoginUser.UserName", "Informe o user name")
                .IsNotEmpty(refreshLoginUser.RefreshToken, "RefreshLoginUser.Token", "Informe o refreshToken");
    }
}
