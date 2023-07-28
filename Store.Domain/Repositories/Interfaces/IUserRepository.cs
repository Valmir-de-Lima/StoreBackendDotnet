
using Store.Domain.Entities;
using Store.Domain.ValueObjects;

namespace Store.Domain.Repositories.Interfaces;
public interface IUserRepository
{
    void Create(User user);
    bool ExistsEmail(Email email);
    User? GetByEmail(Email email);
    User? GetByLink(string link);
    IEnumerable<User> GetAll();
    void Update(User user);
    void Delete(User user);
}
