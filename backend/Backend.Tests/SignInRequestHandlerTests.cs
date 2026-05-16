using System.Net;
using Backend.Application.Interfaces.Services;
using Backend.Application.UseCases.Auth.SignIn;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Backend.Tests;

public class SignInRequestHandlerTests
{
    private readonly Mock<ILogger<SignInRequestHandler>> _logger = new();
    private readonly Mock<IUserRepository> _userRepository = new();
    private readonly Mock<IJwtService> _jwtService = new();

    private readonly SignInRequestHandler _handler;

    public SignInRequestHandlerTests()
    {
        _handler = new SignInRequestHandler(
            _logger.Object,
            _userRepository.Object,
            _jwtService.Object);
    }

    [Fact]
    public async Task Handle_Should_Return_Success_When_User_Exists()
    {
        // Arrange
        var request = new SignInRequest
        {
            Email = "test@mail.com",
            Password = "1234"
        };

        var user = new User
        {
            Email = request.Email,
            Password = request.Password,
            Role = Role.Client,
            Username = "test"
        };

        _userRepository
            .Setup(x => x.GetOneByCredentialsAsync(
                request.Email,
                request.Password,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        _jwtService
            .Setup(x => x.GenerateToken(user))
            .Returns("jwt_token");

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.Equal("jwt_token", result.Value.Token);
        Assert.Equal(Role.Client, result.Value.Role);
    }

    [Fact]
    public async Task Handle_Should_Return_Failure_When_User_Not_Found()
    {
        // Arrange
        var request = new SignInRequest
        {
            Email = "test@mail.com",
            Password = "1234"
        };

        _userRepository
            .Setup(x => x.GetOneByCredentialsAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync((User)null);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
    }
}
