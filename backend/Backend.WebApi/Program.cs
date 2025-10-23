using System.Reflection;
using Backend.Application;
using Backend.Application.CQRS.Cpu.Queries;
using Backend.Application.CQRS.Shipping.Queries;
using Backend.Infrastructure;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Database.Seeder;
using Backend.WebApi.Middlewares;
using MediatR;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var serviceEnvironment = builder.Configuration["Environment"]!;
var serviceUrl = builder.Configuration["Urls:Http"]!;
var serviceName = Assembly.GetEntryAssembly()?.GetName().Name;
var serviceVersion = Assembly.GetEntryAssembly()?.GetName().Version;
var apiUrl = $"{serviceUrl}/api";
var swaggerUrl = $"{serviceUrl}/swagger/index.html";

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
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
app.UseCors((serviceEnvironment == "Development" ? Policy.AllowAny : Policy.AllowFrontend).ToString());
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseMiddleware<RequestDurationMiddleware>();
app.MapControllers();

app.MapGet("/", async (IMediator mediator) =>
{
    var res = await mediator.Send(new GetAllCpusQuery());
    
    
    return Results.Ok(res.Value);   
});

Log.Information("[{ServiceName}]: Configuring web host in {ServiceEnvironment} at version {ServiceVersion}...", serviceName, serviceEnvironment, serviceVersion);
Log.Information("[{ServiceName}]: Web host listening on: {ApiUrl}.", serviceName, apiUrl);
Log.Information("[{ServiceName}]: Swagger available on {SwaggerUrl}.", serviceName, swaggerUrl);

app.Run();