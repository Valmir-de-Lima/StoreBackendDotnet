using Flunt.Validations;

namespace Store.Domain.Entities.Contracts;

public class UpdateRecoveryPasswordUserContract : Contract<User>
{
    public UpdateRecoveryPasswordUserContract(Guid id, string password)
    {
        Requires()
                .IsNotNullOrEmpty(id.ToString(), id.ToString(), "Identificação requerida")
                .IsNotNullOrEmpty(password, password, "Password requerido");
    }
}
