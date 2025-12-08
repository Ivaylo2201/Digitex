using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

public class GraphicsCardFilterService(IBrandProviderService<GraphicsCard> brandProviderService) 
    : FilterServiceBase<GraphicsCard>(brandProviderService)
{
    public override Filter<GraphicsCard> BuildFilter(IDictionary<string, string> criteria) => filter => filter;

    public override object GetFilters() => new
    {
        BaseFilters.Brands,
        BaseFilters.Price,
        BusWidth = Enum.GetValues<BusWidth>().Cast<int>().ToList(),
        MemoryCapacity = new List<int> { 2, 4, 6, 8, 10, 12, 16, 24 },
        BaseClockSpeed = new Range<double>(1.0, 5.0),
        CudaCores = new List<int> { 2048, 3072, 3584, 4352, 5888, 8704, 10496 }
    };
}