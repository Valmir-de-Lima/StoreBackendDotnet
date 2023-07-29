using Store.Tests.Repositories;

namespace Store.Tests.Handlers.UserHandlerTests;

[TestClass]
[TestCategory("Handlers")]
public class DeleteUserHandlersTests
{
    private readonly UserHandler _handler = new UserHandler(new MockUserRepository());

    private CommandResult _result = new(false, "");

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman@wayne.com", "123456")]
    [DataRow("robin@wayne.com", "123456")]
    [DataRow("superman@justiceleague.com", "123456")]
    public void ShouldReturnSuccessWhenEmailExists(string addres, string password)
    {
        var command = new DeleteUserCommand();
        command.Email = addres;
        command.PasswordHash = password;

        _result = (CommandResult)_handler.Handle(command);

        Assert.IsTrue(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman@batman.com", "123456")]
    [DataRow("robin@robin.com", "123456")]
    [DataRow("superman@justice.com", "123456")]
    public void ShouldReturnErrorWhenEmailDontExists(string addres, string password)
    {
        var command = new DeleteUserCommand();
        command.Email = addres;
        command.PasswordHash = password;

        _result = (CommandResult)_handler.Handle(command);

        Assert.IsFalse(_result.Success);
    }

}

