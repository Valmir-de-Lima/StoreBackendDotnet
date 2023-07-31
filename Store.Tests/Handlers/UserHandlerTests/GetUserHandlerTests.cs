using Store.Tests.Repositories;

namespace Store.Tests.Handlers.UserHandlerTests;

[TestClass]
[TestCategory("Handlers")]
public class GetUserHandlersTests
{
    private readonly UserHandler _handler = new UserHandler(new MockUserRepository());

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman-wayne-com")]
    [DataRow("robin-wayne-com")]
    [DataRow("superman-justiceleague-com")]
    public async Task ShouldReturnTrueSuccessWhenLinkExists(string link)
    {
        var _result = (CommandResult)await _handler.HandleAsync(link);

        Assert.IsTrue(_result.Success);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman-batman-com")]
    [DataRow("robin-robin-com")]
    [DataRow("superman-justice-com")]
    public async Task ShouldReturnFalseSucessWhenEmailDontExists(string link)
    {
        var _result = (CommandResult)await _handler.HandleAsync(link);

        Assert.IsFalse(_result.Success);
    }

}

