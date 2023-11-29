using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using N70HomeTask.Application.Service;
using N70HomeTask.Domain.Entities;
using N70HomeTask.Infrastructure.Common.Settings;

namespace N70HomeTask.Infrastructure.Service;

public class TokenGeneratorService(IOptions<JwtSettings> jwtSettings) : ITokenGeneratorService
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    public string GenerateToken(User user)
    {
        var token = GetJwtToken(user);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var jwtToken = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(jwtToken, SecurityAlgorithms.HmacSha256);
        return new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            claims: claims,
            signingCredentials: credentials
        );
    }

    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>{
            new Claim(ClaimTypes.Role, user.Role.RoleType.ToString())
            };
    }
}