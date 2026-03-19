using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IProductBaseRepository : ISingleReadable<ProductBase, Guid>
{
    Task<List<ProductBase>> GetFavoritesByUserIdAsync(int userId, CancellationToken cancellationToken);
    Task AddSuggestionAsync(Guid productId, Guid suggestedProductId, CancellationToken cancellationToken);
    Task RemoveSuggestionAsync(Guid productId, Guid suggestedProductId, CancellationToken cancellationToken);
    Task ReduceQuantityAsync(Guid productId, int quantity, CancellationToken cancellationToken);
    Task<List<ProductBase>> SearchAsync(string query, CancellationToken cancellationToken);
    Task<List<ProductBase>> GetSuggestionsProductsAsync(Guid productId, CancellationToken cancellationToken);
    Task<List<ProductBase>> GetSuggestedProductsAsync(Guid productId, CancellationToken cancellationToken);
    Task<ProductBase?> GetMostSoldProductAsync(CancellationToken cancellationToken);
}