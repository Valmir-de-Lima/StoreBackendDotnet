namespace Store.Tests.Commands.UserCommandTests;

[TestClass]
[TestCategory("Commands")]
public class CreateUserCommandTests
{
    private CreateUserCommand _command = new();

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "Teste.31122022")]
    [DataRow("robin", "robin@wayne.com", "Teste.31122022")]
    [DataRow("superman", "superman@justiceleague.com", "Teste.31122022")]
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
    [DataRow("ba", "batman@wayne.com", "Teste.31122022")]
    [DataRow("", "robin@wayne.com", "Teste.31122022")]
    [DataRow("superman superman superman superman superman superman", "superman@justiceleague.com", "Teste.31122022")]
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
    [DataRow("batman", "@wayne.com", "Teste.31122022")]
    [DataRow("robin", "robin@.com", "Teste.31122022")]
    [DataRow("superman", "supermanjusticeleague.com", "Teste.31122022")]
    public void ShouldReturnInvalidCommandWhenEmailIsInvalid(string name, string addres, string password)
    {
        _command.Name = name;
        _command.Email = addres;
        _command.Password = password;

        _command.Validate();
        Assert.IsFalse(_command.IsValid);
    }

}

