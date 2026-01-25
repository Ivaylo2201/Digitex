using Backend.Application.DTOs.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class RamFiltersProviderService(IBrandRepository brandRepository) : IFiltersProviderService<RamFiltersDto>
{
    public async Task<RamFiltersDto> ProvideFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new RamFiltersDto
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