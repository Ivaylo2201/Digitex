using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using Backend.Application.Contracts.Filters;
using Backend.Application.Contracts.Product;
using Backend.Application.Contracts.Product.Variants;
using Backend.Application.DTOs;
using Backend.Application.Enums;
using Backend.Application.Interfaces.Http;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Settings;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Database.Repositories;
using Backend.Infrastructure.Database.Repositories.Products;
using Backend.Infrastructure.Extensions;
using Backend.Infrastructure.Http;
using Backend.Infrastructure.Services;
using Backend.Infrastructure.Services.FiltersProvider;
using Backend.Infrastructure.Services.Products;
using Backend.Infrastructure.Services.QueryBuilder;
using DotNetEnv;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Stripe;
using Monitor = Backend.Domain.Entities.Monitor;
using Price = Backend.Domain.ValueObjects.Price;
using TokenService = Backend.Infrastructure.Services.TokenService;

namespace Backend.Infrastructure;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration)
        {
            Env.Load();
            
            IServiceCollection.AddMaps();
        
            var env = new EnvSettings
            {
                Jwt = new JwtSettings
                {
                    SecretKey = "JWT__SECRET_KEY".GetRequiredEnvironmentVariable(),
                    Issuer = "JWT__ISSUER".GetRequiredEnvironmentVariable(),
                    Audience = "JWT__AUDIENCE".GetRequiredEnvironmentVariable()
                },
                Merchant = new MerchantSettings
                {
                    Email = "MERCHANT__EMAIL".GetRequiredEnvironmentVariable(),
                    Username = "MERCHANT__USERNAME".GetRequiredEnvironmentVariable()
                },
                Smtp = new SmtpSettings
                {
                    Provider = "SMTP__PROVIDER".GetRequiredEnvironmentVariable(),
                    Port = int.Parse("SMTP__PORT".GetRequiredEnvironmentVariable()),
                    AppPassword = "SMTP__APP_PASSWORD".GetRequiredEnvironmentVariable()
                },
                Cryptography = new CryptographySettings
                {
                    EncryptionKey = "CRYPTOGRAPHY__ENCRYPTION_KEY".GetRequiredEnvironmentVariable(),
                    InitializationVector = "CRYPTOGRAPHY__INITIALIZATION_VECTOR".GetRequiredEnvironmentVariable()
                },
                Stripe = new StripeSettings
                {
                    PublishableKey = "STRIPE__PUBLISHABLE_KEY".GetRequiredEnvironmentVariable(),
                    SecretKey = "STRIPE__SECRET_KEY".GetRequiredEnvironmentVariable(),
                    WebhookSecret = "STRIPE__WEBHOOK_SECRET".GetRequiredEnvironmentVariable()
                },
                Assistant = new AssistantSettings
                {
                    ApiKey = "ASSISTANT__API_KEY".GetRequiredEnvironmentVariable(),
                    ApiUrl = "ASSISTANT__API_URL".GetRequiredEnvironmentVariable()
                }
            };
        
            services.AddSingleton(Options.Create(env));
            StripeConfiguration.ApiKey = env.Stripe.SecretKey;

            return services
                .AddRepositories()
                .AddServices()
                .AddHttpClients(env)
                .AddEmailServices(env)
                .AddSecurity(configuration, env)
                .AddPersistence(configuration);
        }

        private IServiceCollection AddRepositories() => services
            .AddScoped<IProductRepository<Monitor>, MonitorRepository>()
            .AddScoped<IProductRepository<Ram>, RamRepository>()
            .AddScoped<IProductRepository<Processor>, ProcessorRepository>()
            .AddScoped<IProductRepository<GraphicsCard>, GraphicsCardRepository>()
            .AddScoped<IProductRepository<Ssd>, SsdRepository>()
            .AddScoped<IProductRepository<Motherboard>, MotherboardRepository>()
            .AddScoped<IProductRepository<PowerSupply>, PowerSupplyRepository>()
            .AddScoped<IReviewRepository, ReviewRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ICartRepository, CartRepository>()
            .AddScoped<IItemRepository, ItemRepository>()
            .AddScoped<IShipmentRepository, ShipmentRepository>()
            .AddScoped<IUserTokenRepository, UserTokenRepository>()
            .AddScoped<IExchangeRepository, ExchangeRepository>()
            .AddScoped<ICurrencyRepository, CurrencyRepository>()
            .AddScoped<IBrandRepository, BrandRepository>()
            .AddScoped<ICountryRepository, CountryRepository>()
            .AddScoped<ICityRepository, CityRepository>();

        private IServiceCollection AddServices() => services
            .AddScoped<IProductService<Monitor, MonitorProjection>, MonitorService>()
            .AddScoped<IProductService<Ram, RamProjection>, RamService>()
            .AddScoped<IProductService<Processor, ProcessorProjection>, ProcessorService>()
            .AddScoped<IProductService<GraphicsCard, GraphicsCardDto>, GraphicsCardService>()
            .AddScoped<IProductService<Ssd, SsdProjection>, SsdService>()
            .AddScoped<IProductService<Motherboard, MotherboardProjection>, MotherboardService>()
            .AddScoped<IProductService<PowerSupply, PowerSupplyProjection>, PowerSupplyService>()
            .AddScoped<ICurrencyService, CurrencyService>()
            .AddScoped<IFiltersProviderService<GraphicsCardFilters>, GraphicsCardFiltersProviderService>()
            .AddScoped<IFiltersProviderService<MonitorFilters>, MonitorFiltersProviderService>()
            .AddScoped<IFiltersProviderService<RamFilters>, RamFiltersProviderService>()
            .AddScoped<IFiltersProviderService<ProcessorFilters>, ProcessorFiltersProviderService>()
            .AddScoped<IFiltersProviderService<GraphicsCardFilters>, GraphicsCardFiltersProviderService>()
            .AddScoped<IFiltersProviderService<SsdFilters>, SsdFiltersProviderService>()
            .AddScoped<IFiltersProviderService<MotherboardFilters>, MotherboardFiltersProviderService>()
            .AddScoped<IFiltersProviderService<PowerSupplyFilters>, PowerSupplyFiltersProviderService>()
            .AddTransient<IQueryBuilderService<Monitor>, MonitorQueryBuilderService>()
            .AddTransient<IQueryBuilderService<Ram>, RamQueryBuilderService>()
            .AddTransient<IQueryBuilderService<Processor>, ProcessorQueryBuilderService>()
            .AddTransient<IQueryBuilderService<GraphicsCard>, GraphicsCardQueryBuilderService>()
            .AddTransient<IQueryBuilderService<Ssd>, SsdQueryBuilderService>()
            .AddTransient<IQueryBuilderService<Motherboard>, MotherboardQueryBuilderService>()
            .AddTransient<IQueryBuilderService<PowerSupply>, PowerSupplyQueryBuilderService>()
            .AddTransient<ITokenService, TokenService>()
            .AddSingleton<IUrlService, UrlService>()
            .AddSingleton<IJwtService, JwtService>();

        private IServiceCollection AddHttpClients(EnvSettings env)
        {
            services.AddHttpClient<IAssistantClient, AssistantClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(env.Assistant.ApiUrl);
                httpClient.Timeout = TimeSpan.FromSeconds(30);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", env.Assistant.ApiKey);
            });

            return services;
        }

        private IServiceCollection AddEmailServices(EnvSettings env)
        {
            services
                .AddScoped<IEmailSenderService, EmailSenderService>()
                .AddTransient<IEmailBuilderService, EmailBuilderService>()
                .AddFluentEmail(env.Merchant.Email, env.Merchant.Username)
                .AddSmtpSender(() => new SmtpClient(env.Smtp.Provider)
                {
                    Port = env.Smtp.Port,
                    Credentials = new NetworkCredential(env.Merchant.Email, env.Smtp.AppPassword),
                    EnableSsl = true
                });

            return services;
        }

        private IServiceCollection AddSecurity(IConfiguration configuration, EnvSettings env)
        {
            services
                .AddCors(corsOptions =>
                {
                    corsOptions.AddPolicy(nameof(Policy.AllowFrontend), policyBuilder =>
                    {
                        policyBuilder
                            .WithOrigins(configuration.GetRequiredAppSettingsVariable("Urls:Frontend"))
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });

                    corsOptions.AddPolicy(nameof(Policy.AllowAny), policyBuilder =>
                    {
                        policyBuilder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                })
                .AddAuthorization()
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
                        ValidIssuer = env.Jwt.Issuer,
                        ValidAudience = env.Jwt.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(env.Jwt.SecretKey))
                    };
                });
        
            return services;
        }

        private IServiceCollection AddPersistence(IConfiguration configuration)
        {
            return services.AddDbContext<DatabaseContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(
                    configuration.GetRequiredAppSettingsVariable("ConnectionStrings:DefaultConnection"),
                    sqlServerOptionsBuilder =>
                    {
                        sqlServerOptionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
            });
        }
        
        private static void AddMaps()
        {
            TypeAdapterConfig<ProductBase, ProductSummaryDto>.NewConfig()
                .Map(destination => destination.BrandName, source => source.Brand.BrandName)
                .Map(destination => destination.Price, source => new Price
                {
                    Initial = source.InitialPrice,
                    Discounted = source.Price
                })
                .Map(destination => destination.Quantity, source => source.Quantity);
            
            TypeAdapterConfig<Item, ItemDto>.NewConfig()
                .Map(destination => destination.Product, source => new ProductDto
                {
                    Sku = source.Product.Sku,
                    StockQuantity = source.Product.Quantity,
                    BrandName = source.Product.Brand.BrandName,
                    ModelName = source.Product.ModelName,
                    Price = source.Product.Price,
                    ImagePath = source.Product.ImagePath
                })
                .Map(destination => destination.LineTotal, source => source.Product.Price * source.Quantity);

            TypeAdapterConfig<ProductBase, ProductDetailsDto>.NewConfig().Inherits<ProductBase, ProductSummaryDto>()
                .Map(destination => destination.Sku, source => source.Sku.ToUpper())
                .Map(destination => destination.TotalReviews, source => source.Reviews.Count);
        
            TypeAdapterConfig<Processor, ProcessorProjection>.NewConfig().Inherits<ProductBase, ProductDetailsDto>();
            TypeAdapterConfig<GraphicsCard, GraphicsCardDto>.NewConfig().Inherits<ProductBase, ProductDetailsDto>();
            TypeAdapterConfig<Monitor, MonitorProjection>.NewConfig().Inherits<ProductBase, ProductDetailsDto>();
            TypeAdapterConfig<Motherboard, MotherboardProjection>.NewConfig().Inherits<ProductBase, ProductDetailsDto>();
            TypeAdapterConfig<PowerSupply, PowerSupplyProjection>.NewConfig().Inherits<ProductBase, ProductDetailsDto>();
            TypeAdapterConfig<Ram, RamProjection>.NewConfig().Inherits<ProductBase, ProductDetailsDto>();
            TypeAdapterConfig<Ssd, SsdProjection>.NewConfig().Inherits<ProductBase, ProductDetailsDto>();
        }
    }
}