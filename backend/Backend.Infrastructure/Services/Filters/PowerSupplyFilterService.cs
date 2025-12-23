using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

public class PowerSupplyFilterService(IBrandProviderService<PowerSupply> brandProviderService)
    : FilterServiceBase<PowerSupply, PowerSupplyFilters>(brandProviderService)
{
    public override Filter<PowerSupply> BuildFilter(IDictionary<string, string> criteria) => filter => filter;

    public override PowerSupplyFilters Filters => new(
        Brands,
        Enum.GetValues<FormFactor>().Select(formFactor => formFactor.GetEnumMemberValue()).ToList(),
        Enum.GetValues<Modularity>().Select(modularity => modularity.GetEnumMemberValue()).ToList(),
        0,
        100
    );
}
