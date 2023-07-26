using System.Linq;
using System.Collections.Generic;
using Store.Domain.Repositories.Interfaces;
using Store.Tests.Repositories;
using Store.Domain.Queries;

namespace Store.Tests.Queries;

[TestClass]
[TestCategory("Queries")]
public class UserQueriesTests
{
    private MockUserRepository _repository;

    public UserQueriesTests()
    {
        _repository = new MockUserRepository();
    }


    [TestMethod]
    [DataTestMethod]
    [DataRow("batman@wayne.com")]
    [DataRow("robin@wayne.com")]
    [DataRow("superman@justiceleague.com")]
    public void ShouldReturnOneUserWhenEmailIsValid(string adress)
    {
        var result = _repository.Users.AsQueryable().Where(UserQueries.GetByEmail(adress));
        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("batman.com")]
    [DataRow("robin @wayne.com")]
    [DataRow("@justiceleague.com")]
    public void ShouldReturnZeroWhenEmailIsInvalid(string adress)
    {
        var result = _repository.Users.AsQueryable().Where(UserQueries.GetByEmail(adress));
        Assert.AreEqual(0, result.Count());
    }
}

