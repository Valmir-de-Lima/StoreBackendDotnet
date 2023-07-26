namespace Store.Tests.ValueObjects;

[TestClass]
[TestCategory("ValueObjects")]
public class EmailTests
{
    [TestMethod]
    [DataTestMethod]
    [DataRow("batman@wayne.com")]
    [DataRow("robin@wayne.com")]
    [DataRow("superman@justiceleague.com")]
    public void ShouldReturnSuccessWhenEmailIsValid(string adress)
    {
        var email = new Email(adress);
        Assert.IsTrue(email.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman.com")]
    [DataRow("robin @wayne.com")]
    [DataRow("@justiceleague.com")]
    public void ShouldReturnErrorWhenEmailIsInvalid(string adress)
    {
        var email = new Email(adress);
        Assert.IsFalse(email.IsValid);
    }
}

