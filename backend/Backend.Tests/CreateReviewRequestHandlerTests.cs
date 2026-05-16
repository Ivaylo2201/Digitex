using System.Net;
using Backend.Application.UseCases.Reviews.CreateReview;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Backend.Tests;

public class CreateReviewRequestHandlerTests
{
    private readonly Mock<ILogger<CreateReviewRequestHandler>> _logger = new();
    private readonly Mock<IReviewRepository> _reviewRepository = new();

    private readonly CreateReviewRequestHandler _handler;

    public CreateReviewRequestHandlerTests()
    {
        _handler = new CreateReviewRequestHandler(
            _logger.Object,
            _reviewRepository.Object);
    }

    [Fact]
    public async Task Handle_Should_Create_Review_And_Return_Success()
    {
        // Arrange
        var request = new CreateReviewRequest
        {
            ProductId = Guid.NewGuid(),
            UserId = 1,
            Rating = 5,
            Comment = "Great product!"
        };

        var review = new Review
        {
            ProductId = request.ProductId,
            UserId = request.UserId,
            Rating = request.Rating,
            Comment = request.Comment
        };

        _reviewRepository
            .Setup(x => x.CreateAsync(It.IsAny<Review>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(review);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(request.Rating, result.Value.Rating);
        Assert.Equal(request.Comment, result.Value.Comment);
    }

    [Fact]
    public async Task Handle_Should_Call_Repository_Once()
    {
        // Arrange
        var request = new CreateReviewRequest
        {
            ProductId = Guid.NewGuid(),
            UserId = 1,
            Rating = 4,
            Comment = "Good"
        };

        _reviewRepository
            .Setup(x => x.CreateAsync(It.IsAny<Review>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Review() {Rating = 1});

        // Act
        await _handler.Handle(request, CancellationToken.None);

        // Assert
        _reviewRepository.Verify(
            x => x.CreateAsync(It.IsAny<Review>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
