using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

public class ProcessorFilterService(IBrandProviderService<Processor> brandProviderService)
    : FilterServiceBase<Processor, ProcessorFilters>(brandProviderService)
{
    public override Filter<Processor> BuildFilter(IDictionary<string, string> criteria) => processor => processor;

    public override ProcessorFilters Filters => new(
        Brands,
        new List<int> { 4, 6, 8, 10, 12, 14, 16, 20, 24 },
        new List<int> { 8, 12, 16, 20, 24, 28, 32 },
        Enum.GetValues<Socket>().Select(socket => socket.GetEnumMemberValue()).ToList(),
        50,
        250
    );
}
