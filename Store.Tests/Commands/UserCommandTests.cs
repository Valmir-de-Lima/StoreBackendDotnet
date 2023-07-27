namespace Store.Tests.Commands;

[TestClass]
[TestCategory("Commands")]
public class UserCommandTests
{
    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456", EType.Manager)]
    [DataRow("robin", "robin@wayne.com", "123456", EType.Employee)]
    [DataRow("superman", "superman@justiceleague.com", "123456", EType.Customer)]
    public void ShouldReturnSuccessWhenNameIsValid(string name, string addres, string password, EType type)
    {
        var command = new CreateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;
        command.Type = (int)type;

        command.Validate();
        Assert.IsTrue(command.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("ba", "batman@wayne.com", "123456", EType.Manager)]
    [DataRow("", "robin@wayne.com", "123456", EType.Employee)]
    [DataRow("superman superman superman superman superman superman", "superman@justiceleague.com", "123456", EType.Customer)]
    public void ShouldReturnErrorWhenNameIsInvalid(string name, string addres, string password, EType type)
    {
        var command = new CreateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;
        command.Type = (int)type;

        command.Validate();
        Assert.IsFalse(command.IsValid);
    }
}

