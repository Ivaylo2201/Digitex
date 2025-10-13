using System.Security.Claims;
using System.Text;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Database;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        Env.Load();
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var jwtSecretKey = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")!);
        var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER")!;
        var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")!;
        
        services
            // .AddScoped<IOrderService, OrderService>()
            // .AddScoped<IOwnershipService, OwnershipService>()
            // .AddScoped<IAuthenticationService, AuthenticationService>()
            // .AddSingleton<ITokenService, TokenService>()
            .AddDbContext<DatabaseContext>(d =>
            {
                d.UseSqlServer(connectionString,
                    s => s.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            })
            .AddCorsSupport(configuration)
            .AddJwtAuthentication(jwtSecretKey, jwtIssuer, jwtAudience);
    }

    private static void AddJwtAuthentication(this IServiceCollection services, byte[] key, string issuer, string audience)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        
        services.AddAuthorization();
    }

    private static IServiceCollection AddCorsSupport(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddCors(o =>
        {
            o.AddPolicy(
                nameof(Policy.AllowFrontend), 
                p => p.WithOrigins(configuration["Urls:Frontend"]!).AllowAnyHeader().AllowAnyMethod());

            o.AddPolicy(
                nameof(Policy.AllowAny), 
                p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });
    }
}