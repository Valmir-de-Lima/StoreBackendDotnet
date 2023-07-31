using Store.Tests.Repositories;

namespace Store.Tests.Handlers.UserHandlerTests;

[TestClass]
[TestCategory("Handlers")]
public class CreateUserHandlersTests
{
    private readonly UserHandler _handler = new UserHandler(new MockUserRepository());

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@justice.com", "123456")]
    [DataRow("robin", "robin@justice.com", "123456")]
    [DataRow("superman", "superman@justice.com", "123456")]
    public async Task ShouldReturnTrueSuccessWhenDatasAreValids(string name, string addres, string password)
    {
        var command = new CreateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsTrue(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("ba", "batman@justice.com", "123456")]
    [DataRow("", "robin@justice.com", "123456")]
    [DataRow("superman superman superman superman superman superman", "superman@justice.com", "123456")]
    public async Task ShouldReturnFalseSucessWhenNameIsInvalid(string name, string addres, string password)
    {
        var command = new CreateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsFalse(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456")]
    [DataRow("robin", "robin@wayne.com", "123456")]
    [DataRow("superman", "superman@justiceleague.com", "123456")]
    public async Task ShouldReturnFalseSucessWhenEmailExists(string name, string addres, string password)
    {
        var command = new CreateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;

        var _result = (CommandResult)await _handler.HandleAsync(command);

        Assert.IsFalse(_result.Success);
    }

}

