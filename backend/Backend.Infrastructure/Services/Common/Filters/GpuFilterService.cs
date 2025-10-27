using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Infrastructure.Services.Base;

namespace Backend.Infrastructure.Services.Common.Filters;

public class GpuFilterService(IBrandProviderService brandProviderService) : FilterServiceBase<Gpu>(brandProviderService)
{
    public override Filter<Gpu> BuildFilter(IDictionary<string, string> criteria)
    {
        return filter => filter;
    }

    public override object GetFilters()
    {
        var baseFilters = GetBaseFilters();

        return new
        {
            baseFilters.Brands,
            baseFilters.Price
        };
    }
}