using Domain.Shared.ValueObjects;
using Store.Domain.ValueObjects.Contracts;

namespace Store.Domain.ValueObjects;
public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;

        //Design by contracts
        AddNotifications(
            new CreateEmailContract(this)
        );
    }

    public string Address { get; private set; }
}
