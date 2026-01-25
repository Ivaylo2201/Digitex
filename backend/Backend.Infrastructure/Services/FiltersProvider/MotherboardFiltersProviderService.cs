using Backend.Application.DTOs.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class MotherboardFiltersProviderService(IBrandRepository brandRepository) : IFiltersProviderService<MotherboardFiltersDto>
{
    public async Task<MotherboardFiltersDto> ProvideFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new MotherboardFiltersDto
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