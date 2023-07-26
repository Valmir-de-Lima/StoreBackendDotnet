
using Store.Domain.Entities;
using Store.Domain.ValueObjects;

namespace Store.Domain.Repositories.Interfaces;
public interface IUserRepository
{
    void Create(User user);
    User GetByEmail(Email email);
    IEnumerable<User> GetAll();
    void Update(User user);
    void Delete(User user);
}
