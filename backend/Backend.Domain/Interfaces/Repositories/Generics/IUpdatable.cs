namespace Backend.Domain.Interfaces.Repositories.Generics;

public interface IUpdatable<in TEntity, in TKey>
{
    Task UpdateAsync(TKey id, TEntity item, CancellationToken cancellationToken);
}