namespace Store.Tests.Commands.UserCommandTests;

[TestClass]
[TestCategory("Commands")]
public class LoginUserCommandTests
{
    private LoginUserCommand _command = new();

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456")]
    [DataRow("robin", "robin@wayne.com", "123456")]
    [DataRow("superman", "superman@justiceleague.com", "123456")]
    public void ShouldReturnValidCommandWhenDatasAreValids(string name, string addres, string password)
    {
        _command.Name = name;
        _command.Email = addres;
        _command.Password = password;

        _command.Validate();
        Assert.IsTrue(_command.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("ba", "batman@wayne.com", "123456")]
    [DataRow("", "robin@wayne.com", "123456")]
    [DataRow("superman superman superman superman superman superman", "superman@justiceleague.com", "123456")]
    public void ShouldReturnInvalidCommandWhenNameIsInvalid(string name, string addres, string password)
    {
        _command.Name = name;
        _command.Email = addres;
        _command.Password = password;

        _command.Validate();
        Assert.IsFalse(_command.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "@wayne.com", "123456")]
    [DataRow("robin", "robin@.com", "123456")]
    [DataRow("superman", "supermanjusticeleague.com", "123456")]
    public void ShouldReturnInvalidCommandWhenEmailIsInvalid(string name, string addres, string password)
    {
        _command.Name = name;
        _command.Email = addres;
        _command.Password = password;

        _command.Validate();
        Assert.IsFalse(_command.IsValid);
    }
}

