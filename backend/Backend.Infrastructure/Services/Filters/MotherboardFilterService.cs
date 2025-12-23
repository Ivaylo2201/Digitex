using Backend.Application.Dtos.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services.Filters;

public class MotherboardFilterService(IProductRepository<Motherboard> productRepository)
    : FilterServiceBase<Motherboard, MotherboardFilters>(productRepository)
{
    public override Filter<Motherboard> BuildFilter(IDictionary<string, string> criteria) => query => query;
    
    public override async Task<Result<MotherboardFilters>> GetFiltersAsync(CancellationToken stoppingToken = default)
    {
        var filters = new MotherboardFilters
        {
            Brands = await ListBrandsAsync(stoppingToken),
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

        return Result<MotherboardFilters>.Success(StatusCodes.Status200OK, filters);
    }
}