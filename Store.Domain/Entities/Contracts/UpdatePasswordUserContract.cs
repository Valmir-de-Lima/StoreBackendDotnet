using Flunt.Validations;

namespace Store.Domain.Entities.Contracts;

public class UpdatePasswordUserContract : Contract<User>
{
    public UpdatePasswordUserContract(string oldPassword, string newPassword)
    {
        Requires()
                .IsNotEmpty(oldPassword, "oldPassword", "Informe a senha antiga")
                .IsNotEmpty(newPassword, "newPassword", "Informe a senha nova");
    }
}
