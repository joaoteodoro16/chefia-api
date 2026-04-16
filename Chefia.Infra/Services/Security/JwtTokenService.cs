using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Chefia.Api.Settings;
using Chefia.Domain.Entities;
using Chefia.Domain.Services.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Chefia.Infra.Services.Security;

public class JwtTokenService : IJwtTokenService
{
    private readonly JwtSettings _settings;

    public JwtTokenService(IOptions<JwtSettings> settings)
    {
        _settings = settings.Value;
    }


    public string GenerateToken(User op)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, op.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, op.Email),
            new Claim(ClaimTypes.Name, op.Name),
            new Claim(ClaimTypes.Role, op.Role.ToString()),
            new Claim("companyId", op.CompanyId?.ToString() ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_settings.ExpirationInMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
