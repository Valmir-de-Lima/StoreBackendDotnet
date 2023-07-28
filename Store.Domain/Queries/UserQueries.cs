using System.Linq.Expressions;
using Store.Domain.Entities;
using Store.Domain.ValueObjects;

namespace Store.Domain.Queries;

public static class UserQueries
{
    public static Expression<Func<User, bool>> GetByEmail(string address)
    {
        return x => x.Email.Address == address;
    }

    public static Expression<Func<User, bool>> ExistsEmail(Email email)
    {
        return x => x.Email.Address == email.Address;
    }
}