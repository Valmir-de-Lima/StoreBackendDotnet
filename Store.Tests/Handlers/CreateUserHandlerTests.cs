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
    [DataRow("batman", "batman@wayne.com", "123456", EType.Manager)]
    [DataRow("robin", "robin@wayne.com", "123456", EType.Employee)]
    [DataRow("superman", "superman@justiceleague.com", "123456", EType.Customer)]
    public void ShouldReturnSuccessWhenCommandIsValid(string name, string addres, string password, EType type)
    {
        var command = new CreateUserCommand();
        command.Name = name;
        command.Email = new Email(addres);
        command.PasswordHash = password;
        command.Type = type;

        _result = (CommandResult)_handler.Handle(command);

        Assert.IsTrue(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("ba", "batman@wayne.com", "123456", EType.Manager)]
    [DataRow("", "robin@wayne.com", "123456", EType.Employee)]
    [DataRow("superman superman superman superman superman superman", "superman@justiceleague.com", "123456", EType.Customer)]
    public void ShouldReturnErrorWhenCommandIsInvalid(string name, string addres, string password, EType type)
    {
        var command = new CreateUserCommand();
        command.Name = name;
        command.Email = new Email(addres);
        command.PasswordHash = password;
        command.Type = type;

        _result = (CommandResult)_handler.Handle(command);

        Assert.IsFalse(_result.Success);
    }
}

