using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Filters;

public interface IBrandProviderService<TEntity> where TEntity : ProductBase
{
    List<string> Brands { get; }
}