namespace Store.Tests.Handlers.UserHandlerTests;

[TestClass]
[TestCategory("Handlers")]
public class DeleteUserHandlersTests
{
    private readonly UserHandler _handler = new(new MockUserRepository(), new MockTokenService());

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman@wayne.com", "123456")]
    [DataRow("robin@wayne.com", "123456")]
    [DataRow("superman@justiceleague.com", "123456")]
    public async Task ShouldReturnTrueSuccessWhenEmailExists(string addres, string password)
    {
        var command = new DeleteUserCommand();
        command.Email = addres;
        command.Password = password;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsTrue(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman@batman.com", "123456")]
    [DataRow("robin@robin.com", "123456")]
    [DataRow("superman@justice.com", "123456")]
    public async Task ShouldReturnFalseSucessWhenEmailDontExists(string addres, string password)
    {
        var command = new DeleteUserCommand();
        command.Email = addres;
        command.Password = password;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsFalse(_result.Success);
    }

}

