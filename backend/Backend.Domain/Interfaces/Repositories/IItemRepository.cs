using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IItemRepository : ICreatable<Item>, IDeletable<int>
{
    Task<Item?> GetOneByIdWithCartAsync(int itemId, CancellationToken cancellationToken);
    Task<Item?> GetOneByIdWithProductAsync(int itemId, CancellationToken cancellationToken);
    Task UpdateQuantityAsync(int itemId, int newQuantity, CancellationToken cancellationToken);
}