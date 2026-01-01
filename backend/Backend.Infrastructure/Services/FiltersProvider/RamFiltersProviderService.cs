using Backend.Application.Contracts.Filters;
using Backend.Application.Interfaces.FiltersProvider;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class RamFiltersProviderService(IBrandRepository brandRepository) : IFiltersProviderService<RamFilters>
{
    public async Task<RamFilters> ProvideFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new RamFilters
        {
            Brands = await brandRepository.ListBrandNamesAsync<Ram>(stoppingToken),
            MemoryCapacities = new List<int> { 4, 8, 16, 32, 64, 128 },
            MemoryTypes = Enum.GetValues<MemoryType>()
                .Select(memoryType => memoryType.GetEnumMemberValue())
                .ToList(),
            Frequencies = Enum.GetValues<Frequency>()
                .Cast<int>()
                .ToList()
        };
    }
}