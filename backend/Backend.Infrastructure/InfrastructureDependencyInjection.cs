using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using Backend.Application.DTOs.Cpu;
using Backend.Application.DTOs.Gpu;
using Backend.Application.DTOs.Item;
using Backend.Application.DTOs.Monitor;
using Backend.Application.DTOs.Motherboard;
using Backend.Application.DTOs.PowerSupply;
using Backend.Application.DTOs.Product;
using Backend.Application.DTOs.Ram;
using Backend.Application.DTOs.Review;
using Backend.Application.DTOs.Shipping;
using Backend.Application.DTOs.Ssd;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.ValueObjects;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Database.Repositories.Entities;
using Backend.Infrastructure.Services.Common;
using Backend.Infrastructure.Services.Common.Filters;
using Backend.Infrastructure.Services.Entities;
using DotNetEnv;
using Mapster;
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

            services
                .AddDbContext(configuration.GetConnectionString("DefaultConnection"))
                .AddServices()
                .AddRepositories()
                .AddCors(configuration["Urls:Frontend"])
                .AddAuthentication()
                .AddMapsterConfigurations();
            
            Log.Information("[{Source}]: Infrastructure services successfully initialized.", Source);
            return services;
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

    private static IServiceCollection AddAuthentication(this IServiceCollection services)
    {
        var jwtSecretKey = GetRequiredEnvironmentVariable<string>("JWT_SECRET_KEY");
        var jwtIssuer =  GetRequiredEnvironmentVariable<string>("JWT_ISSUER");
        var jwtAudience = GetRequiredEnvironmentVariable<string>("JWT_AUDIENCE");
        
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
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey))
                };
            });
        
        return services.AddAuthorization();
    }

    private static IServiceCollection AddCors(this IServiceCollection services, string? frontendUrl)
    {
        if (frontendUrl is null)
            throw new InvalidOperationException("Missing frontend url.");
        
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
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ICartRepository, CartRepository>()
            .AddScoped<IItemRepository, ItemRepository>();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {

        return services
            .AddEmail()
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
            .AddScoped<IEmailSendingService, EmailSendingService>()
            .AddScoped<ICartService, CartService>()
            .AddScoped<IItemService, ItemService>()
            .AddTransient<IFilterService<Monitor>, MonitorFilterService>()
            .AddTransient<IFilterService<Ram>, RamFilterService>()
            .AddTransient<IFilterService<Cpu>, CpuFilterService>()
            .AddTransient<IFilterService<Gpu>, GpuFilterService>()
            .AddTransient<IFilterService<Ssd>, SsdFilterService>()
            .AddTransient<IFilterService<Motherboard>, MotherboardFilterService>()
            .AddTransient<IFilterService<PowerSupply>, PowerSupplyFilterService>()
            .AddSingleton<ITokenService, TokenService>()
            .AddSingleton<IEmailCryptoService, EmailCryptoService>();
    }

    private static IServiceCollection AddMapsterConfigurations(this IServiceCollection services)
    {
        TypeAdapterConfig<ProductBase, ProductShortDto>.NewConfig()
            .Map(dest => dest.BrandName, src => src.Brand.BrandName)
            .Map(dest => dest.Price, src => new Price
            {
                Initial = src.InitialPrice,
                Discounted = src.Price
            })
            .Map(dest => dest.IsTop, src => src.Rating >= 4);

        TypeAdapterConfig<ProductBase, ProductLongDto>.NewConfig()
            .Inherits<ProductBase, ProductShortDto>()
            .Map(dest => dest.Reviews, src => src.Reviews
                .OrderByDescending(r => r.CreatedAt)
                .Take(10)
                .Adapt<IEnumerable<ReviewDto>>());
        
        TypeAdapterConfig<Item, ItemDto>.NewConfig()
            .Map(dest => dest.Product, src => new ProductItemDto
            {
                Sku = src.Product.Sku,
                BrandName = src.Product.Brand.BrandName,
                ModelName = src.Product.ModelName,
                Price = src.Product.Price,
                ImagePath = src.Product.ImagePath
            })
            .Map(dest => dest.Price, src => src.Product.Price * src.Quantity);
        
        TypeAdapterConfig<Cpu, CpuDto>.NewConfig()
            .Inherits<ProductBase, ProductLongDto>()
            .Map(dest => dest.Cores, src => src.Cores)
            .Map(dest => dest.Threads, src => src.Threads)
            .Map(dest => dest.ClockSpeed, src => src.ClockSpeed)
            .Map(dest => dest.Socket, src => src.Socket)
            .Map(dest => dest.Tdp, src => src.Tdp);
        
        TypeAdapterConfig<Gpu, GpuDto>.NewConfig()
            .Inherits<ProductBase, ProductLongDto>()
            .Map(dest => dest.Memory, src => src.Memory)
            .Map(dest => dest.ClockSpeed, src => src.ClockSpeed)
            .Map(dest => dest.BusWidth, src => src.BusWidth)
            .Map(dest => dest.CudaCores, src => src.CudaCores)
            .Map(dest => dest.DirectXSupport, src => src.DirectXSupport)
            .Map(dest => dest.Tdp, src => src.Tdp);
        
        TypeAdapterConfig<Monitor, MonitorDto>.NewConfig()
            .Inherits<ProductBase, ProductLongDto>()
            .Map(dest => dest.DisplayDiagonal, src => src.DisplayDiagonal)
            .Map(dest => dest.RefreshRate, src => src.RefreshRate)
            .Map(dest => dest.Latency, src => src.Latency)
            .Map(dest => dest.Matrix, src => src.Matrix)
            .Map(dest => dest.Resolution, src => src.Resolution)
            .Map(dest => dest.PixelSize, src => src.PixelSize)
            .Map(dest => dest.Brightness, src => src.Brightness)
            .Map(dest => dest.ColorSpectre, src => src.ColorSpectre);
        
        TypeAdapterConfig<Motherboard, MotherboardDto>.NewConfig()
            .Inherits<ProductBase, ProductLongDto>()
            .Map(dest => dest.Socket, src => src.Socket)
            .Map(dest => dest.FormFactor, src => src.FormFactor)
            .Map(dest => dest.Chipset, src => src.Chipset)
            .Map(dest => dest.RamSlots, src => src.RamSlots)
            .Map(dest => dest.PcieSlots, src => src.PcieSlots);

        TypeAdapterConfig<PowerSupply, PowerSupplyDto>.NewConfig()
            .Inherits<ProductBase, ProductLongDto>()
            .Map(dest => dest.Wattage, src => src.Wattage)
            .Map(dest => dest.FormFactor, src => src.FormFactor)
            .Map(dest => dest.EfficiencyPercentage, src => src.EfficiencyPercentage)
            .Map(dest => dest.Modularity, src => src.Modularity);
        
        TypeAdapterConfig<Ram, RamDto>.NewConfig()
            .Inherits<ProductBase, ProductLongDto>()
            .Map(dest => dest.Memory, src => src.Memory)
            .Map(dest => dest.Timing, src => src.Timing);
        
        TypeAdapterConfig<Ssd, SsdDto>.NewConfig()
            .Inherits<ProductBase, ProductLongDto>()
            .Map(dest => dest.CapacityInGb, src => src.CapacityInGb)
            .Map(dest => dest.OperationSpeed, src => src.OperationSpeed)
            .Map(dest => dest.Interface, src => src.Interface);
        
        TypeAdapterConfig<Review, ReviewDto>.NewConfig()
            .Map(dest => dest.Rating, src => src.Rating)
            .Map(dest => dest.Comment, src => src.Comment)
            .Map(dest => dest.Username, src => src.User.Username)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt);
        
        TypeAdapterConfig<Shipping, ShippingDto>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.ShippingType, src => src.ShippingType)
            .Map(dest => dest.Cost, src => src.Cost)
            .Map(dest => dest.Days, src => src.Days);
        
        return services;
    }

    private static IServiceCollection AddEmail(this IServiceCollection services)
    {
        var email = GetRequiredEnvironmentVariable<string>("SENDER_EMAIL");
        var password = GetRequiredEnvironmentVariable<string>("SENDER_PASSWORD");
        var username = GetRequiredEnvironmentVariable<string>("SENDER_USERNAME");
        var smtpProvider = GetRequiredEnvironmentVariable<string>("SMTP_PROVIDER");
        var smtpPort = GetRequiredEnvironmentVariable<int>("SMTP_PORT");
        
        services
            .AddFluentEmail(email, username)
            .AddSmtpSender(() => new SmtpClient(smtpProvider)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true
            });
        
        return services;
    }

    private static T GetRequiredEnvironmentVariable<T>(string variableName)
    {
        var variable = Environment.GetEnvironmentVariable(variableName);
        
        if (string.IsNullOrEmpty(variable))
            throw new InvalidOperationException($"Missing {variableName}.");
        
        return (T)Convert.ChangeType(variable, typeof(T));
    }
}