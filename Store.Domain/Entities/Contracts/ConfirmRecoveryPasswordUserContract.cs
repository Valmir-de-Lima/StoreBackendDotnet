using Flunt.Validations;

namespace Store.Domain.Entities.Contracts;

public class ConfirmRecoveryPasswordUserContract : Contract<User>
{
    public ConfirmRecoveryPasswordUserContract(string id)
    {
        Requires()
                .IsNotNullOrEmpty(id.ToString(), id.ToString(), "Identificação requerida")
                .Matches(id.ToString(), "^(?:\\{{0,1}(?:[0-9a-fA-F]){8}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){12}\\}{0,1})$", "id", "Valor inválido");
    }
}
