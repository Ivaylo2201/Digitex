using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;

namespace Backend.Infrastructure.Services.Common.Filters;

using Monitor = Backend.Domain.Entities.Monitor;

public class MonitorFilterService(IBrandProviderService brandProviderService) : IFilterService<Monitor>
{
    public Filter<Monitor> Build(IDictionary<string, string> criteria)
    {
        return monitor => monitor;
    }

    public object Get() => new
    {
        Brands = brandProviderService.GetBrands<Monitor>()
    };
}