using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Infrastructure.Services.Base;

namespace Backend.Infrastructure.Services.Common.Filters;

public class SsdFilterService(IBrandProviderService brandProviderService) : FilterServiceBase<Ssd>(brandProviderService)
{
    public override Filter<Ssd> BuildFilter(IDictionary<string, string> criteria)
    {
        return ssd => ssd;
    }

    public override object GetFilters()
    {
        var baseFilters = GetBaseFilters();

        return new
        {
            baseFilters.Brands,
            baseFilters.Price,
            CapacityInGb = new Range<int>(1000, 5000),
            StorageInterfaces = Enum.GetNames<StorageInterface>().ToList(),
            ReadSpeed = new Range<int>(1000, 10000),
            WriteSpeed = new Range<int>(1000, 10000)
        };
    }
}