using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Filters;

public abstract class FilterServiceBase<TEntity>(IBrandProviderService<TEntity> brandProviderService)
    : IFilterService<TEntity> where TEntity : ProductBase
{
    public abstract Filter<TEntity> BuildFilter(IDictionary<string, string> criteria);
    public abstract object Filters { get; }

    protected List<string> Brands => brandProviderService.Brands;
}