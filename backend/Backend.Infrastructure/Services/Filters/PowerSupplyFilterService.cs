using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

public class PowerSupplyFilterService(IBrandProviderService<PowerSupply> brandProviderService) 
    : FilterServiceBase<PowerSupply>(brandProviderService)
{
    public override Filter<PowerSupply> BuildFilter(IDictionary<string, string> criteria) => filter => filter;

    public override object Filters => new
    {
        Brands,
        FormFactors = Enum.GetValues<FormFactor>().Select(formFactor => formFactor.GetEnumMemberValue()),
        Modularities = Enum.GetValues<Modularity>().Select(modularity => modularity.GetEnumMemberValue()),
        MinEfficiencyPercentage = 0,
        MaxEfficiencyPercentage = 100
    };
}