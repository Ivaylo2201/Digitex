using Backend.Application.Dtos.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services.Filters;

public class GraphicsCardFilterService(IProductRepository<GraphicsCard> productRepository) 
    : FilterServiceBase<GraphicsCard, GraphicsCardFilters>(productRepository)
{
    public override Filter<GraphicsCard> BuildFilter(IDictionary<string, string> criteria) => filter => filter;
    
    public override async Task<Result<GraphicsCardFilters>> GetFiltersAsync(CancellationToken stoppingToken = default)
    {
        var filters = new GraphicsCardFilters
        {
            Brands = await ListBrandsAsync(stoppingToken),
            BusWidths = Enum.GetValues<BusWidth>()
                .Cast<int>()
                .ToList(),
            MemoryCapacities = new List<int> { 2, 4, 6, 8, 10, 12, 16, 24 },
            MinClockSpeed = 1,
            MaxClockSpeed = 5,
            CudaCores = new List<int> { 2048, 3072, 3584, 4352, 5888, 8704, 10496 }
        };

        return Result<GraphicsCardFilters>.Success(StatusCodes.Status200OK, filters);
    }
}