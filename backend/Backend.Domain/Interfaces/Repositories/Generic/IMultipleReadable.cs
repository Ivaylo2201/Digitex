namespace Backend.Domain.Interfaces.Repositories.Generic;

public interface IMultipleReadable<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
}