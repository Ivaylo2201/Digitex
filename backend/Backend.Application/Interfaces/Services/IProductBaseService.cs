using Backend.Application.Dtos.Admin;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IProductBaseService
{
    Task<Result> UpdateRatingAsync(Guid id, CancellationToken stoppingToken = default);
    Task<Result> AddSuggestionAsync(AddSuggestionDto dto, CancellationToken stoppingToken = default);
}