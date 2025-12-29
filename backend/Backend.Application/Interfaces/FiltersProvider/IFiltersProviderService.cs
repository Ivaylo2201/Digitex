namespace Backend.Application.Interfaces.FiltersProvider;

public interface IFiltersProviderService<TFilter>
{
    Task<TFilter> ProvideFiltersAsync(CancellationToken stoppingToken = default);
}