using Backend.Application.Dtos.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services.Filters;

public class RamFilterService(IProductRepository<Ram> productRepository)
    : FilterServiceBase<Ram, RamFilters>(productRepository)
{
    public override Filter<Ram> BuildFilter(IDictionary<string, string> criteria) => processor => processor;
    
    public override async Task<Result<RamFilters>> GetFiltersAsync(CancellationToken stoppingToken = default)
    {
        var filters = new RamFilters
        {
            Brands = await ListBrandsAsync(stoppingToken),
            MemoryCapacities = new List<int> { 4, 8, 16, 32, 64, 128 },
            MemoryTypes = Enum.GetValues<MemoryType>()
                .Select(memoryType => memoryType.GetEnumMemberValue())
                .ToList(),
            Frequencies = Enum.GetValues<Frequency>()
                .Cast<int>()
                .ToList()
        };

        return Result<RamFilters>.Success(StatusCodes.Status200OK, filters);
    }
}
