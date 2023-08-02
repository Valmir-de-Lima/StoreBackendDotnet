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
    public void ShouldReturnValidUserWhenDatasAreValids(string name, string addres, string password, EType type)
    {
        var user = new User(name, new Email(addres), password, type);
        Assert.IsTrue(user.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("ba", "batman@wayne.com", "123456", EType.Manager)]
    [DataRow("", "robin@wayne.com", "123456", EType.Employee)]
    [DataRow("superman superman superman superman superman superman", "superman@justiceleague.com", "123456", EType.Customer)]
    public void ShouldReturnInvalidUserWhenNameIsInvalid(string name, string addres, string password, EType type)
    {
        var user = new User(name, new Email(addres), password, type);
        Assert.IsFalse(user.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "@wayne.com", "123456", 0)]
    [DataRow("robin", "robin@.com", "123456", 1)]
    [DataRow("superman", "supermanjusticeleague.com", "123456", 2)]
    public void ShouldReturnInvalidUserWhenEmailIsInvalid(string name, string addres, string password, EType type)
    {
        var user = new User(name, new Email(addres), password, type);
        Assert.IsFalse(user.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "batman@wayne.com", "123456", -1)]
    [DataRow("robin", "robin@wayne.com", "123456", 3)]
    [DataRow("superman", "superman@justiceleague.com", "123456", 4)]
    public void ShouldReturnInvalidUserWhenTypeIsInvalid(string name, string addres, string password, EType type)
    {
        var user = new User(name, new Email(addres), password, type);
        Assert.IsFalse(user.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman", "123456", EType.Manager)]
    [DataRow("robin", "123456", EType.Employee)]
    [DataRow("superman", "123456", EType.Customer)]
    public void ShouldReturnValidUserWhenDatasUpdateAreValids(string name, string password, EType type)
    {
        var user = new User("Flash", new Email("hero@justiceleague.com"), "123456", EType.Customer);
        user.Update(name, password);
        Assert.IsTrue(user.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("ba", "123456", EType.Manager)]
    [DataRow("", "123456", EType.Employee)]
    [DataRow("superman superman superman superman superman superman", "123456", EType.Customer)]
    public void ShouldReturnInvalidUserWhenNameUpdateisInvalid(string name, string password, EType type)
    {
        var user = new User("Flash", new Email("hero@justiceleague.com"), "123456", EType.Customer);
        user.Update(name, password);
        Assert.IsFalse(user.IsValid);
    }

    // [TestMethod]
    // [DataTestMethod]
    // [DataRow("batman", "123456", -1)]
    // [DataRow("robin", "123456", 3)]
    // [DataRow("superman", "123456", 4)]
    // public void ShouldReturnInvalidUserWhenTypeUpdateisInvalid(string name, string password, EType type)
    // {
    //     var user = new User("Flash", new Email("hero@justiceleague.com"), "123456", EType.Customer);
    //     user.Update(name, password);
    //     Assert.IsFalse(user.IsValid);
    // }
}

