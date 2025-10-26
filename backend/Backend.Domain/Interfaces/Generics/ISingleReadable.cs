using Backend.Domain.Common;

namespace Backend.Domain.Interfaces.Generics;

public interface ISingleReadable<TEntity, in TKey>
{
    Task<TEntity?> GetOneAsync(TKey id, IncludeQuery<TEntity>? include, CancellationToken ct = default);
}