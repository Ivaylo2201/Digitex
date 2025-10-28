using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IProductBaseService
{
    Task<Result> UpdateRatingAsync(
        Guid id,
        IServiceProvider serviceProvider,
        CancellationToken stoppingToken = default);
}