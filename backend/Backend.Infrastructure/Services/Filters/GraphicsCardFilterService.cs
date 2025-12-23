using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;

namespace Backend.Infrastructure.Services.Filters;

public class GraphicsCardFilterService(IBrandProviderService<GraphicsCard> brandProviderService) 
    : FilterServiceBase<GraphicsCard, GraphicsCardFilters>(brandProviderService)
{
    public override Filter<GraphicsCard> BuildFilter(IDictionary<string, string> criteria) => filter => filter;

    public override GraphicsCardFilters Filters => new(
        Brands,
        Enum.GetValues<BusWidth>().Cast<int>().ToList(),
        new List<int> { 2, 4, 6, 8, 10, 12, 16, 24 },
        1,
        5,
        new List<int> { 2048, 3072, 3584, 4352, 5888, 8704, 10496 }
    );
}