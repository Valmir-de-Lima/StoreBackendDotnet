using Flunt.Validations;
using Store.Domain.Enums;

namespace Store.Domain.Entities.Contracts;

public class UpdateNameUserContract : Contract<User>
{
    public UpdateNameUserContract(string token, string name)
    {
        Requires()
                .IsGreaterOrEqualsThan(name.Replace(" ", ""), 3, name, "O nome requer no minimo 3 letras")
                .IsLowerOrEqualsThan(name, 40, name, "O nome deve conter no maximo 40 caracteres")
                .IsNotEmpty(token, token, "Token é exigido");
    }
}
