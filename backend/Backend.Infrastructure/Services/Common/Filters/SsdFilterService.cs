using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Common.Filters;

public class SsdFilterService(IBrandProviderService brandProviderService) : IFilterService<Ssd>
{
    public Filter<Ssd> BuildFilter(IDictionary<string, string> criteria)
    {
        return ssd => ssd;
    }

    public object GetFilters() => new
    {
        Brands = brandProviderService.GetBrands<Ssd>()
    };
}