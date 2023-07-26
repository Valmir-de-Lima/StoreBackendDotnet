
using Store.Domain.Entities;
using Store.Domain.ValueObjects;

namespace Store.Domain.Repositories.Interfaces;
public interface IUserRepository
{
    void Save(User user);
    void Update(User user);
    User Get(Email email);
    void Delete(User user);
}
