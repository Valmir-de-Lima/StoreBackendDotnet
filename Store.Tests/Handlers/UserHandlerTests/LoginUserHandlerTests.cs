namespace Store.Tests.Handlers.UserHandlerTests;

[TestClass]
[TestCategory("Handlers")]
public class LoginUserHandlersTests
{
    private readonly UserHandler _handler = new(new MockUserRepository(), new MockTokenService());
    private readonly LoginUserCommand _command = new();


    [TestMethod]
    [DataTestMethod]
    [DataRow("batman@wayne.com", "123456")]
    [DataRow("robin@wayne.com", "123456")]
    [DataRow("superman@justiceleague.com", "123456")]
    public async Task ShouldReturnTrueSuccessWhenDatasAreValids(string addres, string password)
    {
        _command.Email = addres;
        _command.Password = password;

        var _result = (CommandResult)await _handler.HandleAsync(_command);

        Assert.IsTrue(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman@batman.com", "123456")]
    [DataRow("robin@robin.com", "123456")]
    [DataRow("superman@justice.com", "123456")]
    public async Task ShouldReturnFalseSucessWhenEmailDontExists(string addres, string password)
    {
        _command.Email = addres;
        _command.Password = password;

        var _result = (CommandResult)await _handler.HandleAsync(_command);

        Assert.IsFalse(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman@wayne.com", "")]
    [DataRow("robin@wayne.com", "123455")]
    [DataRow("superman@justiceleague.com", "123456123456")]
    public async Task ShouldReturnFalseSucessWhenPasswordDontMatch(string addres, string password)
    {
        _command.Email = addres;
        _command.Password = password;

        var _result = (CommandResult)await _handler.HandleAsync(_command);

        Assert.IsFalse(_result.Success);
    }
}

