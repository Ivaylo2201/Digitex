using Backend.Application.Dtos.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services.Filters;

public class SsdFilterService(IProductRepository<Ssd> productRepository)
    : FilterServiceBase<Ssd, SsdFilters>(productRepository)
{
    public override Filter<Ssd> BuildFilter(IDictionary<string, string> criteria) => ssd => ssd;
    
    public override async Task<Result<SsdFilters>> GetFiltersAsync(CancellationToken stoppingToken = default)
    {
        var filters = new SsdFilters
        {
            Brands = await ListBrandsAsync(stoppingToken),
            MemoryCapacities = new List<int> { 1000, 2000, 3000, 4000, 5000 },
            StorageInterfaces = Enum.GetValues<StorageInterface>()
                .Select(storageInterface => storageInterface.GetEnumMemberValue())
                .ToList(),
            MinReadSpeed = 1000,
            MaxReadSpeed = 10000,
            MinWriteSpeed = 1000,
            MaxWriteSpeed = 10000
        };

        return Result<SsdFilters>.Success(StatusCodes.Status200OK, filters);
    }
}
