using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Backend.Infrastructure.Database;

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
        
        var connectionString = configuration.GetConnectionString("DefaultConnection")!;
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(connectionString);

        return new DatabaseContext(optionsBuilder.Options);
    }
}