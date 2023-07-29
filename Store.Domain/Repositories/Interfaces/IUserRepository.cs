
using Store.Domain.Commands.UserCommands;
using Store.Domain.Entities;
using Store.Domain.ValueObjects;

namespace Store.Domain.Repositories.Interfaces;
public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<bool> ExistsEmailAsync(Email email);
    Task<User?> GetByEmailAsync(Email email);
    Task<User?> GetByLinkAsync(string link);
    Task<IEnumerable<UserCommandResult>> GetAllAsync();
    void Update(User user);
    void Delete(User user);
}
