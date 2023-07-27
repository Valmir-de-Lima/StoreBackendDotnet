using Store.Tests.Repositories;

namespace Store.Tests.Handlers;

[TestClass]
[TestCategory("Handlers")]
public class CreateUserHandlersTests
{
    private readonly CreateUserHandler _handler = new CreateUserHandler(new MockUserRepository());

    private CommandResult _result = new(false, "");

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@justice.com", "123456", 2)]
    [DataRow("robin", "robin@justice.com", "123456", 1)]
    [DataRow("superman", "superman@justice.com", "123456", 0)]
    public void ShouldReturnSuccessWhenCommandIsValid(string name, string addres, string password, int type)
    {
        var command = new CreateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;
        command.Type = type;

        _result = (CommandResult)_handler.Handle(command);

        Assert.IsTrue(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("ba", "batman@wayne.com", "123456", 2)]
    [DataRow("", "robin@wayne.com", "123456", 1)]
    [DataRow("superman superman superman superman superman superman", "superman@justiceleague.com", "123456", 0)]
    public void ShouldReturnErrorWhenCommandIsInvalid(string name, string addres, string password, int type)
    {
        var command = new CreateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;
        command.Type = type;

        _result = (CommandResult)_handler.Handle(command);

        Assert.IsFalse(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456", 3)]
    [DataRow("robin", "robin@wayne.com", "123456", -1)]
    [DataRow("superman", "superman@justiceleague.com", "123456", 4)]
    public void ShouldReturnErrorWhenTypeIsInvalid(string name, string addres, string password, int type)
    {
        var command = new CreateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;
        command.Type = type;

        _result = (CommandResult)_handler.Handle(command);

        Assert.IsFalse(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456", 2)]
    [DataRow("robin", "robin@wayne.com", "123456", 1)]
    [DataRow("superman", "superman@justiceleague.com", "123456", 0)]
    public void ShouldReturnErrorWhenEmailExists(string name, string addres, string password, int type)
    {
        var command = new CreateUserCommand();
        command.Name = name;
        command.Email = addres;
        command.PasswordHash = password;
        command.Type = type;

        _result = (CommandResult)_handler.Handle(command);

        Assert.IsFalse(_result.Success);
    }

}

