using Flunt.Validations;

namespace Store.Domain.Entities.User.Contracts;

public class CreateUserContract : Contract<User>
{
    public CreateUserContract(User user)
    {
        Requires()
                .IsGreaterOrEqualsThan(user.Name.Replace(" ", ""), 3, user.Name, "O nome requer no minimo 3 letras")
                .IsLowerOrEqualsThan(user.Name, 40, user.Name, "O nome deve conter no maximo 40 caracteres")
                .IsNotNullOrEmpty(user.Active.ToString(), user.Active.ToString(), "O valor de ativação é requerido")
                .IsBetween(((int)user.Type), 0, 2, user.Name, "Tipo de usuário inválido");
    }
}
