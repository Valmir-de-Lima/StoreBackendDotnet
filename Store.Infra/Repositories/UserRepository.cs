using Microsoft.EntityFrameworkCore;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Entities;
using Store.Domain.Queries;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.ValueObjects;
using Store.Infra.Data;

namespace Store.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly StoreDataContext _context;

    public UserRepository(StoreDataContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        _context.SaveChanges();
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public async Task<bool> ExistsEmailAsync(Email email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(UserQueries.ExistsEmail(email));
        return (user != null);
    }

    public async Task<IEnumerable<UserCommandResult>> GetAllAsync()
    {
        return new List<UserCommandResult>(await
                _context.Users
                .AsNoTracking()
                .Select(x => new UserCommandResult(x))
                .ToListAsync()
        );
    }

    public async Task<User?> GetByEmailAsync(Email email)
    {
        return await _context.Users.FirstOrDefaultAsync(UserQueries.GetByEmail(email));
    }

    public async Task<User?> GetByLinkAsync(string link)
    {
        return await _context.Users.FirstOrDefaultAsync(UserQueries.GetByLink(link));
    }


    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }
}