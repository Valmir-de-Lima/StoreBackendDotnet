using Store.Domain.Entities;

namespace Store.Domain.Services;
public interface ITokenService
{
    string GenerateToken(User user);
}
