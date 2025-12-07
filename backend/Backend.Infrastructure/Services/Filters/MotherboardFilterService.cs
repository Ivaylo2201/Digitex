using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Filters;

public class MotherboardFilterService(IBrandProviderService brandProviderService) : FilterServiceBase<Motherboard>(brandProviderService)
{
    public override Filter<Motherboard> BuildFilter(IDictionary<string, string> criteria) => filter => filter;

    public override object GetFilters() => new
    {
        BaseFilters.Brands,
        BaseFilters.Price
    };
}