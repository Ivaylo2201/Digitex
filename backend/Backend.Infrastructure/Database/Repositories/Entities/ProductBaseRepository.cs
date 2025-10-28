using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class ProductBaseRepository(ILogger<ProductBaseRepository> logger, DatabaseContext context) : IProductBaseRepository
{
    private const string Source = nameof(ProductBaseRepository);
    
    public async Task<Result> UpdateRatingAsync(Guid id, int newRating, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Updating rating of product with Id of {ProductId}...", Source, id);
        var product = await context.Products.FirstOrDefaultAsync(product => product.Id == id, stoppingToken);

        if (product is null)
            return Result.Failure(ErrorType.NotFound);
        
        product.Rating = newRating;
        await context.SaveChangesAsync(stoppingToken);
        return Result.Success();
    }
}