using System.Net;
using Backend.Application.UseCases.Carts.AddToCart;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Backend.Tests;

public class AddToCartRequestHandlerTests
{
    private readonly Mock<ILogger<AddToCartRequestHandler>> _logger = new();
    private readonly Mock<IUserRepository> _userRepository = new();
    private readonly Mock<ICartRepository> _cartRepository = new();

    private readonly AddToCartRequestHandler _handler;

    public AddToCartRequestHandlerTests()
    {
        _handler = new AddToCartRequestHandler(
            _logger.Object,
            _userRepository.Object,
            _cartRepository.Object);
    }

    [Fact]
    public async Task Handle_Should_Add_Item_To_Cart_When_User_Exists()
    {
        // Arrange
        var request = new AddToCartRequest
        {
            UserId = 1,
            ProductId = Guid.NewGuid(),
            Quantity = 2
        };

        var user = new User
        {
            Username = "test",
            Password = "test",
            Email = "",
            Cart = new Cart()
        };

        _userRepository
            .Setup(x => x.GetOneByIdWithCartAsync(request.UserId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        _cartRepository
            .Setup(x => x.AddToCartAsync(It.IsAny<Item>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.Equal("Item added to cart successfully.", result.Value.Message);

        _cartRepository.Verify(x => x.AddToCartAsync(
            It.Is<Item>(i =>
                i.ProductId == request.ProductId &&
                i.Quantity == request.Quantity &&
                i.CartId == user.Cart.Id),
            It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_Return_NotFound_When_User_Does_Not_Exist()
    {
        // Arrange
        var request = new AddToCartRequest
        {
            UserId = 1,
            ProductId = Guid.NewGuid(),
            Quantity = 2
        };

        _userRepository
            .Setup(x => x.GetOneByIdWithCartAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User)null);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);

        _cartRepository.Verify(
            x => x.AddToCartAsync(It.IsAny<Item>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }
}
