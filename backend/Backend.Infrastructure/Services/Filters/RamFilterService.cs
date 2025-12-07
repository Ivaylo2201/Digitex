using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Filters;

public class RamFilterService(IBrandProviderService brandProviderService) : FilterServiceBase<Ram>(brandProviderService)
{
    public override Filter<Ram> BuildFilter(IDictionary<string, string> criteria) => processor => processor;

    public override object GetFilters() => new
    {
        BaseFilters.Brands,
        BaseFilters.Price
    };
}