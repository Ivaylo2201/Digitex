using System.Diagnostics;
using Backend.Application.CQRS.Entities.Review.Commands;
using Backend.Application.DTOs.Review;
using Backend.Application.Extensions;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Entities.Review.Handlers;

using Review = Domain.Entities.Review;

public class AddReviewCommandHandler(ILogger<AddReviewCommandHandler> logger, IReviewRepository reviewRepository) : ICommandHandler<AddReviewCommand, Result<ReviewDto>>
{
    private const string QueryName = nameof(AddReviewCommand);
    private const string Source = nameof(AddReviewCommandHandler);
    
    public async Task<Result<ReviewDto>> HandleAsync(AddReviewCommand command, CancellationToken ct)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogQueryExecutionStart(Source, QueryName);
        
        var review = await reviewRepository.CreateAsync(new Review
        {
            Rating = command.Dto.Rating,
            Comment = command.Dto.Comment,
            ProductId = command.Dto.ProductId,
            UserId = command.Dto.UserId
        }, ct);
        var projection = review.ToReviewDto();
        
        logger.LogQueryExecutionDuration(Source, QueryName, stopwatch);
        return Result<ReviewDto>.Success(projection);
    }
}