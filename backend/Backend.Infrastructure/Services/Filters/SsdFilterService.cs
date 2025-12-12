using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

public class SsdFilterService(IBrandProviderService<Ssd> brandProviderService)
    : FilterServiceBase<Ssd>(brandProviderService)
{
    public override Filter<Ssd> BuildFilter(IDictionary<string, string> criteria) => ssd => ssd;

    public override object Filters => new
    {
        Brands,
        MemoryCapacities = new List<int> { 1000, 2000, 3000, 4000, 5000 },
        StorageInterfaces = Enum.GetValues<StorageInterface>().Select(storageInterface => storageInterface.GetEnumMemberValue()),
        ReadSpeed = new Range<int>(1000, 10000),
        WriteSpeed = new Range<int>(1000, 10000)
    };
}