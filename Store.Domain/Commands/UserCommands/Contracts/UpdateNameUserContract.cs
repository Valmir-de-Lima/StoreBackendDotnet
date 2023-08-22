using Flunt.Validations;

namespace Store.Domain.Commands.UserCommands.Contracts;

public class UpdateNameUserContract : Contract<UpdateUserCommand>
{
    public UpdateNameUserContract(string name)
    {
        Requires()
                .IsGreaterOrEqualsThan(name.Replace(" ", ""), 3, name, "O nome requer no minimo 3 letras")
                .IsLowerOrEqualsThan(name, 40, name, "O nome deve conter no maximo 40 caracteres");
    }
}
