namespace Store.Tests.Handlers.UserHandlerTests;

[TestClass]
[TestCategory("Handlers")]
public class LoginUserHandlersTests
{
    private readonly UserHandler _handler = new UserHandler(new MockUserRepository(), new MockTokenService());

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456")]
    [DataRow("robin", "robin@wayne.com", "123456")]
    [DataRow("superman", "superman@justiceleague.com", "123456")]
    public async Task ShouldReturnTrueSuccessWhenDatasAreValids(string name, string addres, string password)
    {
        var command = new LoginUserCommand();
        command.Name = name;
        command.Email = addres;
        command.Password = password;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsTrue(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("ba", "batman@wayne.com", "123456")]
    [DataRow("", "robin@wayne.com", "123456")]
    [DataRow("superman superman superman superman superman superman", "superman@justiceleague.com", "123456")]
    public async Task ShouldReturnFalseSucessWhenNameIsInvalid(string name, string addres, string password)
    {
        var command = new LoginUserCommand();
        command.Name = name;
        command.Email = addres;
        command.Password = password;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsFalse(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@batman.com", "123456")]
    [DataRow("robin", "robin@robin.com", "123456")]
    [DataRow("superman", "superman@justice.com", "123456")]
    public async Task ShouldReturnFalseSucessWhenEmailDontExists(string name, string addres, string password)
    {
        var command = new LoginUserCommand();
        command.Name = name;
        command.Email = addres;
        command.Password = password;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsFalse(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "")]
    [DataRow("robin", "robin@wayne.com", "123455")]
    [DataRow("superman", "superman@justiceleague.com", "123456123456")]
    public async Task ShouldReturnFalseSucessWhenPasswordDontMatch(string name, string addres, string password)
    {
        var command = new LoginUserCommand();
        command.Name = name;
        command.Email = addres;
        command.Password = password;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsFalse(_result.Success);
    }
}

