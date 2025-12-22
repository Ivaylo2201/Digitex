using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

public class RamFilterService(IBrandProviderService<Ram> brandProviderService)
    : FilterServiceBase<Ram, RamFilters>(brandProviderService)
{
    public override Filter<Ram> BuildFilter(IDictionary<string, string> criteria) => processor => processor;

    public override RamFilters Filters => new(
        Brands,
        new List<int> { 4, 8, 16, 32, 64, 128 },
        Enum.GetValues<MemoryType>().Select(memoryType => memoryType.GetEnumMemberValue()).ToList(),
        Enum.GetValues<Frequency>().Cast<int>().ToList()
    );
}
