using System.Diagnostics;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class ReviewRepository(ILogger<ReviewRepository> logger, DatabaseContext context) : IReviewRepository
{
    private const string Source = nameof(ReviewRepository);
    
    public async Task<Review> CreateAsync(Review item, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Adding a new review entity...", Source);
        await context.Reviews.AddAsync(item, stoppingToken);
        await context.SaveChangesAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: Review entity created in {Duration}ms", Source, stopwatch.ElapsedMilliseconds);
        
        return await context.Reviews.Include(review => review.User).FirstAsync(review => review.Id == item.Id, stoppingToken);
    }

    public async Task<double> GetAverageRatingAsync(Guid productId)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Calculating the average reviews' rating for product with ProductId={ProductId}...", Source, productId);

        try
        {
            var average = await context.Reviews
                .Where(review => review.ProductId == productId)
                .AverageAsync(review => review.Rating);
            
            stopwatch.Stop();
            logger.LogInformation("[{Source}]: Average rating for product with ProductId={ProductId} is {AverageRating} Calculation done in {Duration}ms", Source, productId, average, stopwatch.ElapsedMilliseconds);

            return average;
        }
        catch (InvalidOperationException)
        {
            logger.LogInformation("[{Source}]: Product with ProductId={ProductId} has no reviews. Defaulting back to 0", Source, productId);
            return 0;
        }
    }
}