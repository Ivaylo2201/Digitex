using System.Security.Claims;
using System.Text;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Database.Repositories;
using Backend.Infrastructure.Services;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Backend.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            Env.Load();
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var jwtSecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            
            services
                .AddDbContext(connectionString)
                .AddServices()
                .AddRepositories()
                .AddCors(configuration)
                .AddAuthentication(jwtSecretKey, jwtIssuer, jwtAudience);
            
            Log.Information("[{ClassName}]: Infrastructure services successfully initialized.", nameof(InfrastructureDependencyInjection));
        }
        catch (Exception ex)
        {
            Log.Error("[{ClassName}]: {ExceptionType} occurred while configuring DI for Infrastructure. Exception message: {ExceptionMessage}", nameof(InfrastructureDependencyInjection), ex.GetType().Name, ex.Message);
        }
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Connection string is null or empty.");
        
        return services
            .AddDbContext<DatabaseContext>(optionsBuilder 
                => optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsBuilder 
                    => sqlServerOptionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, string? secretKey, string? issuer, string? audience)
    {
        if (string.IsNullOrEmpty(secretKey))
            throw new InvalidOperationException("Secret key is null or empty.");
        
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        
        return services.AddAuthorization();
    }

    private static IServiceCollection AddCors(this IServiceCollection services, IConfiguration configuration)
    {
        var frontendUrl = configuration["Urls:Frontend"];
        
        if (frontendUrl is null)
            throw new InvalidOperationException("Missing frontend URL.");
        
        return services.AddCors(corsOptions =>
        {
            corsOptions.AddPolicy(
                nameof(Policy.AllowFrontend), 
                policyBuilder => policyBuilder.WithOrigins(frontendUrl).AllowAnyHeader().AllowAnyMethod());

            corsOptions.AddPolicy(
                nameof(Policy.AllowAny), 
                policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IMotherboardRepository, MotherboardRepository>()
            .AddScoped<ICpuRepository, CpuRepository>()
            .AddScoped<IGpuRepository, GpuRepository>()
            .AddScoped<IRamRepository, RamRepository>()
            .AddScoped<ISsdRepository, SsdRepository>()
            .AddScoped<IMonitorRepository, MonitorRepository>()
            .AddScoped<IShippingRepository, ShippingRepository>();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            // .AddScoped<IOrderService, OrderService>()
            // .AddScoped<IOwnershipService, OwnershipService>()
            // .AddScoped<IAuthenticationService, AuthenticationService>()
            .AddSingleton<ITokenService, TokenService>();
    }
}