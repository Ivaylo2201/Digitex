using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Filters;

public class PowerSupplyFilterService(IBrandProviderService<PowerSupply> brandProviderService) 
    : FilterServiceBase<PowerSupply>(brandProviderService)
{
    public override Filter<PowerSupply> BuildFilter(IDictionary<string, string> criteria) => filter => filter;

    public override object GetFilters() => new
    {
        BaseFilters.Brands
    };
}