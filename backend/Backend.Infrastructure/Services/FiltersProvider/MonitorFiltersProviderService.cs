using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.FiltersProvider;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class MonitorFiltersProviderService(IBrandRepository brandRepository) : IFiltersProviderService<MonitorFilters>
{
    public async Task<MonitorFilters> ProvideFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new MonitorFilters
        {
            Brands = await brandRepository.ListBrandNamesAsync<Monitor>(stoppingToken),
            RefreshRates = Enum.GetValues<RefreshRate>()
                .Cast<int>()
                .ToList(),
            Matrices = Enum.GetValues<Matrix>()
                .Select(matrix => matrix.GetEnumMemberValue())
                .ToList(),
            ResolutionTypes = Enum.GetValues<ResolutionType>()
                .Select(resolutionType => resolutionType.GetEnumMemberValue())
                .ToList()
        };
    }
}