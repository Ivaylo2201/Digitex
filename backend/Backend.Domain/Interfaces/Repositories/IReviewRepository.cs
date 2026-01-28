using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IReviewRepository : ICreatable<Review>
{
    Task<List<Review>> GetRecentByProductIdAsync(Guid productId, int limit, CancellationToken cancellationToken);
}