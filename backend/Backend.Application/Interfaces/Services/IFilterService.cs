namespace Backend.Application.Interfaces.Services;

public interface IFilterService<TFilters>
{
    Task<TFilters> GetFiltersAsync(CancellationToken stoppingToken = default);
}