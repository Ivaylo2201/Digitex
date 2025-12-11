using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;

namespace Backend.Infrastructure.Services.Filters;

using Monitor = Domain.Entities.Monitor;

public class MonitorFilterService(IBrandProviderService<Monitor> brandProviderService)
    : FilterServiceBase<Monitor>(brandProviderService)
{
    public override Filter<Monitor> BuildFilter(IDictionary<string, string> criteria) => filter => filter;

    public override object GetFilters() => new
    {
        BaseFilters.Brands
    };
}