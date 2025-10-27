using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Common.Filters;

public class MotherboardFilterService(IBrandProviderService brandProviderService) : IFilterService<Motherboard>
{
    public Filter<Motherboard> BuildFilter(IDictionary<string, string> criteria)
    {
        return motherboard => motherboard;
    }

    public object GetFilters() => new
    {
        Brands = brandProviderService.GetBrands<Motherboard>()
    };
}