using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

public class SsdFilterService(IBrandProviderService<Ssd> brandProviderService)
    : FilterServiceBase<Ssd, SsdFilters>(brandProviderService)
{
    public override Filter<Ssd> BuildFilter(IDictionary<string, string> criteria) => ssd => ssd;

    public override SsdFilters Filters => new(
        Brands,
        new List<int> { 1000, 2000, 3000, 4000, 5000 },
        Enum.GetValues<StorageInterface>().Select(storageInterface => storageInterface.GetEnumMemberValue()).ToList(),
        1000,
        10000,
        1000,
        10000
    );
}
