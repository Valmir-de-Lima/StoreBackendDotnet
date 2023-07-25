using Domain.Shared.ValueObjects;
using Flunt.Validations;

namespace Store.Domain.ValueObjects;
public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;

        //Design by contracts
        AddNotifications(
            new Contract()
            .Requires()
            .IsEmail(Address, "Email.Address", "Email inválido")
        );
    }

    public string Address { get; private set; }
}
