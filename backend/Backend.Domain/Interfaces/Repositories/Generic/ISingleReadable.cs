namespace Backend.Domain.Interfaces.Repositories.Generic;

public interface ISingleReadable<TEntity, in TIdentifier>
{
    Task<TEntity?> GetOneAsync(TIdentifier id);
}