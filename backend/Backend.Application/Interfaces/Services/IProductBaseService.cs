using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IProductBaseService
{
    Task<Result> UpdateRatingAsync(Guid id, CancellationToken stoppingToken = default);
}