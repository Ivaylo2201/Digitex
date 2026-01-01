using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using Backend.Application.Contracts.Cart.GetCart;
using Backend.Application.Contracts.Filters;
using Backend.Application.Contracts.Product;
using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Email;
using Backend.Application.Interfaces.FiltersProvider;
using Backend.Application.Interfaces.QueryBuilder;
using Backend.Application.Interfaces.Tokens;
using Backend.Domain.Entities;
using Backend.Domain.Exceptions;
using Backend.Domain.Interfaces;
using Backend.Domain.ValueObjects;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Database.Repositories;
using Backend.Infrastructure.Database.Repositories.Products;
using Backend.Infrastructure.Extensions;
using Backend.Infrastructure.Http;
using Backend.Infrastructure.Http.Interfaces;
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
using Monitor = Backend.Domain.Entities.Monitor;
using MonitorService = Backend.Infrastructure.Services.Products.MonitorService;

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
                
                IServiceCollection.AddMapsterConfigurations();

                services
                    .AddDbContext(configuration)
                    .AddRepositories()
                    .AddServices()
                    .AddHttp()
                    .AddCors(configuration)
                    .AddAuthentication();

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
                throw new ImproperlyConfiguredException("Connection string is null or empty.");

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
                    throw new ImproperlyConfiguredException("Frontend url is null or empty.");
                
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
            .AddScoped<IBrandRepository, BrandRepository>();

        private IServiceCollection AddServices() => services
            .AddEmail()
            .AddScoped<IChatbotService, ChatbotService>()
            .AddScoped<IProductService<Monitor, MonitorProjection>, MonitorService>()
            .AddScoped<IProductService<Ram, RamProjection>, RamService>()
            .AddScoped<IProductService<Processor, ProcessorProjection>, ProcessorService>()
            .AddScoped<IProductService<GraphicsCard, GraphicsCardProjection>, GraphicsCardService>()
            .AddScoped<IProductService<Ssd, SsdProjection>, SsdService>()
            .AddScoped<IProductService<Motherboard, MotherboardProjection>, MotherboardService>()
            .AddScoped<IProductService<PowerSupply, PowerSupplyProjection>, PowerSupplyService>()
            .AddScoped<IAuthenticationService, AuthenticationService>()
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IStripeService, StripeService>()
            .AddScoped<IShipmentService, ShipmentService>()
            .AddScoped<IEmailSenderService, EmailSenderService>()
            .AddScoped<ICurrencyService, CurrencyService>()
            .AddScoped<ICartService, CartService>()
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
            
            
            TypeAdapterConfig<Item, ItemProjection>.NewConfig()
                .Map(destination => destination.Product, source => new ProductProjection
                {
                    Sku = source.Product.Sku,
                    BrandName = source.Product.Brand.BrandName,
                    ModelName = source.Product.ModelName,
                    Price = source.Product.Price,
                    ImagePath = source.Product.ImagePath
                })
                .Map(destination => destination.LineTotal, source => source.Product.Price * source.Quantity);

            TypeAdapterConfig<ProductBase, ProductDetails>.NewConfig().Inherits<ProductBase, ProductSummary>()
                .Map(destination => destination.Sku, source => source.Sku.ToUpper())
                .Map(destination => destination.TotalReviews, source => source.Reviews.Count);
        
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
            var gmailAppPassword = "GMAIL_APP_PASSWORD".GetRequiredEnvironmentVariable();
            var username = "MERCHANT_USERNAME".GetRequiredEnvironmentVariable();
            var smtpProvider = "SMTP_PROVIDER".GetRequiredEnvironmentVariable();
            var smtpPort = int.Parse("SMTP_PORT".GetRequiredEnvironmentVariable());

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

        private IServiceCollection AddHttp()
        {
            const string chatbotClientBaseAddress = "https://apifreellm.com/api/chat";
            const int chatbotClientTimeoutInSeconds = 30;
            
            services.AddHttpClient<IChatbotClient, ChatbotClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(chatbotClientBaseAddress);
                httpClient.Timeout = TimeSpan.FromSeconds(chatbotClientTimeoutInSeconds);
            });

            return services;
        }
    }
}
