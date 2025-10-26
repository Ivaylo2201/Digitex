using System.Diagnostics;
using Backend.Application.CQRS.Entities.Review.Queries;
using Backend.Application.DTOs.Review;
using Backend.Application.Extensions;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Entities.Review.Handlers;

public class ListReviewsQueryHandler(ILogger<ListReviewsQueryHandler> logger, IReviewRepository reviewRepository) : IQueryHandler<ListReviewsQuery, Result<List<ReviewDto>>>
{
    private const string QueryName = nameof(ListReviewsQuery);
    
    public async Task<Result<List<ReviewDto>>> HandleAsync(ListReviewsQuery query, CancellationToken ct)
    {
        var source = GetType().Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogQueryExecutionStart(source, QueryName);
        
        var entities = await reviewRepository.ListAllForProductAsync(query.ProductId, ct);
        var projections = entities.Select(entity => entity.ToReviewDto()).ToList();
        
        logger.LogQueryExecutionDuration(source, QueryName, stopwatch);

        return Result<List<ReviewDto>>.Success(projections);
    }
}