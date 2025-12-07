using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

public class ProcessorFilterService(IBrandProviderService<Processor> brandProviderService)
    : FilterServiceBase<Processor>(brandProviderService)
{
    public override Filter<Processor> BuildFilter(IDictionary<string, string> criteria) => processor => processor;

    public override object GetFilters() => new
    {
        BaseFilters.Brands,
        BaseFilters.Price,
        Cores = new List<int> { 4, 6, 8, 10, 12, 14, 16, 20, 24 },
        Threads = new List<int> { 8, 12, 16, 20, 24, 28, 32 },
        Socket = Enum.GetValues<Socket>().Select(socket => socket.GetEnumMemberValue()),
        Tdp = new Range<int>(50, 250),
        BaseClockSpeed = new Range<double>(1.0, 10.0),
        BoostClockSpeed = new Range<double>(1.0, 10.0)
    };
}