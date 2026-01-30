using Backend.Application.DTOs.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class GraphicsCardFilterService(IBrandRepository brandRepository) : IFilterService<GraphicsCardFiltersDto>
{
    public async Task<GraphicsCardFiltersDto> GetFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new GraphicsCardFiltersDto
        {
            Brands = await brandRepository.ListBrandNamesAsync<GraphicsCard>(stoppingToken),
            BusWidths = new List<int> { 128, 256 },
            MemoryCapacities = new List<int> { 2, 4, 6, 8, 10, 12, 16, 24 },
            MinClockSpeed = 1,
            MaxClockSpeed = 5,
            CudaCores = new List<int> { 2048, 3072, 3584, 4352, 5888, 8704, 10496 }
        };
    }
}