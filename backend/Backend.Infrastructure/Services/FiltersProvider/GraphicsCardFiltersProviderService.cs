using Backend.Application.Contracts.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class GraphicsCardFiltersProviderService(IBrandRepository brandRepository) : IFiltersProviderService<GraphicsCardFilters>
{
    public async Task<GraphicsCardFilters> ProvideFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new GraphicsCardFilters
        {
            Brands = await brandRepository.ListBrandNamesAsync<GraphicsCard>(stoppingToken),
            BusWidths = Enum.GetValues<BusWidth>().Cast<int>().ToList(),
            MemoryCapacities = new List<int> { 2, 4, 6, 8, 10, 12, 16, 24 },
            MinClockSpeed = 1,
            MaxClockSpeed = 5,
            CudaCores = new List<int> { 2048, 3072, 3584, 4352, 5888, 8704, 10496 }
        };
    }
}