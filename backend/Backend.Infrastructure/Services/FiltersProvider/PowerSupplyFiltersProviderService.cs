using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.FiltersProvider;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class PowerSupplyFiltersProviderService(IBrandRepository brandRepository) : IFiltersProviderService<PowerSupplyFilters>
{
    public async Task<PowerSupplyFilters> ProvideFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new PowerSupplyFilters
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