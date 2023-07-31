namespace Store.Tests.Commands.UserCommandTests;

[TestClass]
[TestCategory("Commands")]
public class UpdateUserCommandTests
{
    private UpdateUserCommand _command = new();

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456", EType.Manager)]
    [DataRow("robin", "robin@wayne.com", "123456", EType.Employee)]
    [DataRow("superman", "superman@justiceleague.com", "123456", EType.Customer)]
    public void ShouldReturnValidCommandWhenDatasAreValids(string name, string addres, string password, EType type)
    {
        _command.Name = name;
        _command.Email = addres;
        _command.PasswordHash = password;
        _command.Type = (int)type;

        _command.Validate();
        Assert.IsTrue(_command.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("ba", "batman@wayne.com", "123456", EType.Manager)]
    [DataRow("", "robin@wayne.com", "123456", EType.Employee)]
    [DataRow("superman superman superman superman superman superman", "superman@justiceleague.com", "123456", EType.Customer)]
    public void ShouldReturnInvalidCommandWhenNameIsInvalid(string name, string addres, string password, EType type)
    {
        _command.Name = name;
        _command.Email = addres;
        _command.PasswordHash = password;
        _command.Type = (int)type;

        _command.Validate();
        Assert.IsFalse(_command.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456", -1)]
    [DataRow("robin", "robin@wayne.com", "123456", 3)]
    [DataRow("superman", "superman@justiceleague.com", "123456", 4)]

    public void ShouldReturnInvalidCommandWhenTypeIsInvalid(string name, string addres, string password, EType type)
    {
        _command.Name = name;
        _command.Email = addres;
        _command.PasswordHash = password;
        _command.Type = (int)type;

        _command.Validate();
        Assert.IsFalse(_command.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "@wayne.com", "123456", 0)]
    [DataRow("robin", "robin@.com", "123456", 1)]
    [DataRow("superman", "supermanjusticeleague.com", "123456", 2)]
    public void ShouldReturnInvalidCommandWhenEmailIsInvalid(string name, string addres, string password, EType type)
    {
        _command.Name = name;
        _command.Email = addres;
        _command.PasswordHash = password;
        _command.Type = (int)type;

        _command.Validate();
        Assert.IsFalse(_command.IsValid);
    }
}

