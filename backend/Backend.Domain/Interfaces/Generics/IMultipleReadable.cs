namespace Backend.Domain.Interfaces.Generics;

public interface IMultipleReadable<TEntity>
{
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
}