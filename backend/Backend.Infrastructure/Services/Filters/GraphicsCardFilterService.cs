using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Filters;

public class GraphicsCardFilterService(IBrandProviderService<GraphicsCard> brandProviderService) 
    : FilterServiceBase<GraphicsCard>(brandProviderService)
{
    public override Filter<GraphicsCard> BuildFilter(IDictionary<string, string> criteria) => filter => filter;

    public override object GetFilters() => new
    {
        BaseFilters.Brands,
        BaseFilters.Price
    };
}