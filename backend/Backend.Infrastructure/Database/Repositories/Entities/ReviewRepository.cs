using Backend.Domain.Entities;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class ReviewRepository : IReviewRepository
{
    public async Task<Review> CreateAsync(Review item, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}