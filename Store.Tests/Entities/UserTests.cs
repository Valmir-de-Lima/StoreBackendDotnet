using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Domain.ValueObjects;

namespace Store.Tests.Entities;

[TestClass]
[TestCategory("Entities")]
public class UserTests
{
    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456", EType.Manager)]
    [DataRow("robin", "robin@wayne.com", "123456", EType.Employee)]
    [DataRow("superman", "superman@justiceleague.com", "123456", EType.Customer)]
    public void ShouldReturnSuccessWhenNameIsValid(string name, string addres, string password, EType type)
    {
        var user = new User(name, new Email(addres), password, type);
        Assert.IsTrue(user.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("ba", "batman@wayne.com", "123456", EType.Manager)]
    [DataRow("", "robin@wayne.com", "123456", EType.Employee)]
    [DataRow("superman superman superman superman superman superman", "superman@justiceleague.com", "123456", EType.Customer)]
    public void ShouldReturnErrorWhenNameIsInvalid(string name, string addres, string password, EType type)
    {
        var user = new User(name, new Email(addres), password, type);
        Assert.IsFalse(user.IsValid);
    }
}

