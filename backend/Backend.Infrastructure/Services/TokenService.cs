using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using DotNetEnv;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Infrastructure.Services;

public class TokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        Env.Load();

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Name, user.Username),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")!);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
            audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: signingCredentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}