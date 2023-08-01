using System.Security.Claims;
using Store.Domain.Entities;

namespace Store.Domain.Services;
public interface ITokenService
{
    string GenerateToken(User user);
    string GenerateToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetClaimsFromExpiredToken(string token);
    Task SaveRefreshTokenAsync(string userName, string refreshToken);
    Task<string?> GetRefreshTokenAsync(string userName);
    void DeleteRefreshToken(string userName);
}
