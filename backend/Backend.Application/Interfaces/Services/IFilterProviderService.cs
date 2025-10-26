using Backend.Application.Filters;

namespace Backend.Application.Interfaces.Services;

public interface IFilterProviderService
{
    CpuFilters GetCpuFilters();
    SsdFilters GetSsdFilters();
}