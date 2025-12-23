using Backend.Application.Interfaces.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Filters;

public abstract class FilterServiceBase<TEntity, TFilters>(IBrandProviderService<TEntity> brandProviderService)
    : IFilterService<TEntity, TFilters> where TEntity : ProductBase
{
    public abstract Filter<TEntity> BuildFilter(IDictionary<string, string> criteria);
    public abstract TFilters Filters { get; }

    protected List<string> Brands => brandProviderService.Brands;
}