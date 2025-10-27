using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Common.Filters;

public class PowerSupplyFilterService(IBrandProviderService brandProviderService) : IFilterService<PowerSupply>
{
    public Filter<PowerSupply> BuildFilter(IDictionary<string, string> criteria)
    {
        return psu => psu;
    }

    public object GetFilters() => new
    {
        Brands = brandProviderService.GetBrands<PowerSupply>()
    };
}