namespace Backend.Domain.Interfaces.Repositories.Generics;

public interface ICreatable<TEntity>
{
    Task<TEntity> CreateAsync(TEntity item, CancellationToken cancellationToken);
}