using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IBrandProviderService<TEntity> where TEntity : ProductBase
{
    List<string> Brands { get; }
}