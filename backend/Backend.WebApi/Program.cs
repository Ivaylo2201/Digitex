using System.Reflection;
using System.Text.Json.Serialization;
using Backend.Application;
using Backend.Application.Enums;
using Backend.Infrastructure;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Database.Seeder;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Extensions;
using Backend.WebApi.Middlewares;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var serviceName = Assembly.GetEntryAssembly()?.GetName().Name ?? "Backend.WebApi";
var serviceUrl = builder.Configuration.GetRequiredAppSettingsVariable("Urls:Backend");
var swaggerUrl = $"{serviceUrl}/swagger/index.html";

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.ConfigureHttpJsonOptions(options =>
    {
        options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
    })
    .AddOpenApi()
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                    { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
                []
            }
        });
    })
    .AddRouting(options => options.LowercaseUrls = true)
    .AddControllers();

builder.WebHost.UseUrls(serviceUrl);

builder.Host.UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (args.Contains("seed"))
{
    using var scope = app.Services.CreateScope();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Seeder>>();
    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    await new Seeder(logger, context).RunAsync();
    return;
}

app.UseRouting();
app.UseCors((app.Environment.IsDevelopment() ? Policy.AllowAny : Policy.AllowFrontend).ToString());
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseMiddleware<RequestPipelineMiddleware>();
app.UseGlobalExceptionHandler();
app.MapControllers();

Log.Information("[{ServiceName}]: Configuring web host in {ServiceEnvironment}...", serviceName, app.Environment.EnvironmentName);
Log.Information("[{ServiceName}]: Web host configured to listen on: {ApiUrl}.", serviceName, $"{serviceUrl}/api");
Log.Information("[{ServiceName}]: Swagger available on {SwaggerUrl}.", serviceName, swaggerUrl);

app.Run();