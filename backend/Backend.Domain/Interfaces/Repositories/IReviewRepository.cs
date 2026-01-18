using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IReviewRepository : ICreatable<Review>
{
    Task<double> GetAverageRatingAsync(Guid productId);
}