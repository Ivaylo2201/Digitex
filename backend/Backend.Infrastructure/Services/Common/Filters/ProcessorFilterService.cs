using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Infrastructure.Services.Base;

namespace Backend.Infrastructure.Services.Common.Filters;

public class ProcessorFilterService(IBrandProviderService brandProviderService) : FilterServiceBase<Processor>(brandProviderService)
{
    public override Filter<Processor> BuildFilter(IDictionary<string, string> criteria)
    {
        return processor => processor;
    }

    public override object GetFilters()
    {
        var baseFilters = GetBaseFilters();

        return new
        {
            baseFilters.Brands,
            baseFilters.Price,
            Cores = new List<int> { 4, 6, 8, 10, 12, 14, 16, 20, 24 },
            Threads = new List<int> { 8, 12, 16, 20, 24, 28, 32 },
            Socket = Enum.GetValues<Socket>().Select(socket => socket.GetEnumMemberValue()),
            Tdp = new Range<int>(50, 250),
            BaseClockSpeed = new Range<double>(1.0, 10.0),
            BoostClockSpeed = new Range<double>(1.0, 10.0)
        };
    }
}