namespace Backend.Application.Interfaces.Services;

public interface IFiltersProviderService<TFilter>
{
    Task<TFilter> ProvideFiltersAsync(CancellationToken stoppingToken = default);
}