using Store.Domain.Queries;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories;

public class MockUserRepository : IUserRepository
{

    private List<User> _users;

    public MockUserRepository()
    {
        _users = new List<User>();
        _users.Add(new User("batman", new Email("batman@wayne.com"), "123456", EType.Manager));
        _users.Add(new User("robin", new Email("robin@wayne.com"), "123456", EType.Employee));
        _users.Add(new User("superman", new Email("superman@justiceleague.com"), "123456", EType.Customer));
    }


    public void Create(User user)
    {
        //throw new NotImplementedException();
    }

    public void Delete(User user)
    {
        //throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }
    public bool ExistsEmail(Email email)
    {
        var user = _users.AsQueryable().FirstOrDefault(UserQueries.ExistsEmail(email));
        return user != null;
    }

    public User GetByEmail(Email email)
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        //throw new NotImplementedException();
    }

    public List<User> Users => _users;
}