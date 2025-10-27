using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IBrandProviderService
{
    List<string> GetBrands<TEntity>() where TEntity : ProductBase;
}