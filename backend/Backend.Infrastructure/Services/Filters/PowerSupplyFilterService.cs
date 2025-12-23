using Backend.Application.Dtos.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services.Filters;

public class PowerSupplyFilterService(IProductRepository<PowerSupply> productRepository)
    : FilterServiceBase<PowerSupply, PowerSupplyFilters>(productRepository)
{
    public override Filter<PowerSupply> BuildFilter(IDictionary<string, string> criteria) => filter => filter;
    
    public override async Task<Result<PowerSupplyFilters>> GetFiltersAsync(CancellationToken stoppingToken = default)
    {
        var filters = new PowerSupplyFilters
        {
            Brands = await ListBrandsAsync(stoppingToken),
            FormFactors = Enum.GetValues<FormFactor>()
                .Select(formFactor => formFactor.GetEnumMemberValue())
                .ToList(),
            Modularities = Enum.GetValues<Modularity>()
                .Select(modularity => modularity.GetEnumMemberValue())
                .ToList(),
            MinEfficiencyPercentage = 0,
            MaxEfficiencyPercentage = 100
        };

        return Result<PowerSupplyFilters>.Success(StatusCodes.Status200OK, filters);
    }
}
