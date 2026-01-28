using Backend.Application.DTOs.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Infrastructure.Services.FiltersProvider;

public class ProcessorFilterService(IBrandRepository brandRepository) : IFilterService<ProcessorFiltersDto>
{
    public async Task<ProcessorFiltersDto> GetFiltersAsync(CancellationToken stoppingToken = default)
    {
        return new ProcessorFiltersDto
        {
            Brands = await brandRepository.ListBrandNamesAsync<Processor>(stoppingToken),
            Cores = new List<int> { 4, 6, 8, 10, 12, 14, 16, 20, 24 },
            Threads = new List<int> { 8, 12, 16, 20, 24, 28, 32 },
            Sockets = Enum.GetValues<Socket>()
                .Select(socket => socket.GetEnumMemberValue())
                .ToList(),
            MinTdp = 50,
            MaxTdp = 250
        };
    }
}