using Backend.Application.Contracts.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class MotherboardFiltersProviderService(IBrandRepository brandRepository) : IFiltersProviderService<MotherboardFilters>
{
    public async Task<MotherboardFilters> ProvideFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new MotherboardFilters
        {
            Brands = await brandRepository.ListBrandNamesAsync<Motherboard>(stoppingToken),
            Sockets = Enum.GetValues<Socket>()
                .Select(socket => socket.GetEnumMemberValue())
                .ToList(),
            FormFactors = Enum.GetValues<FormFactor>()
                .Select(formFactor => formFactor.GetEnumMemberValue())
                .ToList(),
            Chipsets = Enum.GetValues<Chipset>()
                .Select(chipset => chipset.GetEnumMemberValue())
                .ToList()
        };
    }
}