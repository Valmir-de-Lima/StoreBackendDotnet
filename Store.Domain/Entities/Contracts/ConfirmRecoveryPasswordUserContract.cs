using Flunt.Validations;

namespace Store.Domain.Entities.Contracts;

public class ConfirmRecoveryPasswordUserContract : Contract<User>
{
    public ConfirmRecoveryPasswordUserContract(Guid id)
    {
        Requires()
                .IsNotNullOrEmpty(id.ToString(), id.ToString(), "Identificação requerida");
    }
}
