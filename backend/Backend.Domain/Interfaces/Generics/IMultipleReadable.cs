using Backend.Domain.Common;

namespace Backend.Domain.Interfaces.Generics;

public interface IMultipleReadable<TEntity>
{
    Task<List<TEntity>> ListAllAsync(Filter<TEntity>? filter = null, CancellationToken ct = default);
}