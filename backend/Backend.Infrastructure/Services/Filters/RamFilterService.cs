using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

public class RamFilterService(IBrandProviderService<Ram> brandProviderService) :
    FilterServiceBase<Ram>(brandProviderService)
{
    public override Filter<Ram> BuildFilter(IDictionary<string, string> criteria) => processor => processor;

    public override object Filters => new
    {
        Brands,
        MemoryCapacities = new List<int> { 4, 8, 16, 32, 64, 128 },
        MemoryTypes = Enum.GetValues<MemoryType>().Select(memoryType => memoryType.GetEnumMemberValue()),
        Frequencies = Enum.GetValues<Frequency>().Cast<int>().ToList()
    };
}