using Backend.Domain.Entities;
using Backend.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Seeder;

public class Seeder(ILogger<Seeder> logger, DatabaseContext context)
{
    private const string Source = nameof(Seeder);
    
    public async Task RunAsync()
    {
        try
        {
            await TruncateTables();
            await ResetIndicesAsync();
            Seed();
            await context.SaveChangesAsync();
            
            logger.LogInformation("Database seeding complete.");
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, "seeding the database");
        }
    }
    
    private void Seed()
    {
        logger.LogInformation("Seeding the database...");

        
        List<IEnumerable<ProductBase>> products =
        [
            Data.GraphicsCards,
            Data.Processors,
            Data.Monitors,
            Data.Rams,
            Data.Motherboards,
            Data.Ssds,
            Data.PowerSupplies
        ];
        
        products.ForEach(context.AddRange);
        
        context.Brands.AddRange(Data.Brands.Values);
        context.Shipments.AddRange(Data.Shipments);
        context.Countries.AddRange(Data.Countries.Values);
        context.Cities.AddRange(Data.Cities);
    }

    private async Task TruncateTables()
    {
        logger.LogInformation("Truncating tables...");
        
        await context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Suggestions;");
        await context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Wishlist;");
        
        context.UserTokens.RemoveRange(context.UserTokens);
        context.Addresses.RemoveRange(context.Addresses);
        context.Items.RemoveRange(context.Items);
        context.Reviews.RemoveRange(context.Reviews);
        context.Carts.RemoveRange(context.Carts);
        context.Orders.RemoveRange(context.Orders);
        context.Products.RemoveRange(context.Products);
        context.Processors.RemoveRange(context.Processors);
        context.GraphicsCards.RemoveRange(context.GraphicsCards);
        context.Monitors.RemoveRange(context.Monitors);
        context.Motherboards.RemoveRange(context.Motherboards);
        context.PowerSupplies.RemoveRange(context.PowerSupplies);
        context.Rams.RemoveRange(context.Rams);
        context.Ssds.RemoveRange(context.Ssds);
        context.Products.RemoveRange(context.Products);
        context.Addresses.RemoveRange(context.Addresses);
        context.Cities.RemoveRange(context.Cities);
        context.Shipments.RemoveRange(context.Shipments);
        context.Users.RemoveRange(context.Users);
        context.Brands.RemoveRange(context.Brands);
        context.Cities.RemoveRange(context.Cities);
        context.Countries.RemoveRange(context.Countries);
        context.Payments.RemoveRange(context.Payments);
        context.Sales.RemoveRange(context.Sales);
    }

    private async Task ResetIndicesAsync()
    {
        logger.LogInformation("Resetting indices...");
        
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Addresses', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Cities', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Shipments', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Users', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Brands', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Carts', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Orders', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Items', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Reviews', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Cities', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Countries', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('UserTokens', RESEED, 0);");
    }
} 