using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IProductRepository<TEntity> : ISingleReadable<TEntity, Guid>, IMultipleReadable<TEntity>
{
    IQueryable<TEntity> GetContextSet();
}