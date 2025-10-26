namespace Backend.Domain.Interfaces.Generics;

public interface IUpdatable<in TEntity>
{
    Task UpdateAsync(TEntity item, CancellationToken ct = default);
}