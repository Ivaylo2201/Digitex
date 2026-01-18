using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using Backend.Application.Contracts.Filters;
using Backend.Application.Contracts.Product;
using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Extensions;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Email;
using Backend.Application.Interfaces.FiltersProvider;
using Backend.Application.Interfaces.QueryBuilder;
using Backend.Application.Interfaces.Tokens;
using Backend.Domain.Entities;
using Backend.Domain.Exceptions;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Database.Repositories;
using Backend.Infrastructure.Database.Repositories.Products;
using Backend.Infrastructure.Http;
using Backend.Infrastructure.Services;
using Backend.Infrastructure.Services.Email;
using Backend.Infrastructure.Services.FiltersProvider;
using Backend.Infrastructure.Services.Products;
using Backend.Infrastructure.Services.QueryBuilder;
using Backend.Infrastructure.Services.Tokens;
using DotNetEnv;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Stripe;
using Monitor = Backend.Domain.Entities.Monitor;
using MonitorService = Backend.Infrastructure.Services.Products.MonitorService;
using Price = Backend.Domain.ValueObjects.Price;
using TokenService = Backend.Infrastructure.Services.Tokens.TokenService;

namespace Backend.Infrastructure;

public static class DependencyInjection
{
    private const string Source = nameof(DependencyInjection);

    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration)
        {
            try
            {
                Env.Load();
                
                IServiceCollection.AddMapsterConfigurations();

                services
                    .AddDbContext(configuration)
                    .AddRepositories()
                    .AddServices()
                    .AddHttpClient()
                    .AddCors(configuration)
                    .AddAuthentication()
                    .AddHttpClients()
                    .AddStripe();

                Log.Information("[{Source}]: Infrastructure layer successfully initialized.", Source);
                return services;
            }
            catch (Exception ex)
            {
                var exceptionMessage = ex.InnerException?.Message ?? ex.Message;
                var exceptionType = ex.InnerException?.GetType().Name ?? ex.GetType().Name;
                
                Log.Error("[{Source}]: An {ExceptionType} occurred while configuring the Infrastructure layer. Exception message: {ExceptionMessage}", Source, exceptionType, exceptionMessage);
                return services;
            }
        }

        private IServiceCollection AddDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            if (string.IsNullOrEmpty(connectionString))
                throw new ImproperlyConfiguredException(nameof(connectionString));

            return services
                .AddDbContext<DatabaseContext>(optionsBuilder
                    => optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsBuilder
                        => sqlServerOptionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
        }

        private IServiceCollection AddAuthentication()
        {
            var jwtSecretKey = "JWT_SECRET_KEY".GetRequiredEnvironmentVariable();
            var jwtIssuer = "JWT_ISSUER".GetRequiredEnvironmentVariable();
            var jwtAudience = "JWT_AUDIENCE".GetRequiredEnvironmentVariable();

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

        private IServiceCollection AddCors(IConfiguration configuration) => services
            .AddCors(corsOptions =>
            {
                var frontendUrl = configuration["Urls:Frontend"];
                
                if (string.IsNullOrEmpty(frontendUrl))
                    throw new ImproperlyConfiguredException(nameof(frontendUrl));
                
                corsOptions.AddPolicy(
                    nameof(Policy.AllowFrontend),
                    policyBuilder => policyBuilder.WithOrigins(frontendUrl).AllowAnyHeader().AllowAnyMethod());

                corsOptions.AddPolicy(
                    nameof(Policy.AllowAny),
                    policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

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
            .AddEmail()
            .AddScoped<IProductService<Monitor, MonitorProjection>, MonitorService>()
            .AddScoped<IProductService<Ram, RamProjection>, RamService>()
            .AddScoped<IProductService<Processor, ProcessorProjection>, ProcessorService>()
            .AddScoped<IProductService<GraphicsCard, GraphicsCardProjection>, GraphicsCardService>()
            .AddScoped<IProductService<Ssd, SsdProjection>, SsdService>()
            .AddScoped<IProductService<Motherboard, MotherboardProjection>, MotherboardService>()
            .AddScoped<IProductService<PowerSupply, PowerSupplyProjection>, PowerSupplyService>()
            .AddScoped<IEmailSenderService, EmailSenderService>()
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
            .AddTransient<IEmailBuilderService, EmailBuilderService>()
            .AddTransient<ITokenService, TokenService>()
            .AddSingleton<IUrlService, UrlService>()
            .AddSingleton<IJwtService, JwtService>();

        private static void AddMapsterConfigurations()
        {
            TypeAdapterConfig<ProductBase, ProductSummary>.NewConfig()
                .Map(destination => destination.BrandName, source => source.Brand.BrandName)
                .Map(destination => destination.Price, source => new Price
                {
                    Initial = source.InitialPrice,
                    Discounted = source.Price
                })
                .Map(destination => destination.Quantity, source => source.Quantity);
        
            TypeAdapterConfig<Processor, ProcessorProjection>.NewConfig().Inherits<ProductBase, ProductDetails>();
            TypeAdapterConfig<GraphicsCard, GraphicsCardProjection>.NewConfig().Inherits<ProductBase, ProductDetails>();
            TypeAdapterConfig<Monitor, MonitorProjection>.NewConfig().Inherits<ProductBase, ProductDetails>();
            TypeAdapterConfig<Motherboard, MotherboardProjection>.NewConfig().Inherits<ProductBase, ProductDetails>();
            TypeAdapterConfig<PowerSupply, PowerSupplyProjection>.NewConfig().Inherits<ProductBase, ProductDetails>();
            TypeAdapterConfig<Ram, RamProjection>.NewConfig().Inherits<ProductBase, ProductDetails>();
            TypeAdapterConfig<Ssd, SsdProjection>.NewConfig().Inherits<ProductBase, ProductDetails>();
        }

        private IServiceCollection AddEmail()
        {
            var email = "MERCHANT_EMAIL".GetRequiredEnvironmentVariable();
            var username = "MERCHANT_USERNAME".GetRequiredEnvironmentVariable();

            services
                .AddFluentEmail(email, username)
                .AddSmtpSender(() => new SmtpClient("SMTP_PROVIDER".GetRequiredEnvironmentVariable())
                {
                    Port = int.Parse("SMTP_PORT".GetRequiredEnvironmentVariable()),
                    Credentials = new NetworkCredential(email, "GMAIL_APP_PASSWORD".GetRequiredEnvironmentVariable()),
                    EnableSsl = true
                });

            return services;
        }

        private IServiceCollection AddHttpClients()
        {
            services.AddHttpClient<IAssistantClient, AssistantClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("ASSISTANT_API_URL".GetRequiredEnvironmentVariable());
                httpClient.Timeout = TimeSpan.FromSeconds(30);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    "ASSISTANT_API_KEY".GetRequiredEnvironmentVariable());
            });

            return services;
        }

        private IServiceCollection AddStripe()
        {
            StripeConfiguration.ApiKey = "STRIPE_SECRET_KEY".GetRequiredEnvironmentVariable();
            return services;
        }
    }
}
