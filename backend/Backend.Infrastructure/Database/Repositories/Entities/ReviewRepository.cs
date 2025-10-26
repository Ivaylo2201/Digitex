using System.Diagnostics;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class ReviewRepository(ILogger<ReviewRepository> logger, DatabaseContext context) : IReviewRepository
{
    private const string Source = nameof(ReviewRepository);
    
    public async Task<Review> CreateAsync(Review review, CancellationToken ct = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        await context.Reviews.AddAsync(review, ct);
        await context.SaveChangesAsync(ct);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: Review entity for ProductId={ProductId} with Rating={Rating} created in {Duration}ms.", Source, review.ProductId, review.Rating, stopwatch.ElapsedMilliseconds);
        return review;
    }

    public async Task<List<Review>> ListAllForProductAsync(Guid productId, CancellationToken ct = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Retrieving all Review entities for ProductId={ProductId}", Source, productId);
        
        var reviews = await context.Reviews
            .AsNoTracking()
            .Include(review => review.User)
            .Where(review => review.ProductId == productId)
            .ToListAsync(ct);
        
        stopwatch.Stop();
        
        logger.LogInformation("[{Source}]: Retrieved {Count} Review entities for ProductId={ProductId} in {Duration}ms.", Source, reviews.Count, productId, stopwatch.ElapsedMilliseconds);
        return reviews;
    }
}