namespace Backend.Domain.Interfaces.Repositories.Generics;

public interface IMultipleReadable<TEntity>
{
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
}