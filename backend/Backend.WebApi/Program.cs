using System.Reflection;
using Backend.Application;
using Backend.Application.CQRS.Shipping.Queries;
using Backend.Infrastructure;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Database.Seeder;
using Backend.WebApi.Middlewares;
using Serilog;
using SimpleSoft.Mediator;

var builder = WebApplication.CreateBuilder(args);

var serviceName = Assembly.GetEntryAssembly()?.GetName().Name ?? "Backend.WebApi";
var serviceVersion = Assembly.GetEntryAssembly()?.GetName().Version ?? Version.Parse("1.0.0.0");
var serviceUrl = builder.Configuration["Urls:Backend"]!;
var swaggerUrl = $"{serviceUrl}/swagger/index.html";

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services
    .AddOpenApi()
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
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
app.UseStaticFiles();
app.UseMiddleware<RequestPipelineMiddleware>();
app.MapControllers();

app.MapGet("/{id:int}", async (int id, IMediator mediator, CancellationToken ct) =>
{
    var res = await mediator.FetchAsync(new GetShippingQuery { EntityId = id }, ct);
    return Results.Ok(res.Value);   
});

Log.Information("[{ServiceName}]: Configuring web host in {ServiceEnvironment} at version {ServiceVersion}...", serviceName, app.Environment.EnvironmentName, serviceVersion);
Log.Information("[{ServiceName}]: Web host listening on: {ApiUrl}.", serviceName, $"{serviceUrl}/api");
Log.Information("[{ServiceName}]: Swagger available on {SwaggerUrl}.", serviceName, swaggerUrl);

app.Run();