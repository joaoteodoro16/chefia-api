using Chefia.Domain.Services.Security;

namespace Chefia.Infra.Services.Security;

public class ByCryptService : IPasswordHasher
{
    private const int _WorkFactor = 12;

    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, _WorkFactor);
    }

    public bool VerifyPassword(string providedPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
    }
}
