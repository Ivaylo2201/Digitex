using Backend.Application.Contracts.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class SsdFiltersProviderService(IBrandRepository brandRepository) : IFiltersProviderService<SsdFilters>
{
    public async Task<SsdFilters> ProvideFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new SsdFilters
        {
            Brands = await brandRepository.ListBrandNamesAsync<Ssd>(stoppingToken),
            MemoryCapacities = new List<int> { 1000, 2000, 3000, 4000, 5000 },
            StorageInterfaces = Enum.GetValues<StorageInterface>()
                .Select(storageInterface => storageInterface.GetEnumMemberValue())
                .ToList(),
            MinReadSpeed = 1000,
            MaxReadSpeed = 10000,
            MinWriteSpeed = 1000,
            MaxWriteSpeed = 10000
        };
    }
}