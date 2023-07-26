using System.Linq.Expressions;
using Store.Domain.Entities;

namespace Store.Domain.Queries;

public static class UserQueries
{
    public static Expression<Func<User, bool>> GetByEmail(string address)
    {
        return x => x.Email.Address == address;
    }
}