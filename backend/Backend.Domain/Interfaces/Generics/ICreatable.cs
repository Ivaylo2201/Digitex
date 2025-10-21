namespace Backend.Domain.Interfaces.Generics;

public interface ICreatable<TEntity>
{
    Task<TEntity> CreateAsync(TEntity item);
}