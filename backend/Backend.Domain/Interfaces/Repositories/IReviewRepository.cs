using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IReviewRepository : ICreatable<Review>
{
    Task<List<Review>> ListAllForProductAsync(Guid productId, CancellationToken ct = default);
}