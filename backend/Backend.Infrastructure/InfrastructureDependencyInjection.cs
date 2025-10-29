using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using Backend.Application.DTOs.Cpu;
using Backend.Application.DTOs.Gpu;
using Backend.Application.DTOs.Monitor;
using Backend.Application.DTOs.Motherboard;
using Backend.Application.DTOs.PowerSupply;
using Backend.Application.DTOs.Ram;
using Backend.Application.DTOs.Ssd;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Database.Repositories.Entities;
using Backend.Infrastructure.Services.Common;
using Backend.Infrastructure.Services.Common.Filters;
using Backend.Infrastructure.Services.Entities;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Monitor = Backend.Domain.Entities.Monitor;
using MonitorService = Backend.Infrastructure.Services.Entities.MonitorService;

namespace Backend.Infrastructure;

public static class InfrastructureDependencyInjection
{
    private const string Source = nameof(InfrastructureDependencyInjection);
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            Env.Load();
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var jwtSecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            
            return services
                .AddDbContext(connectionString)
                .AddServices()
                .AddRepositories()
                .AddCors(configuration)
                .AddAuthentication(jwtSecretKey, jwtIssuer, jwtAudience);
        }
        catch (Exception ex)
        {
            Log.Error("[{Source}]: {ExceptionType} occurred while configuring DI for Infrastructure. Exception message: {ExceptionMessage}", Source, ex.GetType().Name, ex.Message);
            return services;
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
            .AddScoped<IProductRepository<Monitor>, MonitorRepository>()
            .AddScoped<IProductRepository<Ram>, RamRepository>()
            .AddScoped<IProductRepository<Cpu>, CpuRepository>()
            .AddScoped<IProductRepository<Gpu>, GpuRepository>()
            .AddScoped<IProductRepository<Ssd>, SsdRepository>()
            .AddScoped<IProductRepository<Motherboard>, MotherboardRepository>()
            .AddScoped<IProductRepository<PowerSupply>, PowerSupplyRepository>()
            .AddScoped<IReviewRepository, ReviewRepository>()
            .AddScoped<IProductBaseRepository, ProductBaseRepository>()
            .AddScoped<IUserRepository, UserRepository>();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        var email = Environment.GetEnvironmentVariable("SENDER_EMAIL");
        var password = Environment.GetEnvironmentVariable("SENDER_PASSWORD");
        var username = Environment.GetEnvironmentVariable("SENDER_USERNAME");

        return services
            .AddEmail(email, username, password)
            .AddScoped<IProductService<Monitor, MonitorDto>, MonitorService>()
            .AddScoped<IProductService<Ram, RamDto>, RamService>()
            .AddScoped<IProductService<Cpu, CpuDto>, CpuService>()
            .AddScoped<IProductService<Gpu, GpuDto>, GpuService>()
            .AddScoped<IProductService<Ssd, SsdDto>, SsdService>()
            .AddScoped<IProductService<Motherboard, MotherboardDto>, MotherboardService>()
            .AddScoped<IProductService<PowerSupply, PowerSupplyDto>, PowerSupplyService>()
            .AddScoped<IReviewService, ReviewService>()
            .AddScoped<IProductBaseService, ProductBaseService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IBrandProviderService, BrandProviderService>()
            .AddTransient<IFilterService<Monitor>, MonitorFilterService>()
            .AddTransient<IFilterService<Ram>, RamFilterService>()
            .AddTransient<IFilterService<Cpu>, CpuFilterService>()
            .AddTransient<IFilterService<Gpu>, GpuFilterService>()
            .AddTransient<IFilterService<Ssd>, SsdFilterService>()
            .AddTransient<IFilterService<Motherboard>, MotherboardFilterService>()
            .AddTransient<IFilterService<PowerSupply>, PowerSupplyFilterService>()
            .AddSingleton<ITokenService, TokenService>()
            .AddSingleton<IEmailCryptoService, EmailCryptoService>()
            .AddSingleton<IEmailSendingService, EmailSendingService>()
            .AddTransient(typeof(ICurrencyService<>), typeof(CurrencyService<>));
    }

    private static IServiceCollection AddEmail(this IServiceCollection services, string? email, string? username, string? password)
    {
        ArgumentNullException.ThrowIfNull(email);
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(password);
        
        services
            .AddFluentEmail(email, username)
            .AddSmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true
            });
        
        return services;
    }
}