using Backend.Application.Dtos.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services.Filters;

public class ProcessorFilterService(IProductRepository<Processor> productRepository)
    : FilterServiceBase<Processor, ProcessorFilters>(productRepository)
{
    public override Filter<Processor> BuildFilter(IDictionary<string, string> criteria) => processor => processor;
    
    public override async Task<Result<ProcessorFilters>> GetFiltersAsync(CancellationToken stoppingToken = default)
    {
        var filters = new ProcessorFilters
        {
            Brands = await ListBrandsAsync(stoppingToken),
            Cores = new List<int> { 4, 6, 8, 10, 12, 14, 16, 20, 24 },
            Threads = new List<int> { 8, 12, 16, 20, 24, 28, 32 },
            Sockets = Enum.GetValues<Socket>()
                .Select(socket => socket.GetEnumMemberValue())
                .ToList(),
            MinTdp = 50,
            MaxTdp = 250
        };

        return Result<ProcessorFilters>.Success(StatusCodes.Status200OK, filters);
    }
}
