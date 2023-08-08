using Flunt.Validations;

namespace Store.Domain.Entities.Contracts;

public class ActiveUserContract : Contract<User>
{
    public ActiveUserContract(Guid id)
    {
        Requires()
                .IsNotNullOrEmpty(id.ToString(), id.ToString(), "Identificação requerida");
    }
}
