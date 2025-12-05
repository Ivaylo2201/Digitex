using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using Backend.Application.Dtos.GraphicsCards;
using Backend.Application.Dtos.Item;
using Backend.Application.Dtos.Monitor;
using Backend.Application.Dtos.Motherboard;
using Backend.Application.Dtos.PowerSupply;
using Backend.Application.Dtos.Processor;
using Backend.Application.Dtos.Product;
using Backend.Application.Dtos.Ram;
using Backend.Application.Dtos.Review;
using Backend.Application.Dtos.Ssd;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Exceptions;
using Backend.Domain.Interfaces;
using Backend.Domain.ValueObjects;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Database.Repositories.Entities;
using Backend.Infrastructure.Services.Common;
using Backend.Infrastructure.Services.Common.Filters;
using Backend.Infrastructure.Services.Entities;
using DotNetEnv;
using FluentEmail.Core;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Monitor = Backend.Domain.Entities.Monitor;
using MonitorService = Backend.Infrastructure.Services.Entities.MonitorService;

namespace Backend.Infrastructure;

public static class InfrastructureDependencyInjection
{
    private const string Source = nameof(InfrastructureDependencyInjection);

    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration)
        {
            try
            {
                Env.Load();
            
                var frontendUrl = configuration["Urls:Frontend"];
                var connectionString = configuration.GetConnectionString("DefaultConnection");
            
                if (frontendUrl is null)
                    throw new ImproperlyConfiguredException("Missing frontend url.");
                
                InfrastructureDependencyInjection.AddMapsterConfigurations();

                services
                    .AddDbContext(connectionString)
                    .AddServices(frontendUrl)
                    .AddRepositories()
                    .AddCors(frontendUrl)
                    .AddAuthentication();

                Log.Information("[{Source}]: Infrastructure services successfully initialized.", Source);
                return services;
            }
            catch (Exception ex)
            {
                var exceptionMessage = ex.InnerException?.Message ?? ex.Message;
                var exceptionType = ex.InnerException?.GetType().Name ?? ex.GetType().Name;
                
                Log.Error("[{Source}]: An {ExceptionType} occurred while configuring DI for Infrastructure. Exception message: {ExceptionMessage}", Source, exceptionType, exceptionMessage);
                return services;
            }
        }

        private IServiceCollection AddDbContext(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ImproperlyConfiguredException("Connection string is null or empty.");

            return services
                .AddDbContext<DatabaseContext>(optionsBuilder
                    => optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsBuilder
                        => sqlServerOptionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
        }

        private IServiceCollection AddAuthentication()
        {
            var jwtSecretKey = GetRequiredEnvironmentVariable<string>("JWT_SECRET_KEY");
            var jwtIssuer = GetRequiredEnvironmentVariable<string>("JWT_ISSUER");
            var jwtAudience = GetRequiredEnvironmentVariable<string>("JWT_AUDIENCE");

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
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

        private IServiceCollection AddCors(string frontendUrl)
        {
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

        private IServiceCollection AddRepositories()
        {
            return services
                .AddScoped<IProductRepository<Monitor>, MonitorRepository>()
                .AddScoped<IProductRepository<Ram>, RamRepository>()
                .AddScoped<IProductRepository<Processor>, ProcessorRepository>()
                .AddScoped<IProductRepository<GraphicsCard>, GraphicsCardRepository>()
                .AddScoped<IProductRepository<Ssd>, SsdRepository>()
                .AddScoped<IProductRepository<Motherboard>, MotherboardRepository>()
                .AddScoped<IProductRepository<PowerSupply>, PowerSupplyRepository>()
                .AddScoped<IReviewRepository, ReviewRepository>()
                .AddScoped<IProductBaseRepository, ProductBaseRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ICartRepository, CartRepository>()
                .AddScoped<IItemRepository, ItemRepository>()
                .AddScoped<IShippingRepository, ShippingRepository>()
                .AddScoped<IUserTokenRepository, UserTokenRepository>();
        }

        private IServiceCollection AddServices(string frontendUrl)
        {
            return services
                .AddEmail()
                .AddScoped<IProductService<Monitor, MonitorDto>, MonitorService>()
                .AddScoped<IProductService<Ram, RamDto>, RamService>()
                .AddScoped<IProductService<Processor, ProcessorDto>, ProcessorService>()
                .AddScoped<IProductService<GraphicsCard, GraphicsCardDto>, GraphicsCardService>()
                .AddScoped<IProductService<Ssd, SsdDto>, SsdService>()
                .AddScoped<IProductService<Motherboard, MotherboardDto>, MotherboardService>()
                .AddScoped<IProductService<PowerSupply, PowerSupplyDto>, PowerSupplyService>()
                .AddScoped<IReviewService, ReviewService>()
                .AddScoped<IProductBaseService, ProductBaseService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IBrandProviderService, BrandProviderService>()
                .AddScoped<IStripeService, StripeService>()
                .AddScoped<IEmailSendingService>(serviceProvider => new EmailSendingService(
                    serviceProvider.GetRequiredService<ILogger<EmailSendingService>>(),
                    serviceProvider.GetRequiredService<IFluentEmail>(),
                    serviceProvider.GetRequiredService<IEmailBuilderService>(),
                    frontendUrl))
                .AddScoped<ICartService, CartService>()
                .AddScoped<IItemService, ItemService>()
                .AddScoped<IShippingService, ShippingService>()
                .AddTransient<IEmailBuilderService, EmailBuilderService>()
                .AddTransient<ITokenService, TokenService>()
                .AddTransient<IFilterService<Monitor>, MonitorFilterService>()
                .AddTransient<IFilterService<Ram>, RamFilterService>()
                .AddTransient<IFilterService<Processor>, ProcessorFilterService>()
                .AddTransient<IFilterService<GraphicsCard>, GraphicsCardFilterService>()
                .AddTransient<IFilterService<Ssd>, SsdFilterService>()
                .AddTransient<IFilterService<Motherboard>, MotherboardFilterService>()
                .AddTransient<IFilterService<PowerSupply>, PowerSupplyFilterService>()
                .AddSingleton<IUrlService, UrlService>()
                .AddSingleton<IJwtService>(_ => new JwtService(
                    Encoding.UTF8.GetBytes(GetRequiredEnvironmentVariable<string>("JWT_SECRET_KEY")),
                    GetRequiredEnvironmentVariable<string>("JWT_ISSUER"),
                    GetRequiredEnvironmentVariable<string>("JWT_AUDIENCE")
                ));
        }

        private static void AddMapsterConfigurations()
        {
            TypeAdapterConfig<ProductBase, ProductShortDto>.NewConfig()
                .Map(destination => destination.BrandName, source => source.Brand.BrandName)
                .Map(destination => destination.Price, source => new Price
                {
                    Initial = source.InitialPrice,
                    Discounted = source.Price
                })
                .Map(destination => destination.Quantity, source => source.Quantity);

            TypeAdapterConfig<Item, ItemDto>.NewConfig()
                .Map(destination => destination.Product, source => new ProductItemDto
                {
                    Sku = source.Product.Sku,
                    BrandName = source.Product.Brand.BrandName,
                    ModelName = source.Product.ModelName,
                    Price = source.Product.Price,
                    ImagePath = source.Product.ImagePath
                })
                .Map(destination => destination.Price, source => source.Product.Price * source.Quantity);

            TypeAdapterConfig<ProductBase, ProductLongDto>.NewConfig().Inherits<ProductBase, ProductShortDto>()
                .Map(destination => destination.Sku, source => source.Sku.ToUpper())
                .Map(destination => destination.TotalReviews, source => source.Reviews.Count)
                .Map(destination => destination.RecentReviews, source => source.Reviews
                    .OrderByDescending(r => r.CreatedAt)
                    .Take(25)
                    .Adapt<List<ReviewDto>>())
                .Map(destination => destination.SuggestedProducts,
                    source => source.Suggestions.Select(suggestion => suggestion.ToSuggestionDto()));
        
            TypeAdapterConfig<Processor, ProcessorDto>.NewConfig().Inherits<ProductBase, ProductLongDto>();
            TypeAdapterConfig<GraphicsCard, GraphicsCardDto>.NewConfig().Inherits<ProductBase, ProductLongDto>();
            TypeAdapterConfig<Monitor, MonitorDto>.NewConfig().Inherits<ProductBase, ProductLongDto>();
            TypeAdapterConfig<Motherboard, MotherboardDto>.NewConfig().Inherits<ProductBase, ProductLongDto>();
            TypeAdapterConfig<PowerSupply, PowerSupplyDto>.NewConfig().Inherits<ProductBase, ProductLongDto>();
            TypeAdapterConfig<Ram, RamDto>.NewConfig().Inherits<ProductBase, ProductLongDto>();
            TypeAdapterConfig<Ssd, SsdDto>.NewConfig().Inherits<ProductBase, ProductLongDto>();
        }

        private IServiceCollection AddEmail()
        {
            var email = GetRequiredEnvironmentVariable<string>("MERCHANT_EMAIL");
            var gmailAppPassword = GetRequiredEnvironmentVariable<string>("GMAIL_APP_PASSWORD");
            var username = GetRequiredEnvironmentVariable<string>("MERCHANT_USERNAME");
            var smtpProvider = GetRequiredEnvironmentVariable<string>("SMTP_PROVIDER");
            var smtpPort = GetRequiredEnvironmentVariable<int>("SMTP_PORT");

            services
                .AddFluentEmail(email, username)
                .AddSmtpSender(() => new SmtpClient(smtpProvider)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(email, gmailAppPassword),
                    EnableSsl = true
                });

            return services;
        }
    }

    private static T GetRequiredEnvironmentVariable<T>(string variableName)
    {
        var variable = Environment.GetEnvironmentVariable(variableName);

        if (string.IsNullOrEmpty(variable))
            throw new ImproperlyConfiguredException($"Missing {variableName}.");

        return (T)Convert.ChangeType(variable, typeof(T));
    }
}
