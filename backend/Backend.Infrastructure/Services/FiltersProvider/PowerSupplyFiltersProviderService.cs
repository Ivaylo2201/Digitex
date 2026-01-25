using Backend.Application.DTOs.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class PowerSupplyFiltersProviderService(IBrandRepository brandRepository) : IFiltersProviderService<PowerSupplyFiltersDto>
{
    public async Task<PowerSupplyFiltersDto> ProvideFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new PowerSupplyFiltersDto
        {
            Brands = await brandRepository.ListBrandNamesAsync<PowerSupply>(stoppingToken),
            FormFactors = Enum.GetValues<FormFactor>()
                .Select(formFactor => formFactor.GetEnumMemberValue())
                .ToList(),
            Modularities = Enum.GetValues<Modularity>()
                .Select(modularity => modularity.GetEnumMemberValue())
                .ToList(),
            MinEfficiencyPercentage = 0,
            MaxEfficiencyPercentage = 100
        };
    }
}