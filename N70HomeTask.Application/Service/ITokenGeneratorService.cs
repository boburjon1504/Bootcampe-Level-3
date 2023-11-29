using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using N70HomeTask.Domain.Entities;

namespace N70HomeTask.Application.Service;

public interface ITokenGeneratorService
{
    string GenerateToken(User user);
    JwtSecurityToken GetJwtToken(User user);
    List<Claim> GetClaims(User user);
}