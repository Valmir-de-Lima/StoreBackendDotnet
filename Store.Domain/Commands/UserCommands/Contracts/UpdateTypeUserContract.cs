using Flunt.Validations;
using Store.Domain.Enums;

namespace Store.Domain.Commands.UserCommands.Contracts;

public class UpdateTypeUserContract : Contract<UpdateTypeUserCommand>
{
    public UpdateTypeUserContract(EType type)
    {
        Requires()
                .IsBetween((int)type, 0, 2, "user.Type", "Tipo de usuário inválido");
    }
}
