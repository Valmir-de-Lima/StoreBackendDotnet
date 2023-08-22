using System.Security.Claims;
using Store.Domain.Entities.User;

namespace Store.Domain.Services;
public interface ITokenService
{
    string GenerateToken(User user);
    string GenerateToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetClaimsFromToken(string token);
    Task SaveRefreshTokenAsync(string userName, string refreshToken);
    Task<string?> GetRefreshTokenAsync(string userName);
    void DeleteRefreshToken(string userName);
    void LoadClaimsPrincipal(IEnumerable<Claim> claimsPrincipal);
    ClaimsPrincipal GetUserClaims();
}
