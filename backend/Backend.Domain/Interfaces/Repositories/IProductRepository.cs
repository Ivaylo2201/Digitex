using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IProductRepository<TProduct> : 
    ISingleReadable<TProduct, Guid>,
    ICreatable<TProduct>,
    IDeletable<Guid>,
    IUpdatable<TProduct, Guid> where TProduct : ProductBase
{ 
    Task<List<TProduct>> GetAllAsync(int page, int pageSize, IQueryable<TProduct> filter, CancellationToken cancellationToken);
    Task<int> CountAsync(IQueryable<TProduct> filter, CancellationToken cancellationToken);
    IQueryable<TProduct> Query();
}