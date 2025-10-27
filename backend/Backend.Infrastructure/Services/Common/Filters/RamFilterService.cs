using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Common.Filters;

public class RamFilterService(IBrandProviderService brandProviderService) : IFilterService<Ram>
{
    public Filter<Ram> BuildFilter(IDictionary<string, string> criteria)
    {
        return ram => ram;
    }

    public object GetFilters() => new
    {
        Brands = brandProviderService.GetBrands<Ram>()
    };
}