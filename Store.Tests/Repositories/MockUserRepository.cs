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


    public async Task CreateAsync(User user)
    {
        _users.Add(user);
        await Task.CompletedTask;
    }

    public void Delete(User user)
    {
        _users.Remove(user);
    }

    public async Task<IEnumerable<UserCommandResult>> GetAllAsync()
    {
        await Task.CompletedTask;
        return new List<UserCommandResult>(
                _users
                .AsQueryable()
                .Select(x => new UserCommandResult(x))
                );
    }
    public async Task<bool> ExistsEmailAsync(Email email)
    {
        var user = _users.AsQueryable().FirstOrDefault(UserQueries.ExistsEmail(email));
        await Task.CompletedTask;
        return user != null;
    }

    public async Task<User?> GetByEmailAsync(Email email)
    {
        await Task.CompletedTask;
        return _users.AsQueryable().FirstOrDefault(UserQueries.GetByEmail(email));
    }
    public async Task<User?> GetByLinkAsync(string link)
    {
        await Task.CompletedTask;
        return _users.AsQueryable().FirstOrDefault(UserQueries.GetByLink(link));
    }

    public void Update(User user)
    {
        var userOld = _users.AsQueryable().FirstOrDefault(UserQueries.GetByLink(user.Link));
        if (userOld != null)
            _users.Remove(userOld);
        _users.Add(user);
    }

    public List<User> Users => _users;
}