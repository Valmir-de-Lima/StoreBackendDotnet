using Flunt.Validations;

namespace Store.Domain.Entities.Contracts;

public class UpdateRecoveryPasswordUserContract : Contract<User>
{
    public UpdateRecoveryPasswordUserContract(Guid id, string password, Guid recoveryPassword)
    {
        Requires()
                .IsNotNullOrEmpty(id.ToString(), id.ToString(), "Campo requerido")
                .IsNotNullOrEmpty(password, password, "Campo requerido")
                .IsNotNullOrEmpty(recoveryPassword.ToString(), recoveryPassword.ToString(), "Campo requerido");
    }
}
