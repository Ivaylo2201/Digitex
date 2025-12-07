using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Filters;

public abstract class FilterServiceBase<TEntity>(IBrandProviderService brandProviderService)
    : IFilterService<TEntity> where TEntity : ProductBase
{
    public abstract Filter<TEntity> BuildFilter(IDictionary<string, string> criteria);
    public abstract object GetFilters();

    protected FilterBase BaseFilters => new(brandProviderService.GetBrands<TEntity>(), new Range<double>(1, 5000));
}