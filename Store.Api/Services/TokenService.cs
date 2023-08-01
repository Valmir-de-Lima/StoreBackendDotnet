using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Store.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Store.Domain.Services;

namespace Store.Api.Services;

public class TokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[] {
                new (ClaimTypes.Name, user.Link),
                new (ClaimTypes.Role, user.Type.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}