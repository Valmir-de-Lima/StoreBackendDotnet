
using Store.Domain.Entities;
using Store.Domain.ValueObjects;

namespace Store.Domain.Repositories.Interfaces;
public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<bool> ExistsEmailAsync(Email email);
    Task<User?> GetByEmailAsync(Email email);
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByLinkAsync(string link);
    Task<dynamic> GetAllAsync(int skip = 0, int take = 25);
    void Update(User user);
    void Delete(User user);
}
