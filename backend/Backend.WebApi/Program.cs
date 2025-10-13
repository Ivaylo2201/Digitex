using Backend.Application;
using Backend.Infrastructure;
using Backend.Infrastructure.Common;

var builder = WebApplication.CreateBuilder(args);

var isInDevelopment = builder.Configuration["Environment"] == "Development";

builder.Services.AddControllers(o => o.Filters.Add<ExceptionFilter>());
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
app.UseCors((isInDevelopment ? Policy.AllowAny : Policy.AllowFrontend).ToString());
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.Run();