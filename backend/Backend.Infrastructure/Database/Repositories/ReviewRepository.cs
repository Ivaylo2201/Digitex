using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ReviewRepository(DatabaseContext context) : IReviewRepository
{
    public async Task<Review> CreateAsync(Review review, CancellationToken stoppingToken = default)
    {
        var entity = (await context.Reviews.AddAsync(review, stoppingToken)).Entity;
        await context.SaveChangesAsync(stoppingToken);
        return entity;
    }

    public async Task<double> GetAverageRatingAsync(Guid productId)
        => await context.Reviews
            .Where(review => review.ProductId == productId)
            .AverageAsync(review => review.Rating);
}