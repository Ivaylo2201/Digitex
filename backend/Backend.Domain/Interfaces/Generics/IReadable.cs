namespace Backend.Domain.Interfaces.Generics;

public interface IReadable<TEntity, in TKey>
{
    Task<IEnumerable<TEntity>> ListAllAsync();
    Task<TEntity?> GetOneAsync(TKey id);
}