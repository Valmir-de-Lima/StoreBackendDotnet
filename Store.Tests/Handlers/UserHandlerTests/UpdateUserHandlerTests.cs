using Store.Tests.Repositories;

namespace Store.Tests.Handlers.UserHandlerTests;

[TestClass]
[TestCategory("Handlers")]
public class UpdateUserHandlersTests
{
    private readonly UserHandler _handler = new UserHandler(new MockUserRepository());

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456", 2)]
    [DataRow("robin", "robin@wayne.com", "123456", 1)]
    [DataRow("superman", "superman@justiceleague.com", "123456", 0)]
    public async Task ShouldReturnSuccessWhenCommandIsValid(string name, string addres, string password, int type)
    {
        var command = new UpdateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;
        command.Type = type;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsTrue(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("ba", "batman@wayne.com", "123456", 2)]
    [DataRow("", "robin@wayne.com", "123456", 1)]
    [DataRow("superman superman superman superman superman superman", "superman@justiceleague.com", "123456", 0)]
    public async Task ShouldReturnErrorWhenCommandIsInvalid(string name, string addres, string password, int type)
    {
        var command = new UpdateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;
        command.Type = type;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsFalse(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456", 3)]
    [DataRow("robin", "robin@wayne.com", "123456", -1)]
    [DataRow("superman", "superman@justiceleague.com", "123456", 4)]
    public async Task ShouldReturnErrorWhenTypeIsInvalid(string name, string addres, string password, int type)
    {
        var command = new UpdateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;
        command.Type = type;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsFalse(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@batman.com", "123456", 2)]
    [DataRow("robin", "robin@robin.com", "123456", 1)]
    [DataRow("superman", "superman@justice.com", "123456", 0)]
    public async Task ShouldReturnErrorWhenEmailDontExists(string name, string addres, string password, int type)
    {
        var command = new UpdateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;
        command.Type = type;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsFalse(_result.Success);
    }

}

