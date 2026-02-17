using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IProductBaseRepository : ISingleReadable<ProductBase, Guid>
{
    Task<List<ProductBase>> GetFavoritesByUserIdAsync(int userId, CancellationToken cancellationToken);
    Task AddSuggestionAsync(Guid productId, string suggestedProductSku, CancellationToken cancellationToken);
    Task RemoveSuggestionAsync(Guid productId, string suggestedProductSku, CancellationToken cancellationToken);
}