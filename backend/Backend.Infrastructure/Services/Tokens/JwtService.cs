using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Infrastructure.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Infrastructure.Services.Tokens;

public class JwtService : IJwtService
{
    private readonly byte[] _secretKey = Encoding.UTF8.GetBytes("JWT_SECRET_KEY".GetFromEnvironmentVariables());
    private readonly string _issuer = "JWT_ISSUER".GetFromEnvironmentVariables();
    private readonly string _audience = "JWT_AUDIENCE".GetFromEnvironmentVariables();
    
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Name, user.Username),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Role, user.Role.ToString())
        };
        
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(_secretKey), SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: signingCredentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}