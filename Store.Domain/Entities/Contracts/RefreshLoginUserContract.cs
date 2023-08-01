using Flunt.Validations;
using Store.Domain.Commands.UserCommands;


namespace Store.Domain.Entities.Contracts;

public class RefreshLoginUserContract : Contract<RefreshLoginUserCommand>
{
    public RefreshLoginUserContract(RefreshLoginUserCommand command)
    {
        Requires()
                .IsNotEmpty(command.Token, "RefreshLoginUserCommand.Token", "Informe o token")
                .IsNotEmpty(command.RefreshToken, "RefreshLoginUserCommand.Token", "Informe o refreshToken");
    }
}
