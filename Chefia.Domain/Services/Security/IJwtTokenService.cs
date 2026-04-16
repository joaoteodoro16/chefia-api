using Chefia.Domain.Entities;

namespace Chefia.Domain.Services.Security;

public interface IJwtTokenService
{
    string GenerateToken(User op);
}
