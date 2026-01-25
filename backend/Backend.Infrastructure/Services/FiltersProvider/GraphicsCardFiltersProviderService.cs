using Backend.Application.DTOs.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class GraphicsCardFiltersProviderService(IBrandRepository brandRepository) : IFiltersProviderService<GraphicsCardFiltersDto>
{
    public async Task<GraphicsCardFiltersDto> ProvideFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new GraphicsCardFiltersDto
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