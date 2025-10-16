using Backend.Application;
using Backend.Infrastructure;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Database.Seeder;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var isInDevelopment = builder.Configuration["Environment"] == "Development";

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Host.UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
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
app.UseCors((isInDevelopment ? Policy.AllowAny : Policy.AllowFrontend).ToString());
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.Run();