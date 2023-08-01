using System.Security.Claims;
using Store.Domain.Entities;

namespace Store.Domain.Services;
public interface ITokenService
{
    string GenerateToken(User user);
    string GenerateToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetClaimsFromExpiredToken(string token);
    void SaveRefreshToken(string username, string refreshToken);
    string GetRefreshToken(string username);
    void DeleteRefreshToken(string username);
}
