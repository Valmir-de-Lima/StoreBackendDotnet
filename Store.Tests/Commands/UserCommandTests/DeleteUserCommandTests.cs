namespace Store.Tests.Commands.UserCommandTests;

[TestClass]
[TestCategory("Commands")]
public class DeleteUserCommandTests
{
    private DeleteUserCommand _command = new();

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman@wayne.com", "123456")]
    [DataRow("robin@wayne.com", "123456")]
    [DataRow("superman@justiceleague.com", "123456")]
    public void ShouldReturnValidCommandWhenEmailIsValid(string addres, string password)
    {
        _command.Email = addres;
        _command.PasswordHash = password;

        _command.Validate();
        Assert.IsTrue(_command.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("@wayne.com", "123456")]
    [DataRow("robin@.com", "123456")]
    [DataRow("supermanjusticeleague.com", "123456")]
    public void ShouldReturnInvalidCommandWhenEmailIsInvalid(string addres, string password)
    {
        _command.Email = addres;
        _command.PasswordHash = password;

        _command.Validate();
        Assert.IsFalse(_command.IsValid);
    }

}

