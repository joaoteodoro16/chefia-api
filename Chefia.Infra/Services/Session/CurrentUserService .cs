using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Chefia.App.Services;
using Microsoft.AspNetCore.Http;

namespace Chefia.Infra.Services.Session;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private static readonly string[] UserIdClaimTypes = [ClaimTypes.NameIdentifier, JwtRegisteredClaimNames.Sub, "sub"];

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid CompanyId
    {
        get
        {
            var claim = _httpContextAccessor.HttpContext?.User.FindFirst("companyId");
            if (claim == null || !Guid.TryParse(claim.Value, out var id))
                throw new UnauthorizedAccessException("CompanyId não encontrado no token.");
            return id;
        }
    }

    public Guid UserId => GetRequiredGuidClaim(UserIdClaimTypes, "Usuário não encontrado no token.");

    private Guid GetRequiredGuidClaim(IEnumerable<string> claimTypes, string errorMessage)
    {
        var user = _httpContextAccessor.HttpContext?.User;

        foreach (var claimType in claimTypes)
        {
            var claim = user?.FindFirst(claimType);
            if (claim != null && Guid.TryParse(claim.Value, out var id))
                return id;
        }

        throw new UnauthorizedAccessException(errorMessage);
    }

}
