using Microsoft.EntityFrameworkCore;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Entities.User;
using Store.Domain.Queries;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.ValueObjects;
using Store.Infra.Data;

namespace Store.Infra.Repositories;

public class RefreshLoginUserRepository : IRefreshLoginUserRepository
{
    private readonly StoreDataContext _context;

    public RefreshLoginUserRepository(StoreDataContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(RefreshLoginUser refreshLoginUser)
    {
        await _context.RefreshLoginUsers.AddAsync(refreshLoginUser);
        _context.SaveChanges();
    }

    public void Delete(RefreshLoginUser item)
    {
        _context.RefreshLoginUsers.Remove(item);
        _context.SaveChanges();
    }

    public async Task<string?> GetByUserNameAsync(string userName)
    {
        var refreshLoginUser = await _context.RefreshLoginUsers.FirstOrDefaultAsync(x => x.UserName == userName);
        if (refreshLoginUser != null)
            return refreshLoginUser.RefreshToken;
        return "";
    }

    public async Task<RefreshLoginUser?> GetByUserNameAndRefreshTokenAsync(string userName, string refreshToken)
    {
        return await _context.RefreshLoginUsers.FirstOrDefaultAsync(x => x.UserName == userName && x.RefreshToken == refreshToken);
    }

}