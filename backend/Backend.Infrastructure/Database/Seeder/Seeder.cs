using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Seeder;

public class Seeder(ILogger<Seeder> logger, DatabaseContext context)
{
    public async Task RunAsync()
    {
        try
        {
            TruncateTables();
            await ResetIndicesAsync();
            Seed();
            await ConfigureTriggersAsync();
            await context.SaveChangesAsync();
            
            logger.LogInformation("Seeding complete.");
        }
        catch (Exception ex)
        {
            var exceptionMessage = ex.InnerException?.Message ?? ex.Message;
            var exceptionType = ex.InnerException?.GetType().Name ?? ex.GetType().Name;
            
            logger.LogError("{ExceptionName} occurred while seeding the database. Exception message: {ExceptionMessage}", exceptionType, exceptionMessage);
        }
    }
    
    private void Seed()
    {
        logger.LogInformation("Seeding...");

        
        List<IEnumerable<ProductBase>> products =
        [
            Data.Gpus,
            Data.Cpus,
            Data.Monitors,
            Data.Rams,
            Data.Motherboards,
            Data.Ssds,
            Data.PowerSupplies
        ];
        
        products.ForEach(context.AddRange);
        
        context.Brands.AddRange(Data.Brands.Values);
        context.Shippings.AddRange(Data.Shippings);
        context.Countries.AddRange(Data.Countries.Values);
        context.Cities.AddRange(Data.Cities);
    }

    private void TruncateTables()
    {
        logger.LogInformation("Truncating tables...");
        
        context.Addresses.RemoveRange(context.Addresses);
        context.Items.RemoveRange(context.Items);
        context.Reviews.RemoveRange(context.Reviews);
        context.Carts.RemoveRange(context.Carts);
        context.Orders.RemoveRange(context.Orders);
        context.Products.RemoveRange(context.Products);
        context.Cpus.RemoveRange(context.Cpus);
        context.Gpus.RemoveRange(context.Gpus);
        context.Monitors.RemoveRange(context.Monitors);
        context.Motherboards.RemoveRange(context.Motherboards);
        context.PowerSupplies.RemoveRange(context.PowerSupplies);
        context.Rams.RemoveRange(context.Rams);
        context.Ssds.RemoveRange(context.Ssds);
        context.Products.RemoveRange(context.Products);
        context.Addresses.RemoveRange(context.Addresses);
        context.Cities.RemoveRange(context.Cities);
        context.Shippings.RemoveRange(context.Shippings);
        context.Users.RemoveRange(context.Users);
        context.Brands.RemoveRange(context.Brands);
        context.Cities.RemoveRange(context.Cities);
        context.Countries.RemoveRange(context.Countries);
    }

    private async Task ResetIndicesAsync()
    {
        logger.LogInformation("Resetting indices...");
        
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Addresses', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Cities', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Shippings', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Users', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Brands', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Carts', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Orders', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Items', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Reviews', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Cities', RESEED, 0);");
        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Countries', RESEED, 0);");
    }

    private async Task ConfigureTriggersAsync()
    {
        await context.Database.ExecuteSqlRawAsync(
            """
            IF OBJECT_ID('dbo.trg_update_product_rating', 'TR') IS NOT NULL
                DROP TRIGGER dbo.trg_update_product_rating;
            """);
        
        await context.Database.ExecuteSqlRawAsync(
            """
            CREATE TRIGGER trg_update_product_rating
            ON [dbo].Reviews
            AFTER INSERT
            AS
            BEGIN
                DECLARE @ProductId VARCHAR = (SELECT ProductId FROM INSERTED)
                UPDATE dbo.Products
                SET Rating = (SELECT AVG(Rating) FROM dbo.Reviews WHERE ProductId = @ProductId)
                WHERE Id = @ProductId
            END
            """);
    }
} 