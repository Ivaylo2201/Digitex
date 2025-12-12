using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;

namespace Backend.Infrastructure.Services.Filters;

public class GraphicsCardFilterService(IBrandProviderService<GraphicsCard> brandProviderService) 
    : FilterServiceBase<GraphicsCard>(brandProviderService)
{
    public override Filter<GraphicsCard> BuildFilter(IDictionary<string, string> criteria) => filter => filter;

    public override object Filters => new
    {
        Brands,
        BusWidths = Enum.GetValues<BusWidth>().Cast<int>().ToList(),
        MemoryCapacities = new List<int> { 2, 4, 6, 8, 10, 12, 16, 24 },
        MinClockSpeed = 1,
        MaxClockSpeed = 5,
        CudaCores = new List<int> { 2048, 3072, 3584, 4352, 5888, 8704, 10496 }
    };
}