using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
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

    public void Create(User user)
    {
        _context.Users.AddAsync(user);
        _context.SaveChanges();
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public bool ExistsEmail(Email email)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == email);
        return (user != null);
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users
               .AsNoTracking()
               .ToList();
    }

    public User GetByEmail(Email email)
    {
        return _context.Users.First(x => x.Email == email);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }
}