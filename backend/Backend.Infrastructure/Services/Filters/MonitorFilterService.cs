using Backend.Application.Dtos.Filters;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services.Filters;

using Monitor = Domain.Entities.Monitor;

public class MonitorFilterService(IProductRepository<Monitor> productRepository)
    : FilterServiceBase<Monitor, MonitorFilters>(productRepository)
{
    public override Filter<Monitor> BuildFilter(IDictionary<string, string> criteria) => filter => filter;
    
    public override async Task<Result<MonitorFilters>> GetFiltersAsync(CancellationToken stoppingToken = default)
    {
        var filters = new MonitorFilters
        {
            Brands = await ListBrandsAsync(stoppingToken),
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

        return Result<MonitorFilters>.Success(StatusCodes.Status200OK, filters);
    }
}