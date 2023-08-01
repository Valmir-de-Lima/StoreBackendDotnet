using Store.Domain.Services;

namespace Store.Tests.Services;

public class MockTokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        return "";
    }
}

