using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class ProductBaseRepository(ILogger<ProductBaseRepository> logger, DatabaseContext context) : IProductBaseRepository
{
    private const string Source = nameof(ProductBaseRepository);
    
    public async Task UpdateRatingAsync(Guid id, int newRating, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Updating rating of product with Id of {ProductId}...", Source, id);
        var product = await context.Products.FirstOrDefaultAsync(product => product.Id == id, stoppingToken);

        if (product is null)
            return;
        
        product.Rating = newRating;
        await context.SaveChangesAsync(stoppingToken);
    }

    public async Task DecreaseQuantityAsync(Guid id, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Decreasing quantity of product with Id of {ProductId}...", Source, id);
        var product = await context.Products.FirstOrDefaultAsync(product => product.Id == id, stoppingToken);

        if (product is null)
            return;

        product.Quantity -= 1;
        await context.SaveChangesAsync(stoppingToken);
    }

    public async Task<bool> IsInStockAsync(Guid id, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Checking if product with Id of {ProductId} is in stock", Source, id);
        var product = await context.Products.FirstOrDefaultAsync(product => product.Id == id, stoppingToken);

        return product?.IsInStock ?? false;
    }

    public async Task<bool> AddSuggestionAsync(Guid productId, Guid suggestedProductId, CancellationToken stoppingToken = default)
    {
        var currentProduct = await context.Products
            .Include(product => product.Suggestions)
            .FirstOrDefaultAsync(product => product.Id == productId, stoppingToken);
        
        var suggestedProduct = await context.Products
            .Include(product => product.Suggestions)
            .FirstOrDefaultAsync(product => product.Id == suggestedProductId, stoppingToken);
        
        if (currentProduct is null || suggestedProduct is null)
            return false;
        
        if (!currentProduct.Suggestions.Contains(suggestedProduct))
            currentProduct.Suggestions.Add(suggestedProduct);

        if (!suggestedProduct.Suggestions.Contains(currentProduct))
            suggestedProduct.Suggestions.Add(currentProduct);

        await context.SaveChangesAsync(stoppingToken);
        return true;
    }
}