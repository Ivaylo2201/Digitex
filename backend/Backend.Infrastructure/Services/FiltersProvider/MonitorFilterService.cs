using Backend.Application.DTOs.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class MonitorFilterService(IBrandRepository brandRepository) : IFilterService<MonitorFiltersDto>
{
    public async Task<MonitorFiltersDto> GetFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new MonitorFiltersDto
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