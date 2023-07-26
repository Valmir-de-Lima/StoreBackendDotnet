using Flunt.Validations;

namespace Store.Domain.ValueObjects.Contracts;

public class CreateEmailContract : Contract<Email>
{
    public CreateEmailContract(Email email)
    {
        Requires()
        .IsEmail(email.Address, "Email.Address", "Email inválido");
    }
}
