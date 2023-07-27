using Flunt.Validations;

namespace Store.Domain.Entities.Contracts;

public class CreateUserContract : Contract<User>
{
    public CreateUserContract(User user)
    {
        Requires()
                .IsGreaterOrEqualsThan(user.Name.Replace(" ", ""), 3, "Name.FirstName", "O nome requer no minimo 3 letras")
                .IsLowerOrEqualsThan(user.Name, 40, "Name.FirstName", "O nome deve conter no maximo 40 caracteres")
                .IsBetween(((int)user.Type), 0, 2, "user.Type", "Tipo de usuário inválido");
    }
}
