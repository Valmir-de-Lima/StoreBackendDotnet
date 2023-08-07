using Flunt.Validations;
using Store.Domain.Enums;

namespace Store.Domain.Entities.Contracts;

public class GetUserContract : Contract<User>
{
    public GetUserContract(string link)
    {
        Requires()
                .IsNotEmpty(link, link, "O link deve ser informado");
    }
}
