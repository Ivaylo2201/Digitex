using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ReviewRepository(DatabaseContext context) : IReviewRepository
{
    public async Task<Review> CreateAsync(Review review, CancellationToken cancellationToken = default)
    {
        var entity = (await context.Reviews.AddAsync(review, cancellationToken)).Entity;
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Review>> GetRecentByProductIdAsync(Guid productId, int limit, CancellationToken cancellationToken = default)
        => await context.Reviews
            .AsNoTracking()
            .Include(review => review.User)
            .Where(review => review.ProductId == productId)
            .OrderByDescending(review => review.CreatedAt)
            .Take(limit)
            .ToListAsync(cancellationToken);
}