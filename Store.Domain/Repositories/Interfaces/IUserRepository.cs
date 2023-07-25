
using Store.Domain.Entities;

namespace Store.Domain.Repositories.Interfaces;
public interface ICustomerRepository
{
    User Get(string email);
}
